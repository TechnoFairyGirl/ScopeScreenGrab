using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleHttp;

namespace ScopeScreenGrab
{
	public partial class MainWindow : Form
	{
		Config config = null;

		static byte[] GetPclScreenshot(string adapterHost, int gpibAddress)
		{
			var client = new TcpClient(adapterHost, 1234);
			var stream = client.GetStream();

			stream.WriteLine("++savecfg 0");
			stream.WriteLine("++mode 1");
			stream.WriteLine($"++addr {gpibAddress}");
			stream.WriteLine("++auto 0");
			stream.WriteLine("++eoi 1");
			stream.WriteLine("++eos 2");
			stream.WriteLine("++eot_enable 0");
			stream.WriteLine("++eot_char 0");
			stream.WriteLine("++read_tmo_ms 3000");
			stream.WriteLine("++ifc");

			stream.WriteLine(":HARDCOPY:MODE THINKJET");
			stream.WriteLine(":HARDCOPY:LENGTH 11");
			stream.WriteLine(":HARDCOPY:PAGE AUTOMATIC");
			stream.WriteLine(":PRINT?");
			stream.WriteLine("++read eoi");

			var pclData = new List<byte>();

			while (true)
			{
				Task.Delay(3000).Wait();
				var dataAvailable = client.Available;
				if (dataAvailable == 0) break;
				var dataBlock = stream.ReadBytes(dataAvailable);
				pclData.AddRange(dataBlock);
			}

			stream.WriteLine("++loc");

			return pclData.ToArray();
		}

		static int FindBytes<T>(IEnumerable<T> source, IEnumerable<T> pattern)
		{
			for (int i = 0; i < source.Count(); i++)
			{
				if (source.Skip(i).Take(pattern.Count()).SequenceEqual(pattern))
					return i;
			}

			return -1;
		}

		static byte[] GetImageFromPcl(byte[] pclData)
		{
			var rowHeader = new byte[] { 0x1b, 0x2a, 0x62, 0x38, 0x30, 0x57 };
			var rowLength = 80;

			var imageData = new List<byte>();
			var inputPtr = 0;

			while (true)
			{
				var rowPtr = FindBytes(pclData.Skip(inputPtr), rowHeader);
				if (rowPtr == -1) break;
				var row = pclData.Skip(inputPtr + rowPtr + rowHeader.Length).Take(rowLength).ToArray();
				inputPtr += rowPtr + rowHeader.Length + rowLength;
				imageData.AddRange(row);
			}

			return imageData.ToArray();
		}

		void RenderImage(byte[] imageData)
		{
			var width = 640;
			var height = 480;
			var border = 10;

			var fullWidth = width + (border * 2);
			var fullHeight = height + (border * 2);

			var bitmap = new Bitmap(fullWidth, fullHeight);

			for (var y = 0; y < fullHeight; y++)
				for (var x = 0; x < fullWidth; x++)
					bitmap.SetPixel(x, y , Color.FromArgb(0, 0, 0));

			var pixelCtr = 0;

			for (var y = 0; y < height; y++)
			{
				for (var x = 0; x < width; x++)
				{
					var bytePtr = Math.Min(pixelCtr / 8, imageData.Length - 1);
					var bitPtr = pixelCtr % 8;
					var bit = Convert.ToString(imageData[bytePtr], 2).PadLeft(8, '0')[bitPtr];
					var color = bit == '1' ? 255 : 0;
					pixelCtr++;
					bitmap.SetPixel(x + border, y + border, Color.FromArgb(color, color, color));
				}
			}

			if (screenshotBox.Image != null) screenshotBox.Image.Dispose();
			screenshotBox.Image = bitmap;
		}

		public MainWindow()
		{
			InitializeComponent();

			config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
			hostBox.Text = config.AdapterHost;
			addressBox.Text = config.GPIBAddress.ToString();
		}

		private void getScreenshotButton_Click(object sender, EventArgs e)
		{
			try
			{
				var adapterHost = hostBox.Text;
				var gpibAddress = int.Parse(addressBox.Text);

				this.Text = "Oscilloscope Screenshot Tool - Working...";

				hostBox.Enabled = false;
				addressBox.Enabled = false;
				getScreenshotButton.Enabled = false;
				saveScreenshotButton.Enabled = false;

				var pclData = GetPclScreenshot(adapterHost, gpibAddress);
				var imageData = GetImageFromPcl(pclData);
				RenderImage(imageData);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Something Went Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			finally
			{
				hostBox.Enabled = true;
				addressBox.Enabled = true;
				getScreenshotButton.Enabled = true;
				saveScreenshotButton.Enabled = true;

				this.Text = "Oscilloscope Screenshot Tool";
			}
		}

		private void saveScreenshotButton_Click(object sender, EventArgs e)
		{
			try
			{
				var bitmap = (Bitmap)screenshotBox.Image;
				if (bitmap == null)
				{
					MessageBox.Show("You must get an image before saving.", "Seriously?!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				var sfd = new SaveFileDialog();
				sfd.Filter = "PNG Files (*.png)|*.png";
				sfd.DefaultExt = "png";
				sfd.RestoreDirectory = true;

				if (sfd.ShowDialog() == DialogResult.OK)
					bitmap.Save(sfd.FileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Something Went Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
	}

	sealed class Config
	{
		public string AdapterHost { get; set; }
		public int GPIBAddress { get; set; }
	}
}

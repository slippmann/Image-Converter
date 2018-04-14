using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image2Bin
{
    public partial class Form1 : Form
    {
        private string[] imagePaths = new string[20];
        private string[] newPaths = new string[20];

        private int height;
        private int width;

        public Form1()
        {
            InitializeComponent();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.bmp, *.jpg, *.png) | *.bmp; *.jpg; *.png";
            openFileDialog1.Multiselect = true;
            var result = openFileDialog1.ShowDialog();

            if(result == DialogResult.OK)
            {
                imagePaths = openFileDialog1.FileNames;
                for (int i = 0; i < imagePaths.Length; i++)
                {
                    newPaths[i] = Path.GetDirectoryName(imagePaths[i]) + "\\" + Path.GetFileNameWithoutExtension(imagePaths[i]) + ".bin";
                }
            }

            Save.Enabled = (imagePaths.Length <= 1);
            SaveName.Enabled = (imagePaths.Length > 1);

            ImgFile.Text = Path.GetFileName(imagePaths[0]);
            SaveName.Text = Path.GetFileName(newPaths[0]);

            ImgFile.Text += (imagePaths.Length > 1) ? ", ..." : "";
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < imagePaths.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(newPaths[i]))
                {
                    if (!string.IsNullOrWhiteSpace(SaveName.Text) &&
                        SaveName.Text != "Save binary as...")
                    {
                        newPaths[i] = Path.GetDirectoryName(imagePaths[i]) + "\\" + SaveName.Text;
                    }
                    else
                    {
                        return;
                    }
                }

                if (!string.IsNullOrWhiteSpace(imagePaths[i]) &&
                    File.Exists(imagePaths[i]))
                {
                    var image = new Bitmap(imagePaths[i]);
                    var length = image.Height * image.Width * 2;
                    var rgb = new byte[length + 4];
                    var index = 0;

#if DEBUG
                    var rgb_st = new string[image.Height];
#endif

                    height = image.Height;
                    width = image.Width;

                    rgb[index++] = (byte)(height >> 8 & 0xFF);
                    rgb[index++] = (byte)(height & 0xFF);
                    rgb[index++] = (byte)(width >> 8 & 0xFF);
                    rgb[index++] = (byte)(width & 0xFF);

#if DEBUG
                    rgb_st[0] += String.Format("0x{0:X2}", rgb[0]) + String.Format("{0:X2},", rgb[1]);
                    rgb_st[0] += String.Format("0x{0:X2}", rgb[2]) + String.Format("{0:X2},\n", rgb[3]);
#endif


                    for (int y = 0; y < image.Height; y++)
                    {
                        for (int x = 0; x < image.Width; x++)
                        {
                            var colour = image.GetPixel(x, y);

                            var ar = (colour.A & 0xF0) | ((colour.R & 0xF0) >> 4);
                            var gb = (colour.G & 0xF0) | ((colour.B & 0xF0) >> 4);

                            rgb[index++] = (byte)ar;
                            rgb[index++] = (byte)gb;

#if DEBUG
                            rgb_st[y] += String.Format("0x{0:X2}", ar) + String.Format("{0:X2}", gb);

                            if (x != (image.Width - 1) || y != (image.Height - 1))
                            {
                                rgb_st[y] += ", ";
                            }
#endif
                        }

#if DEBUG
                        if (y < (image.Height - 1))
                        {
                            rgb_st[y] += "\\";
                        }
#endif
                    }

                    var newRgb = rgb;

                    if (EndianCheckBox.Checked == false)
                    {
                        newRgb = ToLittleEndian(rgb);
                    }

                    File.WriteAllBytes(newPaths[i], newRgb);

#if DEBUG
                    var textFile = Path.GetDirectoryName(newPaths[i]) + "\\" + Path.GetFileNameWithoutExtension(newPaths[i]) + ".txt";
                    File.WriteAllLines(textFile, rgb_st);
#endif
                }

            }

            System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(newPaths[0]));
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SaveName.Text) &&
                    SaveName.Text != "Save binary as...")
            {
                saveFileDialog1.FileName = SaveName.Text;
            }

            saveFileDialog1.DefaultExt = "bin";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.Filter = "Binary File(*.bin) | *.bin | All Files(*.*) | *.*";

            var result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                newPaths[0] = saveFileDialog1.FileName;
            }

            SaveName.Text = Path.GetFileName(newPaths[0]);
        }

        private byte[] ToLittleEndian(byte[] array)
        {
            int extra = array.Length % 4;
            var newArray = new byte[array.Length + extra];

            for (int i = 0; i < newArray.Length; i += 4)
            {
                var temp1 = array[i];
                var temp2 = array[i + 1];

                if (i + 2 >= array.Length)
                {
                    newArray[i] = 0;
                    newArray[i + 1] = 0;
                }
                else
                {
                    newArray[i] = array[i + 3];
                    newArray[i + 1] = array[i + 2];
                }

                newArray[i + 2] = temp2;
                newArray[i + 3] = temp1;
            }

            return newArray;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Activity_on_Image_processing
{
    public partial class Form1 : Form
    {
        Bitmap loadImage, resultImage;

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            loadImage = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loadImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            resultImage = new Bitmap(loadImage.Width, loadImage.Height);
            for(int x = 0; x < loadImage.Width; x++)
            {
                for(int y = 0; y < loadImage.Height; y++)
                {
                    Color pixel = loadImage.GetPixel(x, y);
                    resultImage.SetPixel(x, y, pixel);
                }
            }
            pictureBox2.Image = resultImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            resultImage = new Bitmap(loadImage.Width, loadImage.Height);
            for (int x = 0; x < loadImage.Width; x++)
            {
                for (int y = 0; y < loadImage.Height; y++)
                {
                    Color pixel = loadImage.GetPixel(x, y);
                    int grey = (pixel.R+ pixel.G+ pixel.B) / 3;

                    resultImage.SetPixel(x, y, Color.FromArgb(grey,grey, grey));
                }
            }
            pictureBox2.Image = resultImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            resultImage = new Bitmap(loadImage.Width, loadImage.Height);
            for (int x = 0; x < loadImage.Width; x++)
            {
                for (int y = 0; y < loadImage.Height; y++)
                {
                    Color pixel = loadImage.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;

                    resultImage.SetPixel(x, y, Color.FromArgb(255-pixel.R, 255 - pixel.G, 255 - pixel.B));
                }
            }
            pictureBox2.Image = resultImage;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            resultImage = new Bitmap(loadImage.Width, loadImage.Height);
            for (int x = 0; x < loadImage.Width; x++)
            {
                for (int y = 0; y < loadImage.Height; y++)
                {
                    Color pixel = loadImage.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;

                    resultImage.SetPixel(x, y, Color.FromArgb(grey, grey, grey));
                }
            }
            Color sample;
            int[] histdata = new int[256];
            for (int x = 0; x < loadImage.Width; x++)
            {
                for (int y = 0; y < loadImage.Height; y++)
                {
                    sample = resultImage.GetPixel(x, y);
                    histdata[sample.R]++;
                }
            }
            Bitmap mydata = new Bitmap(256, 800);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    mydata.SetPixel(x, y, Color.White);
                }
            }

            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < Math.Min(histdata[x]/5, 800); y++)
                {
                    mydata.SetPixel(x, 799-y, Color.Black);
                }
            }
            resultImage = mydata;
            pictureBox2.Image = mydata;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            resultImage = new Bitmap(loadImage.Width, loadImage.Height);
            for (int x = 0; x < loadImage.Width; x++)
            {
                for (int y = 0; y < loadImage.Height; y++)
                {
                    Color pixel = loadImage.GetPixel(x, y);
                    int red = (int)(pixel.R * 0.393 + pixel.G * 0.769 + pixel.B * 0.189);
                    if (red > 255)
                        red = 255;
                    int green = (int)(pixel.R * 0.349 + pixel.G * 0.686 + pixel.B * 0.168);
                    if (green > 255)
                        green = 255;
                    int blue = (int)(pixel.R * 0.272 + pixel.G * 0.534 + pixel.B * 0.131);
                    if (blue > 255)
                        blue = 255;
                    resultImage.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
            pictureBox2.Image = resultImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            resultImage.Save(saveFileDialog1.FileName);
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}

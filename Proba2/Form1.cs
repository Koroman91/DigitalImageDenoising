using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proba2
{
    public partial class Form1 : Form
    {
        //private PixelFormat height;

        public Form1()
        {
            InitializeComponent();
        }

        public object SimplexNoise { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 12;

            if (i == 10)
            {
                MessageBox.Show("Deset");
            }
            else
            {
                MessageBox.Show("Nije deset");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = 2;
            int b = 3;

            int result = 0;

            if (a % 2 == 0 && b % 2 == 0)
            {
                result = a + b; 
                MessageBox.Show("Resenje parnih brojeva je: " + result);
            }
            else
            {
                result = a + b;
                MessageBox.Show("Resenje neparnih brojeva je: " + result);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bitmaps|*.bmp; *.jpeps; *.jpg; *.png; *.jpeg; *.tiff; *.gif;" ;
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Bitmap.FromFile(openFileDialog.FileName);
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = @"C:\\Users\\Stefan-Ivan\\Desktop";
            saveFile.Filter = "Image Files(*.jpg,*.png,*.tiff,*.bmp,*.gif)|*.jpg;*.png;*.tiff;*.bmp;*.gif";
            saveFile.Title = "Save an Image";
            saveFile.AddExtension = true;
            saveFile.DefaultExt = "jpg";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string fName = saveFile.FileName;
                pictureBox1.Image.Save(fName, ImageFormat.Jpeg);
            }
        }
        int width = 300;
        int height = 300;
        private int noise;

        int[] mask = new int[9];




        // dio koda koji omogucuje da se promene izvrse nad slikom, tu dodavati za svako sledece dugme
        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.Text = "DEVASP Image APPLICATION";

            for (int i = 0; i < 9; i++)

            {

                mask[i] = 1;

            }


     

            button6.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;


        }




        private void button5_Click(object sender, EventArgs e)
        {
           
            Bitmap finalBmp = (Bitmap)pictureBox1.Image;
            Random r = new Random();
            int width = finalBmp.Size.Width;
            int height = finalBmp.Size.Height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y ++)
                {
                    int num = r.Next(0, 255);
                    finalBmp.SetPixel(x, y, Color.FromArgb(255,num, num, num));
                }
            }
            //return finalBmp;
            pictureBox1.Image = finalBmp;
            button4.Enabled = true;
        }
       
        private void button6_Click(object sender, EventArgs e)
        {

            Bitmap grays = (Bitmap)pictureBox1.Image;
            int width = grays.Size.Width;
            int height = grays.Size.Height;

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Color col;
                    col = grays.GetPixel(i, j);

                    grays.SetPixel(i, j, Color.FromArgb((col.R + col.G + col.B) / 3, (col.R + col.G + col.B) / 3, (col.R + col.G + col.B) / 3));
                }
            }

            pictureBox1.Image = grays;
            button4.Enabled = true;


        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap NewBitmap = (Bitmap)pictureBox1.Image;
            Random rand = new Random();
            //double rnoise;
            int noise;
            //int range = 2*noise;
            int width = NewBitmap.Size.Width;
            int height = NewBitmap.Size.Height;


          
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        Color col;
                        col = NewBitmap.GetPixel(i, j);
                        noise = rand.Next(240, 256);
                    if (col.R == 140 || col.G == 140 || col.B == 140)
                    {
                        NewBitmap.SetPixel(i, j, Color.FromArgb(255, noise, noise, noise));
                    }

                       
        
                    }
                }
            
            pictureBox1.Image = NewBitmap;
            button4.Enabled = true;


        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap NewBitmap = (Bitmap)pictureBox1.Image;
            Random rand = new Random();
            int noise;
            int noise1;

            int width = NewBitmap.Size.Width;
            int height = NewBitmap.Size.Height;



            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Color col;
                    col = NewBitmap.GetPixel(i, j);
                    noise = rand.Next(255, 256);
                    noise1 = rand.Next(0,1);
                    if (col.R >= 0 && col.R < 128 || col.G >= 0 && col.G < 128 || col.B == 0 && col.B < 128)
                    {
                        NewBitmap.SetPixel(i, j, Color.FromArgb(255, noise, noise, noise));
                    }
                    else if (col.R >= 128 && col.R <= 255 || col.G >= 128 && col.G <= 255 || col.B == 128 && col.B <= 255)
                    {
                        NewBitmap.SetPixel(i, j, Color.FromArgb(255, noise1, noise1, noise1));
                    }


                }
            }

            pictureBox1.Image = NewBitmap;
            button4.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(pictureBox1.Image);

            Color c;



            for (int ii = 0; ii < img.Width; ii++)

            {

                for (int jj = 0; jj < img.Height; jj++)

                {



                    if (ii - 1 >= 0 && jj - 1 >= 0)

                    {

                        c = img.GetPixel(ii - 1, jj - 1);

                        mask[0] = Convert.ToInt16(c.R);

                    }

                    else

                    {

                        mask[0] = 0;

                    }



                    if (jj - 1 >= 0 && ii + 1 < img.Width)

                    {

                        c = img.GetPixel(ii + 1, jj - 1);

                        mask[1] = Convert.ToInt16(c.R);

                    }

                    else

                        mask[1] = 0;



                    if (jj - 1 >= 0)

                    {

                        c = img.GetPixel(ii, jj - 1);

                        mask[2] = Convert.ToInt16(c.R);

                    }

                    else

                        mask[2] = 0;



                    if (ii + 1 < img.Width)

                    {

                        c = img.GetPixel(ii + 1, jj);

                        mask[3] = Convert.ToInt16(c.R);

                    }

                    else

                        mask[3] = 0;



                    if (ii - 1 >= 0)

                    {

                        c = img.GetPixel(ii - 1, jj);

                        mask[4] = Convert.ToInt16(c.R);

                    }

                    else

                        mask[4] = 0;



                    if (ii - 1 >= 0 && jj + 1 < img.Height)

                    {

                        c = img.GetPixel(ii - 1, jj + 1);

                        mask[5] = Convert.ToInt16(c.R);

                    }

                    else

                        mask[5] = 0;



                    if (jj + 1 < img.Height)

                    {

                        c = img.GetPixel(ii, jj + 1);

                        mask[6] = Convert.ToInt16(c.R);

                    }

                    else

                        mask[6] = 0;





                    if (ii + 1 < img.Width && jj + 1 < img.Height)

                    {

                        c = img.GetPixel(ii + 1, jj + 1);

                        mask[7] = Convert.ToInt16(c.R);

                    }

                    else

                        mask[7] = 0;

                    c = img.GetPixel(ii, jj);

                    mask[8] = Convert.ToInt16(c.R);



                    int sum = 0;

                    for (int u = 0; u < 9; u++)

                        sum = sum + mask[u];

                    sum = sum / 9;

                    img.SetPixel(ii, jj, Color.FromArgb(sum, sum, sum));

                }

            }

            pictureBox1.Image = img;

            MessageBox.Show("successfully Done");

        }
    }
    }
    


        



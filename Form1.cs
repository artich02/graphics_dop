using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab_graph
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        //private Image chest;
        private Image chest1;
        //private Image coin;
        private Image coin1;
        private Image coin2;
        private Image coin3;

        public Form1()
        {
            InitializeComponent();
            
            chest1 = Properties.Resources.chest1; 
            
            coin1 = Properties.Resources.coin1;
            coin2 = Properties.Resources.coin2;
            coin3 = Properties.Resources.coin3;
            pictureBox1.Image = chest1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.chest1;
        }

        private void fillButton_Click(object sender, EventArgs e)
        {
            
            FillChestWithCoins();
            
            pictureBox1.Invalidate();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearChest(); 
            pictureBox1.Invalidate();
            chest1 = Properties.Resources.chest1;
            pictureBox1.Image = chest1;
            pictureBox1.Invalidate();
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void SaveImage()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|BMP Image|*.bmp";
                saveFileDialog.Title = "Save an Image File";
                saveFileDialog.FileName = "ChestWithCoins";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Image saved successfully!");
                }
            }
        }

        private void FillChestWithCoins()
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);

            int coinCount = random.Next(900,1000); 
            Image coinImage1 = Properties.Resources.coin1;
            Image coinImage2 = Properties.Resources.coin2;
            Image coinImage3 = Properties.Resources.coin3;

            // Размещаем случайное количество монет в сундуке
            for (int i = 0; i < coinCount; i++)
            {
                int x = random.Next(65, 277);
                int y = random.Next(168, 279);

                if (x > 95 && x < 247 && y > 188 && y < 259)
                { 

                    int coin_1or2 = random.Next(0, 6);
                    if (coin_1or2 == 1 || coin_1or2 == 2)
                    {
                        g.DrawImage(coinImage1, new Rectangle(x, y, 38, 35));
                    }
                    else if (coin_1or2 == 3 || coin_1or2 == 4)
                    {
                        g.DrawImage(coinImage2, new Rectangle(x, y, 28, 28));
                    }
                    //else
                    //{
                    //    g.DrawImage(coinImage3, new Rectangle(x, y, 28, 28));
                    //}
                }
                else
                {
                    int coin_1or2 = random.Next(0, 6);
                    if (coin_1or2 == 1 || coin_1or2 == 2)
                    {
                        g.DrawImage(coinImage1, new Rectangle(x, y, 25, 28));
                    }
                    else if (coin_1or2 == 3 || coin_1or2 == 4)
                    {
                        g.DrawImage(coinImage2, new Rectangle(x, y , 15, 15));
                    }
                    else
                    {
                        g.DrawImage(coinImage3, new Rectangle(x, y + 5, 15, 15));
                    }

                }
            }

        }

        private void ClearChest()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
       
            }          
        }   
        
    }
}
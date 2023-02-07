using System;
using System.Windows.Forms;

namespace FrogWindowsForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
            if (EndGame())
            {
                if (Convert.ToInt32(scoreLabel.Text) == 24)
                {
                    MessageBox.Show("Победа!");
                }
                else
                {
                    var result = MessageBox.Show("Можно лучше. Хотите попробовать еще раз?", "Конец игры.", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                }

            }
        }
        private void Swap (PictureBox clicledPicture)
        {
            var distance = Math.Abs(clicledPicture.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;
            if (distance > 2)
            {
                MessageBox.Show("Так нельзя прыгать!");
            }
            else
            {
                var location = clicledPicture.Location;
                clicledPicture.Location = emptyPictureBox.Location;
                emptyPictureBox.Location = location;
                scoreLabel.Text = (Convert.ToInt32(scoreLabel.Text)+1).ToString();
            }
        }
        private bool EndGame()
        {
            var startLocation = 324;
            if (leftPictureBox1.Location.X > emptyPictureBox.Location.X &&
                leftPictureBox2.Location.X > emptyPictureBox.Location.X &&
                leftPictureBox3.Location.X > emptyPictureBox.Location.X &&
                leftPictureBox4.Location.X > emptyPictureBox.Location.X &&
                emptyPictureBox.Location.X == startLocation)
            {
                leftPictureBox1.Enabled = false;
                leftPictureBox2.Enabled = false;
                leftPictureBox3.Enabled = false;
                leftPictureBox4.Enabled = false;

                rightPictureBox1.Enabled = false;
                rightPictureBox2.Enabled = false;
                rightPictureBox3.Enabled = false;
                rightPictureBox4.Enabled = false;

                return true;   
            }
            return false;
        }
    }
}

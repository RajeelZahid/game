using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Racing_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int score, speed, hs, hs1, hs2, hs3, hs4, hs5, b3 = 0;
        string car_color;
        List<int> hss = new List<int>();

        //declaring array to store objects
        PictureBox[] road = new PictureBox[8];
        public void Form1_Load(object sender, EventArgs e)
        {
            //pictureBox9.ImageLocation = @"Files\\blu.png";

            speed = 1;
            score = 0;
            //form size
            this.Width = 240;
            this.Height = 400;

            this.Text = "Car Race";

            //disabling maximize / minimize box
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            panel1.BackColor = Color.Black;
            panel2.BackColor = Color.Black;
            panel3.BackColor = Color.Black;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //MinimumSize.Width = 240;
            //MinimumSize.Height = 240;

            //gameover label
            this.label1.BackColor = Color.White;
            this.label1.ForeColor = Color.Red;
            this.label1.Text = "Game Over";
            this.label1.Visible = false;
            this.label1.Font = new Font(label1.Font.FontFamily, 16, FontStyle.Bold);

            //score label1
            this.label2.Text = "Score: 0";
            this.label2.ForeColor = Color.White;
            this.label2.Font = new Font(label2.Font.FontFamily, 10, FontStyle.Bold);

            //speed label
            this.label4.Text = "Level: 1";
            this.label4.ForeColor = Color.Black;
            this.label4.Font = new Font(label4.Font.FontFamily, 10, FontStyle.Bold);

            //HighScore label
            this.label5.ForeColor = Color.Crimson;
            this.label5.Font = new Font(label5.Font.FontFamily, 10, FontStyle.Bold | FontStyle.Underline);

            //HighScores label
            label11.Text = "HighScores";
            panel5.BackColor = Color.White;
            panel7.BackColor = Color.Black;
            this.label11.Font = new Font(label11.Font.FontFamily, 12, FontStyle.Bold | FontStyle.Underline | FontStyle.Italic);
            this.label6.Font = new Font(label6.Font.FontFamily, 8, FontStyle.Bold);
            this.label7.Font = new Font(label7.Font.FontFamily, 8, FontStyle.Bold);
            this.label8.Font = new Font(label8.Font.FontFamily, 8, FontStyle.Bold);
            this.label9.Font = new Font(label9.Font.FontFamily, 8, FontStyle.Bold);
            this.label10.Font = new Font(label10.Font.FontFamily, 8, FontStyle.Bold);

            //about label
            this.label3.Text = "Modified By: M.Rajeel";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.label3.Font = new Font("Times", 10, FontStyle.Bold);
            this.label3.ForeColor = Color.Black;
            this.label3.Visible = false;

            //replay button
            this.button1.Text = "Replay";
            this.button1.ForeColor = Color.White;
            this.button1.BackColor = Color.DarkBlue;
            this.button1.Visible = false;
            this.button1.Font = new Font(button1.Font.FontFamily, 10);

            //Quit game button
            this.button2.Text = "Quit Game";
            this.button2.ForeColor = Color.White;
            this.button2.BackColor = Color.Red;
            this.button2.Visible = false;
            this.button2.Font = new Font(button2.Font.FontFamily, 10);

            //HghScore button
            this.button3.Text = "Show" + Environment.NewLine + "HighScores";
            this.button3.ForeColor = Color.White;
            this.button3.BackColor = Color.DarkGreen;
            this.button3.Visible = false;
            this.button3.Font = new Font(button3.Font.FontFamily, 7);
            this.button3.Location = new Point(152, 298);

            //ChangeCarColor button
            this.button4.Text = "Change" + Environment.NewLine + "Car Color";
            this.button4.ForeColor = Color.White;
            this.button4.BackColor = Color.Green;
            this.button4.Visible = false;
            this.button4.Font = new Font(button3.Font.FontFamily, 7);
            this.button4.Location = new Point(3, 298);

            //this.Blue.Font = new Font("Modern No. 20", 10);
            //this.Green.Font = new Font("Modern No. 20", 10);
            //this.Red.Font = new Font("Modern No. 20", 10);
            //this.Yellow.Font = new Font("Modern No. 20", 10);

            panel4.BackColor = Color.Black;
            Red.ForeColor = Color.White;
            Blue.ForeColor = Color.White;
            Green.ForeColor = Color.White;
            Yellow.ForeColor = Color.White;
            Red.BackColor = Color.Black;
            Blue.BackColor = Color.Black;
            Green.BackColor = Color.Black;
            Yellow.BackColor = Color.Black;

            //color
            this.BackColor = Color.DarkGray;
            this.pictureBox1.BackColor = Color.White;
            this.pictureBox2.BackColor = Color.White;
            this.pictureBox3.BackColor = Color.White;
            this.pictureBox4.BackColor = Color.White;
            this.pictureBox5.BackColor = Color.White;
            this.pictureBox6.BackColor = Color.White;
            this.pictureBox7.BackColor = Color.White;
            this.pictureBox8.BackColor = Color.White;

            //road timer
            this.timer1.Interval = 10;
            this.timer1.Enabled = true;

            //rightkey press timer
            this.timer2.Interval = 10;
            this.timer2.Enabled = false;

            //left key press timer
            this.timer3.Interval = 10;
            this.timer3.Enabled = false;

            //enemy car 1 timer
            this.car2_mover.Interval = 10;
            this.car2_mover.Enabled = true;

            //enemy car 2 timer
            this.car3_mover.Interval = 10;
            this.car3_mover.Enabled = true;

            //enemy car 3 timer
            this.car4_mover.Interval = 10;
            this.car4_mover.Enabled = true;

            this.AcceptButton = button1;
            this.CancelButton = button2;
            //assigning roadstraps into array
            road[0] = pictureBox1;
            road[1] = pictureBox2;
            road[2] = pictureBox3;
            road[3] = pictureBox4;
            road[4] = pictureBox5;
            road[5] = pictureBox6;
            road[6] = pictureBox7;
            road[7] = pictureBox8;

            StreamReader sr_hs = new StreamReader(@"Files\\1.txt");
            hs = int.Parse(sr_hs.ReadToEnd());
            label5.Text = "HS: " + hs;
            sr_hs.Close();

            hss.Clear();

            StreamReader sr_hs1 = new StreamReader(@"Files\\1.txt");
            hs1 = int.Parse(sr_hs1.ReadToEnd());
            sr_hs1.Close();

            StreamReader sr_hs2 = new StreamReader(@"Files\\2.txt");
            hs2 = int.Parse(sr_hs2.ReadToEnd());
            sr_hs2.Close();

            StreamReader sr_hs3 = new StreamReader(@"Files\\3.txt");
            hs3 = int.Parse(sr_hs3.ReadToEnd());
            sr_hs3.Close();

            StreamReader sr_hs4 = new StreamReader(@"Files\\4.txt");
            hs4 = int.Parse(sr_hs4.ReadToEnd());
            sr_hs4.Close();

            StreamReader sr_hs5 = new StreamReader(@"Files\\5.txt");
            hs5 = int.Parse(sr_hs5.ReadToEnd());
            sr_hs5.Close();

            hss.Add(hs1);
            hss.Add(hs2);
            hss.Add(hs3);
            hss.Add(hs4);
            hss.Add(hs5);

            hss.Sort();

            hs5 = hss[0];
            hs4 = hss[1];
            hs2 = hss[3];
            hs1 = hss[4];

            hss[0] = hs1;
            hss[1] = hs2;
            hss[3] = hs4;
            hss[4] = hs5;

            label6.Text = "1st :" + Environment.NewLine + "    " + hss[0];
            label7.Text = "2nd :" + Environment.NewLine + "    " + hss[1];
            label8.Text = "3rd :" + Environment.NewLine + "    " + hss[2];
            label9.Text = "4th :" + Environment.NewLine + "    " + hss[3];
            label10.Text = "5th :" + Environment.NewLine + "    " + hss[4];

            Blue.Text = "Blue";
            Green.Text = "Green";
            Red.Text = "Red";
            Yellow.Text = "Yellow";

            StreamReader sr_car_color = new StreamReader(@"Files\\carcolor.txt");
            car_color = sr_car_color.ReadToEnd();
            sr_car_color.Close();
            
            if (car_color == "blue")
            {
                Blue.Checked = true;
                pictureBox9.ImageLocation = @"Files\\blu.png";
            }
            else if (car_color == "green")
            {
                Green.Checked = true;
                pictureBox9.ImageLocation = @"Files\\gre.png";
            }
            else if (car_color == "red")
            {
                Red.Checked = true;
                pictureBox9.ImageLocation = @"Files\\red.png";
            }
            else if (car_color == "yellow")
            {
                Yellow.Checked = true;
                pictureBox9.ImageLocation = @"Files\\yel.png";
            }

        }

        //moving road
        private void timer1_Tick(object sender, EventArgs e)
        {

            for (int x = 0; x <= 7; x++)
            {
                road[x].Top += speed;

                //for repating road movement
                if (road[x].Top >= this.Height)
                {
                    road[x].Top = -road[x].Height;
                }

            }
            if (pictureBox9.Bounds.IntersectsWith(pictureBox10.Bounds))
            {
                pictureBox10.ImageLocation = @"Files\\fire.png";
                gameover();
            }
            if (pictureBox9.Bounds.IntersectsWith(pictureBox11.Bounds))
            {
                pictureBox11.ImageLocation = @"Files\\fire.png";
                gameover();
            }
            if (pictureBox9.Bounds.IntersectsWith(pictureBox12.Bounds))
            {
                pictureBox12.ImageLocation = @"Files\\fire.png";
                gameover();
            }

            //increasing speed
            if (score > 3)
            {
                speed = 2;
                this.pictureBox10.Size = new System.Drawing.Size(22, 42);
                this.pictureBox11.Size = new System.Drawing.Size(22, 42);
                this.pictureBox12.Size = new System.Drawing.Size(22, 42);
                this.label4.Text = "Level: 2";
                label4.ForeColor = Color.Maroon;
            }
            if (score > 15)
            {
                speed = 3;
                this.pictureBox10.Size = new System.Drawing.Size(24, 44);
                this.pictureBox11.Size = new System.Drawing.Size(24, 44);
                this.pictureBox12.Size = new System.Drawing.Size(24, 44);
                this.label4.Text = "Level: 3";
                label4.ForeColor = Color.SaddleBrown;
            }
            if (score > 35)
            {
                speed = 3;
                this.pictureBox10.Size = new System.Drawing.Size(27, 47);
                this.pictureBox11.Size = new System.Drawing.Size(27, 47);
                this.pictureBox12.Size = new System.Drawing.Size(27, 47);
                this.label4.Text = "Level: 4";
                label4.ForeColor = Color.Olive;
            }
            if (score > 60)
            {
                speed = 3;
                this.pictureBox10.Size = new Size(30, 50);
                this.pictureBox11.Size = new Size(30, 50);
                this.pictureBox12.Size = new Size(30, 50);
                this.label4.Text = "Level: 5";
                label4.ForeColor = Color.MidnightBlue;
            }

            if (score >= hss[0])
            {
                label5.Text = "HS: " + score;
                label3.Visible = true;
                label3.Text = "This is the Highest Score!!!";
            }

            else if (score >= hss[1])
            {
                label3.Visible = true;
                label3.Text = "This is the 2nd Highest Score!!!";
            }

            else if (score >= hss[2])
            {
                label3.Visible = true;
                label3.Text = "This is the 3rd Highest Score!!!";
            }

            else if (score >= hss[3])
            {
                label3.Visible = true;
                label3.Text = "This is the 4th Highest Score!!!";
            }

            else if (score >= hss[4] && score != 0)
            {
                label3.Visible = true;
                label3.Text = "This is the 5th Highest Score!!!";
            }
        }

        private void highscoreFunc()
        {
            label6.Text = "1st :" + Environment.NewLine + "    " + hss[0];
            label7.Text = "2nd :" + Environment.NewLine + "    " + hss[1];
            label8.Text = "3rd :" + Environment.NewLine + "    " + hss[2];
            label9.Text = "4th :" + Environment.NewLine + "    " + hss[3];
            label10.Text = "5th :" + Environment.NewLine + "    " + hss[4];
            StreamWriter sw_hs1 = new StreamWriter(@"Files\\1.txt");
            sw_hs1.Write(hss[0]);
            sw_hs1.Close();
            StreamWriter sw_hs2 = new StreamWriter(@"Files\\2.txt");
            sw_hs2.Write(hss[1]);
            sw_hs2.Close();
            StreamWriter sw_hs3 = new StreamWriter(@"Files\\3.txt");
            sw_hs3.Write(hss[2]);
            sw_hs3.Close();
            StreamWriter sw_hs4 = new StreamWriter(@"Files\\4.txt");
            sw_hs4.Write(hss[3]);
            sw_hs4.Close();
            StreamWriter sw_hs5 = new StreamWriter(@"Files\\5.txt");
            sw_hs5.Write(hss[4]);
            sw_hs5.Close();
            hss.Remove(5);
        }
        private void gameover()
        {
            this.label1.Visible = true;
            this.button1.Visible = true;
            this.button2.Visible = true;
            this.button3.Visible = true;
            this.button4.Visible = true;
            this.timer1.Stop();
            this.label3.Visible = true;

            this.label2.ForeColor = Color.Yellow;

            Blue.Visible = true;
            Green.Visible = true;
            Red.Visible = true;
            Yellow.Visible = true;

            this.car2_mover.Stop();
            this.car3_mover.Stop();
            this.car4_mover.Stop();

            if (hs < score)
            {
                StreamWriter sw = new StreamWriter(@"Files\\1.txt");
                sw.Write(score);
                label5.Text = "HS: " + score.ToString();
                sw.Close();
            }

            if (score > hss[0])
            {
                hss.Insert(0, score);
                highscoreFunc();
            }

            else if (score > hss[1])
            {
                hss.Insert(1, score);
                highscoreFunc();
            }

            else if (score > hss[2])
            {
                hss.Insert(2, score);
                highscoreFunc();
            }

            else if (score > hss[3])
            {
                hss.Insert(3, score);
                highscoreFunc();
            }

            else if (score > hss[4])
            {
                hss.Insert(4, score);
                highscoreFunc();
            }


            pictureBox9.ImageLocation = @"Files\\fire.png";

        }

        private void increseSpeed()
        {
            score += 1;
            label2.Text = "Score: " + score;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            //starting timer when user press right key
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                timer2.Start();
            }

            //starting timer when user press left key
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)

            {
                timer3.Start();
            }

        }

        //moving player car to right on timer start
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pictureBox9.Location.X < 182)
                pictureBox9.Left += 5;
        }

        //moving player car to left on timer start
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (pictureBox9.Location.X > 5)
                pictureBox9.Left -= 5;

        }

        private void green_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"Files\\carcolor.txt");
            sw.Write("green");
            sw.Close();
            pictureBox9.ImageLocation = @"Files\\gre.png";
        }

        private void Blue_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"Files\\carcolor.txt");
            sw.Write("blue");
            sw.Close();
            pictureBox9.ImageLocation = @"Files\\blu.png";
        }

        private void Red_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"Files\\carcolor.txt");
            sw.Write("red");
            sw.Close();
            pictureBox9.ImageLocation = @"Files\\red.png";
        }

        private void Yellow_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"Files\\carcolor.txt");
            sw.Write("yellow");
            sw.Close();
            pictureBox9.ImageLocation = @"Files\\yel.png";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Size = new Size(240, 450);
            b3 = 0;
            this.button3.Location = new Point(152, 298);
            this.button3.Text = "Show" + Environment.NewLine + "HighScores";
        }

        //stoping timer when user release right/left key
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
        }


        public Random r = new Random();

        private void button3_Click(object sender, EventArgs e)
        {
            if (b3 == 0)
            {
                this.Width = 400;
                this.Height = 400;
                this.button3.Location = new Point(225, 298);
                this.button3.Text = "Hide" + Environment.NewLine + "HighScores";
                b3 = 1;
            }
            else if (b3 == 1)
            {
                this.Width = 240;
                this.Height = 400;
                this.button3.Location = new Point(152, 298);
                this.button3.Text = "Show" + Environment.NewLine + "HighScores";
                b3 = 0;
            }
        }

        //moving enemy car 1
        private void car2_mover_Tick(object sender, EventArgs e)
        {
            pictureBox10.Top += speed * 3 / 2;

            //repeting when car cross the form (YELLOW CAR)
            if (pictureBox10.Top >= this.Height)
            {
                //    int x = r.Next(0, 240);
                //  int y = r.Next(0, 400);


                //increasing score when enemy car crosses the form every time , with the help on funtion
                increseSpeed();
                //moving car on random position 
                pictureBox10.Location = new Point((int)(new Random().Next(3, 60)), -100);


                //pictureBox10.Top = -(y + pictureBox10.Height) * -1;
                //pictureBox10.Left = -(x * 240) + pictureBox10.Height;
                // pictureBox10.Top = -(new Random().Next(0,150)+pictureBox10.Height);
                //pictureBox10.Left = -(new Random().Next(0, 240));
                //pictureBox10.Top = ((int.Parse(Math.Ceiling(Random(1,240)) + pictureBox10.Height)* -1);
            }
        }

        //moving enemy car 2 (RED CAR)
        private void car3_mover_Tick(object sender, EventArgs e)
        {
            pictureBox11.Top += speed * 5 / 3;


            //repeting when car cross the form
            if (pictureBox11.Top >= this.Height)
            {
                increseSpeed();
                pictureBox11.Location = new Point((int)(new Random().Next(63, 127)), -100);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Blue.Visible = false;
            Green.Visible = false;
            Red.Visible = false;
            Yellow.Visible = false;

            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"Files\\carcolor.txt");
            sw.Write("blue");
            sw.Close();
            Application.Exit();
        }

        //moving enemy car 3 (green car)
        private void car4_mover_Tick(object sender, EventArgs e)
        {
            pictureBox12.Top += speed * 3 / 2;

            //repeting when car cross the form
            if (pictureBox12.Top >= this.Height)
            {
                //increseSpeed();
                pictureBox12.Location = new Point((int)(new Random().Next(130, 190)), -100);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace square_chaser
{
    public partial class squareChaser : Form
    {

        Random rand = new Random();


        Rectangle player1 = new Rectangle(0, 0, 15, 15);
        Rectangle player2 = new Rectangle(385, 385, 15, 15);
        Rectangle ball = new Rectangle(200, 200, 12, 12);

        Rectangle speed;
        Rectangle obstacle;
        //Rectangle obstacle1;
        //Rectangle obstacle2;
        //Rectangle obstacle3;
        //Rectangle obstacle4;
        //Rectangle obstacle5;
        //Rectangle obstacle6;
        //Rectangle obstacle7;
        
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

        SoundPlayer Ding = new SoundPlayer(Properties.Resources.Ding);
        SoundPlayer Error = new SoundPlayer(Properties.Resources.Error);
        SoundPlayer Car = new SoundPlayer(Properties.Resources.Car);

        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        int player1Speed = 4;
        int player2Speed = 4;
        int ballXSpeed = 0;
        int ballYSpeed = 0;

        int timerTick = 0;
        int currentTime;

        int player1Score = 0;
        int player2Score = 0;

        int powerUpTime1 = 150;
        int powerUpTime2 = 150;
        bool powerUp1 = false;
        bool powerUp2 = false;

        public squareChaser()
        {
            InitializeComponent();
            int Randx = rand.Next(8, 392);
            int Randy = rand.Next(8, 392);
            int Rand1 = rand.Next(8, 392);
            int Rand2 = rand.Next(8, 392);
            obstacle = new Rectangle(Randx, Randy, 12, 12);
            speed = new Rectangle(Rand1, Rand2, 12, 12);

            //obstacle1 = new Rectangle(Randx, Randy, 12, 12);
            //obstacle2 = new Rectangle(Randx, Randy, 12, 12);
            //obstacle3 = new Rectangle(Randx, Randy, 12, 12);
            //obstacle4 = new Rectangle(Randx, Randy, 12, 12);
            //obstacle5 = new Rectangle(Randx, Randy, 12, 12);
            //obstacle6 = new Rectangle(Randx, Randy, 12, 12);
            //obstacle7 = new Rectangle(Randx, Randy, 12, 12);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if(powerUp1 == true)
            {
                powerUpTime1--;
            }
            if (powerUp2 == true)
            {
                powerUpTime2--;
            }
            //            ball.X += ballXSpeed;
            //            ball.Y += ballYSpeed;
            scoreLabel.Text = $"{player1Score}  |  {player2Score}";


            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height - 1)
            {
                player1.Y += player1Speed;
            }

            if (aDown == true && player1.X > 0)
            {
                player1.X -= player1Speed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width - 1)
            {
                player1.X += player1Speed;
            }


            if (upArrowDown == true && player2.Y > 0 + 2)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }

            if (leftArrowDown == true && player2.X > 0 + 2)
            {
                player2.X -= player2Speed;
            }

            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += player2Speed;
            }

            //ball collision with player
            if (player1.IntersectsWith(ball))
            {
                Ding.Play();
                player1Score++;
                int randY = rand.Next(8, 392);
                int randX = rand.Next(8, 392);

                ball.Size = new Size(0, 0);
                Refresh(); 

                //Thread.Sleep(2000);
                ball.Location = new Point(randX, randY);
                ball.Size = new Size(12, 12);
            }
            else if (player2.IntersectsWith(ball))
            {
                Ding.Play();
                player2Score++;
                int randY = rand.Next(10, 392);
                int randX = rand.Next(10, 392);

                ball.Size = new Size(0, 0);
                Refresh();

                //dsThread.Sleep(2000);
                ball.Location = new Point(randX, randY);
                ball.Size = new Size(12, 12);
            }
            if (player1.IntersectsWith(obstacle))
            {
                Error.Play();
                player1Score--;
                int randY = rand.Next(8, 392);
                int randX = rand.Next(8, 392);

                obstacle.Size = new Size(0, 0);
                Refresh();

                //Thread.Sleep(2000);
                obstacle.Location = new Point(randX, randY);
                obstacle.Size = new Size(12, 12);
            }
            else if (player2.IntersectsWith(obstacle))
            {
                Error.Play();
                player2Score--;
                int randY = rand.Next(10, 392);
                int randX = rand.Next(10, 392);

                obstacle.Size = new Size(0, 0);
                Refresh();

                //dsThread.Sleep(2000);
                obstacle.Location = new Point(randX, randY);
                obstacle.Size = new Size(12, 12);
            }

            //if (currentTime < timerTick + 150)
            //{
            //    player1Speed = 7;
            //}
            //else
            //{
            //    player1Speed = 4;
            //}

            if (player1.IntersectsWith(speed))
            {
                Car.Play();
                powerUpTime1 = 150;
                powerUp1 = true;
                //currentTime = timerTick;
                player1Speed = 7;

                int randY = rand.Next(8, 392);
                int randX = rand.Next(8, 392);

                speed.Size = new Size(0, 0);

                Refresh();

                //Thread.Sleep(2000);
                speed.Location = new Point(randX, randY);
                speed.Size = new Size(12, 12);
            }
            else if (player2.IntersectsWith(speed))
            {
                Car.Play();

                powerUpTime2 = 150;
                powerUp2 = true;
                player2Speed = 7;
                int randY = rand.Next(8, 392);
                int randX = rand.Next(8, 392);

                speed.Size = new Size(0, 0);
                Refresh();

                //Thread.Sleep(2000);
                speed.Location = new Point(randX, randY);
                speed.Size = new Size(12, 12);
            }
            if(powerUpTime1 == 0)
            {
                powerUp1 = false;
                player1Speed = 4;
            }
            if (powerUpTime2 == 0)
            {
                powerUp2 = false;
                player2Speed = 4;
            }

            if (player1Score == 5)
            {
                ball.Location = new Point(200, 200);
                ball.Size = new Size(12, 12);
                scoreLabel.Text = "Blue Wins!";
                player1Score = 0;
                player1.Location = new Point(0, 0);
                player2Score = 0;
                player2.Location = new Point(385, 385); 
                Refresh();
                Thread.Sleep(1000);
                scoreLabel.Text = "3";
                Refresh();
                Thread.Sleep(1000);
                scoreLabel.Text = "2";
                Refresh();
                Thread.Sleep(1000);
                scoreLabel.Text = "1";
                Refresh();
                Thread.Sleep(1000);
                scoreLabel.Text = "GO!";
            }
            else if(player2Score == 5)
            {
                ball.Location = new Point(200, 200);
                ball.Size = new Size(12, 12);
                scoreLabel.Text = "Green Wins!";
                player2Score = 0;
                player2.Location = new Point(385, 385);
                player1Score = 0;
                player1.Location = new Point(0, 0);
                Refresh();
                Thread.Sleep(1000);
                scoreLabel.Text = "3";
                Refresh();
                Thread.Sleep(1000);
                scoreLabel.Text = "2";
                Refresh();
                Thread.Sleep(1000);
                scoreLabel.Text = "1";
                Refresh();
                Thread.Sleep(1000);
                scoreLabel.Text = "GO!";
            }
            Refresh();
        }

        private void squareChaser_Paint(object sender, PaintEventArgs e)
        {
                e.Graphics.FillRectangle(blueBrush, player1);
                e.Graphics.FillRectangle(greenBrush, player2);
                e.Graphics.FillRectangle(whiteBrush, ball);
                e.Graphics.FillRectangle(redBrush, obstacle);
                e.Graphics.FillRectangle(yellowBrush, speed);
            ////e.Graphics.FillRectangle(redBrush, obstacle1);
            ////e.Graphics.FillRectangle(redBrush, obstacle2);
            ////e.Graphics.FillRectangle(redBrush, obstacle3);
            ////e.Graphics.FillRectangle(redBrush, obstacle4);
            ////e.Graphics.FillRectangle(redBrush, obstacle5);
            ////e.Graphics.FillRectangle(redBrush, obstacle6);
            ////e.Graphics.FillRectangle(redBrush, obstacle7);
        }

        private void squareChaser_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void squareChaser_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }


    }
}

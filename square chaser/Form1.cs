using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace square_chaser
{
    public partial class squareChaser : Form
    {

        Random rand = new Random();


        Rectangle player1 = new Rectangle(0, 0, 15, 15);
        Rectangle player2 = new Rectangle(385, 385, 15, 15);
        Rectangle ball = new Rectangle(200, 200, 8, 8);
        Rectangle obstacle1;
        Rectangle obstacle2;
        Rectangle obstacle3;
        Rectangle obstacle4;
        Rectangle obstacle5;
        Rectangle obstacle6;
        Rectangle obstacle7;
        
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush greenBrush = new SolidBrush(Color.Green);

        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        int playerSpeed = 4;
        int ballXSpeed = 0;
        int ballYSpeed = 0;

        int player1Score = 0;
        int player2Score = 0;

        public squareChaser()
        {
            InitializeComponent();
            int Randx = rand.Next(8, 392);
            int Randy = rand.Next(8, 392);

            obstacle1 = new Rectangle(Randx, Randy, 12, 12);
            obstacle2 = new Rectangle(Randx, Randy, 12, 12);
            obstacle3 = new Rectangle(Randx, Randy, 12, 12);
            obstacle4 = new Rectangle(Randx, Randy, 12, 12);
            obstacle5 = new Rectangle(Randx, Randy, 12, 12);
            obstacle6 = new Rectangle(Randx, Randy, 12, 12);
            obstacle7 = new Rectangle(Randx, Randy, 12, 12);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
       
//            ball.X += ballXSpeed;
//            ball.Y += ballYSpeed;
            scoreLabel.Text = $"{player1Score}  |  {player2Score}";


            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height - 1)
            {
                player1.Y += playerSpeed;
            }

            if (aDown == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width - 1)
            {
                player1.X += playerSpeed;
            }


            if (upArrowDown == true && player2.Y > 0 + 2)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            if (leftArrowDown == true && player2.X > 0 + 2)
            {
                player2.X -= playerSpeed;
            }

            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += playerSpeed;
            }

            //ball collision with player
            if (player1.IntersectsWith(ball))
            {
                player1Score++;
                int randY = rand.Next(8, 392);
                int randX = rand.Next(8, 392);

                ball.Size = new Size(0, 0);
                Refresh(); 

                //Thread.Sleep(2000);
                ball.Location = new Point(randX, randY);
                ball.Size = new Size(8, 8);
            }
            else if (player2.IntersectsWith(ball))
            {
                player2Score++;
                int randY = rand.Next(10, 392);
                int randX = rand.Next(10, 392);

                ball.Size = new Size(0, 0);
                Refresh();

                //dsThread.Sleep(2000);
                ball.Location = new Point(randX, randY);
                ball.Size = new Size(8, 8);
            }

            if(player1Score == 5)
            {
                ball.Location = new Point(200, 200);
                ball.Size = new Size(8, 8);
                scoreLabel.Text = "Blue Wins!";
            }
            else if(player2Score == 5)
            {
                ball.Location = new Point(200, 200);
                ball.Size = new Size(8, 8);
                scoreLabel.Text = "Red Wins!";
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
            Refresh();
        }

        private void squareChaser_Paint(object sender, PaintEventArgs e)
        {
                e.Graphics.FillRectangle(blueBrush, player1);
                e.Graphics.FillRectangle(greenBrush, player2);
                e.Graphics.FillRectangle(whiteBrush, ball);
                e.Graphics.FillRectangle(redBrush, obstacle1);
                e.Graphics.FillRectangle(redBrush, obstacle2);
                e.Graphics.FillRectangle(redBrush, obstacle3);
                e.Graphics.FillRectangle(redBrush, obstacle4);
                e.Graphics.FillRectangle(redBrush, obstacle5);
                e.Graphics.FillRectangle(redBrush, obstacle6);
                e.Graphics.FillRectangle(redBrush, obstacle7);
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

using System;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLUSTER
{
    public partial class Bluster : Form
    {
        WindowsMediaPlayer Backgroundsound = new WindowsMediaPlayer();
        WindowsMediaPlayer Shoot = new WindowsMediaPlayer();
        WindowsMediaPlayer Blustsound = new WindowsMediaPlayer();



        PictureBox[] Star;   //array for the moving starts at the back ground
        PictureBox[] Bullet; //arrray for bullet picture
        PictureBox[] Enemies;
        PictureBox[] Enemiesbullet;
        





        bool pause;
        bool gameover;
        int Backgroundspeed;            //fo the speed of background movment
        int mothershipspeed=6;          //for the movement of mothership
        int Bulletspeed;                 //for bulllet speed 
        int Enemyspeed;                 //for speed of enemy
        int Enemybulletspeed;       //for the bullet speed of enemy
        int Score;          //for the score
        int Level;     //for the level
        int hard;    //for the diffucuilty by level
        string tress;
       
    
        Random rand;

       



        public Bluster(string a)
        {
            InitializeComponent();
            this.tress = a;
            
        }
        
        private void Bluster_Load(object sender, EventArgs e)
        {
            //inatial value settings of verables
            Score = 0;
            Level = 1;
            pause = false;
            gameover = false;
            mothershipspeed = 6;
            hard = 9;
            Backgroundspeed = 6;
            Star = new PictureBox[10];
            rand = new Random();
            
            //setting the bullet
            Bulletspeed = 20;
            Bullet = new PictureBox[3];
            Image bullet = Image.FromFile("asserts\\bullet.png");
            Image star1 = Image.FromFile("asserts\\star2.png");

           
            //Load all songs
            Backgroundsound.URL = "songs\\GameSong.mp3";
            Shoot.URL = "songs\\shoot.mp3";
           Blustsound.URL = "songs\\boom.mp3";

           //Setup Songs settings
           Backgroundsound.settings.setMode("loop", true);
           Backgroundsound.settings.volume = 1;
           Shoot.settings.volume = 3;
           Blustsound.settings.volume = 5;


            //for setting image of bullet
            for (int i = 0; i < Bullet.Length; i++)
            {
                Bullet[i] = new PictureBox();
                Bullet[i].Size = new Size(8, 8);
                Bullet[i].Image = bullet;
                Bullet[i].SizeMode = PictureBoxSizeMode.Zoom;
                Bullet[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(Bullet[i]);
            }

            //forsetting  star picture 
            for (int i = 0; i < Star.Length; i++)
            {
                
                Star[i] = new PictureBox();
                Star[i].BorderStyle = BorderStyle.None;
                Star[i].Location = new Point(rand.Next(20, 580), rand.Next(-10, 400));
                if (i<4)
                {
                    Star[i].Size = new Size(1, 1);
                    Star[i].BackColor = Color.Wheat;
                    
                }
                else if(i>=4 && i<7)
                {
                    Star[i].Size = new Size(2, 2);
                    Star[i].BackColor = Color.DarkGray;
                }
                else
                {
                    Star[i].Size = new Size(3, 3);
                    Star[i].BackColor = Color.DarkGray;
                    Star[i].Image = star1;
                }
                this.Controls.Add(Star[i]);
            }


            //set everything for the enemies
            Enemyspeed = 4;
            //loading pictures for the enemies
            Image enemi1 = Image.FromFile("asserts\\E1.png");
            Image enemi2 = Image.FromFile("asserts\\E2.png");
            Image enemi3 = Image.FromFile("asserts\\E3.png");
            Image boss1 = Image.FromFile("asserts\\Boss1.png");
            Image boss2 = Image.FromFile("asserts\\Boss2.png");

            Enemies = new PictureBox[10];//creating array of enemies

            //inatialiazing the enemy picture boxes

            for (int i = 0; i < Enemies.Length; i++)
            {
                Enemies[i] = new PictureBox();
                Enemies[i].Size = new Size(40, 40);
                Enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                Enemies[i].BorderStyle = BorderStyle.None;
                Enemies[i].Visible = false;
                this.Controls.Add(Enemies[i]);
                Enemies[i].Location = new Point((i + 1) * 50, -50);
            }

            //implementing the pictures inside the array

            Enemies[0].Image = boss1;
            Enemies[1].Image = enemi2;
            Enemies[2].Image = enemi3;
            Enemies[3].Image = enemi3;
            Enemies[4].Image = enemi1;
            Enemies[5].Image = enemi3;
            Enemies[6].Image = enemi2;
            Enemies[7].Image = enemi3;
            Enemies[8].Image = enemi2;
            Enemies[9].Image = boss2;


            //enemies bullet
            Enemiesbullet = new PictureBox[10];
            Enemybulletspeed = 4;
                 
            for (int i = 0; i < Enemiesbullet.Length; i++)
            {
                Enemiesbullet[i] = new PictureBox();
                Enemiesbullet[i].Size = new Size(2, 25);
                Enemiesbullet[i].Visible = false;
                Enemiesbullet[i].BackColor = Color.Yellow;
                int x = rand.Next(0, 10);
                Enemiesbullet[i].Location = new Point(Enemies[x].Location.X, Enemies[x].Location.Y - 20);
                this.Controls.Add(Enemiesbullet[i]);
            }

            //Initialise enemy bullet PictureBoxes
            for (int i = 0; i < Bullet.Length; i++)
            {
                Bullet[i] = new PictureBox();
                Bullet[i].Size = new Size(8, 8);
                Bullet[i].Image = bullet;
                Bullet[i].SizeMode = PictureBoxSizeMode.Zoom;
                Bullet[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(Bullet[i]);
            }
            Backgroundsound.controls.play();


        }


        //for moving the background
        private void movebabckgroundtimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Star.Length / 3; i++)
            {
                Star[i].Top += Backgroundspeed;
                if (Star[i].Top >= this.Height)
                {
                    Star[i].Top = -Star[i].Height;
                }
            }

            for (int i = (Star.Length / 2)+1; i < Star.Length; i++)
            {
                Star[i].Top += Backgroundspeed - 4;
                if (Star[i].Top >= this.Height)
                {
                    Star[i].Top = -Star[i].Height;
                }
            }

            for (int i = (Star.Length/3)+1; i < (Star.Length / 2) + 2; i++)
            {
                Star[i].Top += Backgroundspeed -2;
                if (Star[i].Top >= this.Height)
                {
                    Star[i].Top = -Star[i].Height;
                }
            }


        }




        private void mothership_Click(object sender, EventArgs e)
        {

        }

        private void Bluster_KeyUp(object sender, KeyEventArgs e)
        {


        }
        
        //for events(tsak by pressing keys)
        private void Bluster_KeyDown(object sender, KeyEventArgs e)
        {
            if (!gameover)
            {
                if (e.KeyCode == Keys.Space )//for space
                {
                    pause = !pause;
                    if (!pause)
                    {
                        label1.Visible = false;
                        movebabckgroundtimer.Start();
                        moveenemies.Start();
                        movbullettimer.Start();
                        Enemybulletspeedtimer.Start();
                        Backgroundsound.controls.play();
                    }
                    if (pause)
                    {
                        label1.Visible = true;
                        label1.Text = "paused";
                        movebabckgroundtimer.Stop();
                        moveenemies.Stop();
                        movbullettimer.Stop();
                        Enemybulletspeedtimer.Stop();
                        Backgroundsound.controls.stop();
                    }
                    

                }

                //for movement

                if (!pause)
                {


                    if (e.KeyCode == Keys.Up || e.KeyCode==Keys.W)//key up or W
                    {
                        if (mothership.Top > 10)
                        {
                            mothership.Top -= mothershipspeed;
                        }
                    }

                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)//down or s
                    {
                        if (mothership.Top <400)
                        {

                            mothership.Top += mothershipspeed;

                        }
                    }

                    if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)//left or a
                    {
                        if (mothership.Left >10)
                        {

                            mothership.Left -= mothershipspeed;

                        }
                    }

                    if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)//right or d
                    {
                        if (mothership.Left < 530)
                        {

                            mothership.Left += mothershipspeed;

                        }
                    }

                }
            }
        }

        private void Bluster_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

  
        
          
        //Enemi Vertical Move Method
        private void MoveEnemiesVertical(PictureBox[] enemis, int speed)
        {
            for (int i = 0; i < enemis.Length; i++)
            {
                enemis[i].Visible = true;
                enemis[i].Top += speed;

                if (enemis[i].Top > this.Height)
                {
                    Enemies[i].Location = new Point((i + 1) * 50, -200);
                }
            }
        }



        private void movbullettimer_Tick(object sender, EventArgs e)//for the movement of bullet timer its calles the bullet mobement function every 20ms
        {
            Shoot.controls.play();
            

            for (int i = 0; i < Bullet.Length; i++)
            {
                if (Bullet[i].Top > 0)
                {
                    Bullet[i].Visible = true;
                    Bullet[i].Top -= Bulletspeed;

                    Collision();
                }
                else
                {
                    Bullet[i].Visible = false;
                    Bullet[i].Location = new Point(mothership.Location.X + 20, mothership.Location.Y - i * 30);
                }
            }
        }

        private void moveenemies_Tick(object sender, EventArgs e)
        {
            MoveEnemiesVertical(Enemies, Enemyspeed);
        }//timer for enemy movement in every 100ms


        //collution with the mother ship and the enemy bullet
        private void Collisionwithenemybullet()
        {
            for (int i = 0; i < Enemiesbullet.Length; i++)
            {
                if (Enemiesbullet[i].Bounds.IntersectsWith(mothership.Bounds))
                {
                    Blustsound.settings.volume = 30;
                    Blustsound.controls.play();
                    
                    Enemiesbullet[i].Visible = false;
                    mothership.Visible = false;
                    GameOver("Game Over");
                    
                }
            }
        }

        //for detacting collution
        private void Collision()
        {
            for (int i = 0; i < Enemies.Length; i++)
            {
                if (Bullet[0].Bounds.IntersectsWith(Enemies[i].Bounds) || Bullet[1].Bounds.IntersectsWith(Enemies[i].Bounds) || Bullet[2].Bounds.IntersectsWith(Enemies[i].Bounds))
                {
                    Blustsound.controls.play();
                    Score += 1;
                    
                    label2.Text = "Score: " + Score;
                    label3.Text = "Level" + Level;
                    if (Score % 30 == 0)
                    {
                        Level += 1;

                        label3.Text = "Level" + Level;

                        if (Enemyspeed <= 10 && Enemybulletspeed <= 10 && hard >= 0)
                        {
                            hard--;
                            Enemyspeed++;
                            Enemybulletspeed++;
                        }

                        if (Level == 10)
                        {
                            GameOver("NICE DONE");
                        }
                    }
                    Enemies[i].Location = new Point((i + 1) * 50, -100);
                }
                if (mothership.Bounds.IntersectsWith(Enemies[i].Bounds))
                {
                    Blustsound.settings.volume = 30;
                    Blustsound.controls.play();
                    mothership.Visible = false;
                    GameOver("GAME OVER");
                }
            }
        }


        private void DBconnection()
        {
            MySqlCommand command;
            MySqlDataReader mdr;
            string ConnectString = "datasource = localhost; username = root; password=; database = bluster";
            MySqlConnection DBconnect = new MySqlConnection(ConnectString);
            DBconnect.Open();
            string checkString = "SELECT * FROM `info` WHERE username = '"+ tress +"';";
            MySqlCommand command1 = new MySqlCommand(checkString, DBconnect);
            MySqlDataReader mdr1 = command1.ExecuteReader();
            if (mdr1.Read())
            { 
                string a = (mdr1["score"].ToString());
                DBconnect.Close();
                int b = int.Parse(a);
                if (this.Score > b)
                {
                    try
                    {
                        DBconnect.Open();
                        string updateScore = "UPDATE `info` SET `score`= '" + Score + "' WHERE `username` = '" + tress + "';";
                        command = new MySqlCommand(updateScore, DBconnect);
                        mdr = command.ExecuteReader();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Your Score Is " + Score);
                }
            }
            DBconnect.Close();
        }

        private void GameOver(String str)
        {
            Backgroundsound.controls.stop();
            
            label1.Text = str.Trim();
            label1.Visible = true;
            gameover = true;
            pause = true;
            button2.Text = "Replay";
            button2.Visible = true;
            button1.Visible = true;
            StopTimers();
        }

       

        //for stop all the timers
        private void StopTimers()
        {
            movebabckgroundtimer.Stop();
            moveenemies.Stop();
            movbullettimer.Stop();
            Enemybulletspeedtimer.Stop();
        }

        private void Enemybulletspeedtimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < (Enemiesbullet.Length - hard); i++)
            {
                if (Enemiesbullet[i].Top < this.Height)
                {
                    Enemiesbullet[i].Visible = true;
                    Enemiesbullet[i].Top += Enemybulletspeed;
                    Collisionwithenemybullet();
                }
                else
                {
                    Enemiesbullet[i].Visible = false;
                    int x = rand.Next(0, 10);
                    Enemiesbullet[i].Location = new Point(Enemies[x].Location.X + 20, Enemies[x].Location.Y + 30);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBconnection();
            this.Controls.Clear();
            InitializeComponent();
            Bluster_Load(e,e);
            
        }
          
        private void button1_Click(object sender, EventArgs e)
        {
            DBconnection();
            this.Hide();
            MainFrom mainform = new MainFrom(tress);
            mainform.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

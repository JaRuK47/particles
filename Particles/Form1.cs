using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Particles
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        //GravityPoint point1;
        //GravityPoint point2;

        ReflectorPoint reflector1;
        ReflectorPoint reflector2;
        ReflectorPoint reflectorMouse;

        TeleportPoint teleportEntrance;
        TeleportPoint teleportExit;

        RadarPoint radar;

        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);


            this.emitter = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter);

            reflector1 = new ReflectorPoint
            {
                X = picDisplay.Width / 3,
                Y = picDisplay.Height / 2,
                Radius = 60
            };

            reflector2 = new ReflectorPoint
            {
                X = 2 * picDisplay.Width / 3,
                Y = picDisplay.Height / 2,
                Radius = 60
            };

            reflectorMouse = new ReflectorPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
                Radius = 45
            };

            emitter.impactPoints.Add(reflector1);
            emitter.impactPoints.Add(reflector2);
            emitter.impactPoints.Add(reflectorMouse);

            teleportEntrance = new TeleportPoint
            {
                X = picDisplay.Width / 2 - 150,
                Y = picDisplay.Height / 2,
                Radius = 50,
                IsEntrance = true
            };

            teleportExit = new TeleportPoint
            {
                ExitX = picDisplay.Width / 2 + 150,
                ExitY = picDisplay.Height / 2,
                IsEntrance = false,
                ExitDirection = 0,
                ExitSpeedMultiplier = 1.0f
            };

            teleportEntrance.ExitX = teleportExit.ExitX;
            teleportEntrance.ExitY = teleportExit.ExitY;
            teleportEntrance.ExitDirection = teleportExit.ExitDirection;
            teleportEntrance.ExitSpeedMultiplier = teleportExit.ExitSpeedMultiplier;

            emitter.impactPoints.Add(teleportEntrance);
            emitter.impactPoints.Add(teleportExit);

            radar = new RadarPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2 + 100,
                Radius = 70
            };

            emitter.impactPoints.Add(radar);

            //point1 = new GravityPoint
            //{
            //    X = picDisplay.Width / 2 + 100,
            //    Y = picDisplay.Height / 2,
            //};
            //point2 = new GravityPoint
            //{
            //    X = picDisplay.Width / 2 - 100,
            //    Y = picDisplay.Height / 2,
            //};

            //emitter.impactPoints.Add(point1);
            //emitter.impactPoints.Add(point2);

            //emitter = new TopEmitter
            //{
            //    Width = picDisplay.Width,
            //    GravitationY = 0.25f
            //};

            //emitter.impactPoints.Add(new GravityPoint
            //{
            //    X = (float)(picDisplay.Width * 0.25),
            //    Y = picDisplay.Height / 2
            //});

            //emitter.impactPoints.Add(new AntiGravityPoint
            //{
            //    X = (float)(picDisplay.Width / 2 * 0.75),
            //    Y = picDisplay.Height / 2
            //});

            //emitter.impactPoints.Add(new GravityPoint
            //{
            //    X = (float)(picDisplay.Width * 0.75),
            //    Y = picDisplay.Height / 2
            //});
        }

        private void DrawTeleportConnection(Graphics g)
        {
            using (var pen = new Pen(Color.FromArgb(100, Color.Magenta), 2))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawLine(pen, teleportEntrance.X, teleportEntrance.Y,
                          teleportExit.ExitX, teleportExit.ExitY);
            }
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            reflectorMouse.X = e.X;
            reflectorMouse.Y = e.Y;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
                DrawTeleportConnection(g);
            }
            picDisplay.Invalidate();
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            teleportExit.ExitDirection = tbDirection.Value;
            teleportEntrance.ExitDirection = tbDirection.Value;
            lblDirection.Text = $"Нап: {tbDirection.Value}°";
        }

        private void tbSpreading_Scroll(object sender, EventArgs e)
        {
            float multiplier = tbSpreading.Value / 100f;
            teleportExit.ExitSpeedMultiplier = multiplier;
            teleportEntrance.ExitSpeedMultiplier = multiplier;
            lblSpreading.Text = $"Мн: {multiplier:F2}x";
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            //point2.Power = tbGraviton1.Value;
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            //point1.Power = tbGraviton2.Value;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta > 0 ? 5 : -5; 
            reflectorMouse.Radius = Math.Max(20, Math.Min(150, reflectorMouse.Radius + delta));
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Левой кнопкой - перемещаем вход телепорта
                teleportEntrance.X = e.X;
                teleportEntrance.Y = e.Y;
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Правой кнопкой - перемещаем выход телепорта
                teleportExit.ExitX = e.X;
                teleportExit.ExitY = e.Y;
                teleportEntrance.ExitX = e.X;
                teleportEntrance.ExitY = e.Y;
            }
        }
    }
}

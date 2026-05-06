using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;

        public abstract void ImpactParticle(Particle particle);

        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }

    public class GravityPoint : IImpactPoint
    {
        public int Power = 100;

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius < Power / 2) // если частица оказалось внутри окружности
            {
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }
        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );

            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            var text = $"Я гравитон\nc силой {Power}";
            var font = new Font("Verdana", 10);

            var size = g.MeasureString(text, font);

            g.FillRectangle(
                new SolidBrush(Color.Red),
                X - size.Width / 2,
                Y - size.Height / 2,
                size.Width,
                size.Height
            );

            g.DrawString(
                text,
                font,
                new SolidBrush(Color.White),
                X,
                Y,
                stringFormat
            );
        }
    }

    public class AntiGravityPoint : IImpactPoint
    {
        public int Power = 100;

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX -= gX * Power / r2; 
            particle.SpeedY -= gY * Power / r2;
        }
    }

    public class ReflectorPoint : IImpactPoint
    {
        public int Radius = 50; 
        public int Power = 10; 

        public override void ImpactParticle(Particle particle)
        {
            float dx = particle.X - X;
            float dy = particle.Y - Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance + particle.Radius < Radius)
            {
                float nx = dx / distance;
                float ny = dy / distance;

                float targetDistance = Radius - particle.Radius - 1;
                particle.X = X + nx * targetDistance;
                particle.Y = Y + ny * targetDistance;

                particle.SpeedX += nx * Power;
                particle.SpeedY += ny * Power;
            }
            else if (Math.Abs(distance + particle.Radius - Radius) < 5)
            {
                float nx = dx / distance;
                float ny = dy / distance;

                float vx = particle.SpeedX;
                float vy = particle.SpeedY;
                float dot = vx * nx + vy * ny;

                if (dot < 0) 
                {
                    particle.SpeedX = vx - 2 * dot * nx;
                    particle.SpeedY = vy - 2 * dot * ny;
                }
            }
        }

        public override void Render(Graphics g)
        {
            using (var pen = new Pen(Color.Cyan, 2))
            using (var fillBrush = new SolidBrush(Color.FromArgb(50, Color.Cyan)))
            {
                g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);
                g.FillEllipse(fillBrush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }

    public class TeleportPoint : IImpactPoint
    {
        public int Radius = 50; 
        public float ExitX; 
        public float ExitY; 
        public float ExitDirection = 0; 
        public float ExitSpeedMultiplier = 1.0f; 
        public bool IsEntrance = true; 

        public override void ImpactParticle(Particle particle)
        {
            if (!IsEntrance) return; 

 
            float dx = particle.X - X;
            float dy = particle.Y - Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            
            if (distance + particle.Radius < Radius)
            {
                
                particle.X = ExitX;
                particle.Y = ExitY;

                
                if (ExitDirection != 0 || ExitSpeedMultiplier != 1.0f)
                {
                    float currentSpeed = (float)Math.Sqrt(particle.SpeedX * particle.SpeedX + particle.SpeedY * particle.SpeedY);

         
                    float radian = ExitDirection * (float)Math.PI / 180;
                    particle.SpeedX = (float)Math.Cos(radian) * currentSpeed * ExitSpeedMultiplier;
                    particle.SpeedY = -(float)Math.Sin(radian) * currentSpeed * ExitSpeedMultiplier;
                }
            }
        }

        public override void Render(Graphics g)
        {
            if (IsEntrance)
            {
                
                using (var pen = new Pen(Color.Red, 2))
                using (var fillBrush = new SolidBrush(Color.FromArgb(80, Color.Red)))
                {
                    g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);
                    g.FillEllipse(fillBrush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
                }
            }
            else
            {
                using (var pen = new Pen(Color.Green, 2))
                using (var fillBrush = new SolidBrush(Color.FromArgb(80, Color.Green)))
                {
                    g.DrawEllipse(pen, ExitX - 30, ExitY - 30, 60, 60);
                    g.FillEllipse(fillBrush, ExitX - 30, ExitY - 30, 60, 60);
                }

                DrawDirectionArrow(g);
            }
        }

        private void DrawDirectionArrow(Graphics g)
        {
            if (ExitDirection == 0) return;

            float radian = ExitDirection * (float)Math.PI / 180;
            float arrowLength = 40;
            float arrowX = ExitX + (float)Math.Cos(radian) * arrowLength;
            float arrowY = ExitY - (float)Math.Sin(radian) * arrowLength;

            using (var pen = new Pen(Color.Yellow, 3))
            {
                g.DrawLine(pen, ExitX, ExitY, arrowX, arrowY);

                float angle = (float)Math.PI / 6;
                float arrowSize = 10;

                float arrowX1 = arrowX - (float)Math.Cos(radian - angle) * arrowSize;
                float arrowY1 = arrowY + (float)Math.Sin(radian - angle) * arrowSize;
                float arrowX2 = arrowX - (float)Math.Cos(radian + angle) * arrowSize;
                float arrowY2 = arrowY + (float)Math.Sin(radian + angle) * arrowSize;

                g.DrawLine(pen, arrowX, arrowY, arrowX1, arrowY1);
                g.DrawLine(pen, arrowX, arrowY, arrowX2, arrowY2);
            }
        }
    }

    public class RadarPoint : IImpactPoint
    {
        public int Radius = 80;
        private int particlesCount = 0;

        public override void ImpactParticle(Particle particle)
        {
            float dx = particle.X - X;
            float dy = particle.Y - Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance + particle.Radius < Radius)
            {
                particlesCount++;
                particle.IsInRadar = true;
            }
            else
            {
                particle.IsInRadar = false;
            }
        }

        public void ResetCounter()
        {
            particlesCount = 0;
        }

        public override void Render(Graphics g)
        {
            using (var pen = new Pen(Color.Lime, 2))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }

            using (var fillBrush = new SolidBrush(Color.FromArgb(40, Color.Lime)))
            {
                g.FillEllipse(fillBrush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }

            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            string text = $"РАДАР\n{particlesCount} частиц";
            var font = new Font("Verdana", 10, FontStyle.Bold);
            var size = g.MeasureString(text, font);

            using (var bgBrush = new SolidBrush(Color.FromArgb(180, Color.Black)))
            using (var textBrush = new SolidBrush(Color.Lime))
            {
                g.FillRectangle(bgBrush,
                    X - size.Width / 2,
                    Y - size.Height / 2 - 15,
                    size.Width,
                    size.Height);

                g.DrawString(text, font, textBrush, X, Y - 15, stringFormat);
            }
        }
    }
}

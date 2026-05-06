using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles
{
    public class Emitter
    {
        public int ParticlesCount = 500;
        public int MaxParticles = 500;

        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        public float GravitationX = 0;
        public float GravitationY = 1;

        public List<Particle> particles = new List<Particle>();
        public int MousePositionX;
        public int MousePositionY;

        public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 80; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы

        public int ParticlesPerTick = 1;

        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black);

        public void UpdateState()
        {

            foreach (var point in impactPoints)
            {
                if (point is RadarPoint radar)
                {
                    radar.ResetCounter();
                }
            }

            int particlesToCreate = ParticlesPerTick;


            for (int i = 0; i < particles.Count; i++)
            {
                var particle = particles[i];

                if (particle.Life < 0)
                {

                    if (particlesToCreate > 0)
                    {
                        particlesToCreate--;
                        ResetParticle(particle);

                    }
                }
                else
                {

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                    particle.Life--;

                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                }
            }


            while (particlesToCreate > 0 && particles.Count < MaxParticles)
            {
                particlesToCreate--;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }

        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }

        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction
                + (double)Particle.rand.Next(Spreading)
                - Spreading / 2;

            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }

        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }
    }

    public class TopEmitter : Emitter
    {
        public int Width;

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);

            particle.X = Particle.rand.Next(Width); 
            particle.Y = 0;

            particle.SpeedY = 1;
            particle.SpeedX = Particle.rand.Next(-2, 2);
        }
    }
}

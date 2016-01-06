using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    abstract class SoundTankPlayer : DrivingTankPlayer
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        /// <param name="velocity">Скорость</param>
        /// <param name="direction">Направление движения</param>
        public SoundTankPlayer(Rectangle rect, int velocity, Direction direction, int velosityShel)
            : base(rect, velocity, direction, velosityShel)
        { }

        protected void PlaySound()
        {
            if (!isParking)
            {
                SoundGame.SoundMove();
            }
            else if (isParking)
            {
                SoundGame.SoundStop();
            }
        }
    }
}
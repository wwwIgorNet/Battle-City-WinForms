using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Управление танком противника
    /// </summary>
    [Serializable]
    abstract class DrivingTankEnemy : TankEnemy
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        /// <param name="velocity">Скорость</param>
        /// <param name="direction">Направление движения</param>
        public DrivingTankEnemy(Rectangle rect, int velocity, Direction direction, int velosityShel)
            : base(rect, velocity, direction, velosityShel)
        {
            i = random.Next(0, 50);
            j = random.Next(0, 100);
            isParking = false;
        }

        private static Random random = new Random();
        private int i = 0, j = 0;

        /// <summary>
        /// Генерация команд танку
        /// </summary>
        protected void Driving()
        {
            oldDirection = direction;
            if (i == 0)
            {
                i = random.Next(6, 50);
                newDirection = (Direction)random.Next(0, 4);
                Move();
            }
            else
            {
                i--;
                Move();
            }

            if (j == 0)
            {
                j = random.Next(0, 100);
                Fire(KeyObjGame.TankEnemy);
            }
            else
                j--;
        }
    }
}

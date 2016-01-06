using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    /// <summary>
    /// Управление танком Player
    /// </summary>
    [Serializable]
    abstract class DrivingTankPlayer : TankPlayer
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        /// <param name="velocity">Скорость</param>
        /// <param name="direction">Направление движения</param>
        public DrivingTankPlayer(Rectangle rect, int velocity, Direction direction, int velosityShel)
            : base(rect, velocity, direction, velosityShel)
        { }

        /// <summary>
        /// Управление танком Player (обработка нажатия клавиш)
        /// </summary>
        protected void Driving()
        {
            oldDirection = direction;
            if (Keyboard.Left)
            {
                newDirection = Direction.Left;
                isParking = false;
                Move();
            }
            else if (Keyboard.Right)
            {
                newDirection = Direction.Right;
                isParking = false;
                Move();
            }
            else if (Keyboard.Up)
            {
                newDirection = Direction.Up;
                isParking = false;
                Move();
            }
            else if (Keyboard.Down)
            {
                newDirection = Direction.Down;
                isParking = false;
                Move();
            }
            else
            {
                isParking = true;
                Move();
            }

            if (Keyboard.Space)
            {
                Fire(KeyObjGame.Player);
            }
        }
    }
}
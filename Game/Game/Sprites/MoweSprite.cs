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
    /// Движущийся обьект
    /// </summary>
    [Serializable]
    abstract class MoweSprite : Sprite
    {
        // Направление движения
        protected Direction direction;
        // Скорость
        protected int velocity;

        /// <summary>
        /// Констуктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        /// <param name="velocity">Скорость</param>
        /// <param name="direction">Направление движения</param>
        protected MoweSprite(Rectangle rect, int velocity, Direction direction)
            : base(rect)
        {
            this.velocity = velocity;
            this.direction = direction;
        }

        /// <summary>
        /// Передвижение обьекта
        /// </summary>
        protected virtual void Move()
        {
            switch (direction)
            {
                case Direction.Up:
                    spriteRectangle.Y -= velocity;
                    break;
                case Direction.Right:
                    spriteRectangle.X += velocity;
                    break;
                case Direction.Down:
                    spriteRectangle.Y += velocity;
                    break;
                case Direction.Left:
                    spriteRectangle.X -= velocity;
                    break;
            }
        }
    }
}

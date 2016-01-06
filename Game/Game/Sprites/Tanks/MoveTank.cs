using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Движение танка
    /// </summary>
    [Serializable]
    abstract class MoveTank : CollisionsSprite
    {
        // Состояния остановки
        protected bool isParking;
        // Cтарое направление движения
        protected Direction oldDirection;
        // Новое наравление движения
        protected Direction newDirection;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        /// <param name="velocity">Скорость</param>
        /// <param name="direction">Направление движения</param>
        public MoveTank(Rectangle rect, int velocity, Direction direction)
            : base(rect, velocity, direction)
        {
            this.isParking = true;
            newDirection = oldDirection = direction;
        }

        /// <summary>
        /// Движение танка
        /// </summary>
        protected override void Move()
        {
            // Если не стоит
            if (!this.isParking)
            {
                // Если старое напрвление не равно новому
                if (newDirection != oldDirection)
                {
                    // Смищение к границам тайла
                    if (offsetToBorderTile())
                        // Устанавливаем направление
                        direction = newDirection;
                }
                else
                    // Иначе базовое перемещение
                    base.Move();
            }
            else
                // Смищение к границам тайла
                offsetToBorderTile();
        }

        /// <summary>
        /// Смищение к границам тайла
        /// </summary>
        /// <returns>tru если координаты танка кратны 20(танк на границе тайла)</returns>
        private bool offsetToBorderTile()
        {
            int tmp = (int)(oldDirection - newDirection);
            if (tmp == 2 || tmp == -2)
            {
                direction = newDirection;
                return false;
            }


            if (direction == Direction.Left)
            {
                int offset = spriteRectangle.X % SizeGame.WidtchSmoll;
                if (offset == 0)
                    return true;

                if (offset >= velocity)
                    spriteRectangle.X -= velocity;
                else
                    spriteRectangle.X -= offset;
            }
            else if (direction == Direction.Up)
            {
                int offset = spriteRectangle.Y % SizeGame.HeighSmoll;
                if (offset == 0)
                    return true;

                if (offset >= velocity)
                    spriteRectangle.Y -= velocity;
                else
                    spriteRectangle.Y -= offset;
            }
            else if (direction == Direction.Right)
            {
                int offset = SizeGame.WidtchSmoll - spriteRectangle.X % SizeGame.WidtchSmoll;
                if (offset == SizeGame.WidtchSmoll)
                    return true;

                if (offset >= velocity)
                    spriteRectangle.X += velocity;
                else
                    spriteRectangle.X += offset;
            }
            else if (direction == Direction.Down)
            {
                int offset = SizeGame.HeighSmoll - spriteRectangle.Y % SizeGame.HeighSmoll;
                if (offset == SizeGame.HeighSmoll)
                    return true;

                if (offset >= velocity)
                    spriteRectangle.Y += velocity;
                else
                    spriteRectangle.Y += offset;
            }

            return false;
        }
    }
}

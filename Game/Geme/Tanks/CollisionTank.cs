using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Столкновение танка с обектами игры
    /// </summary>
    [Serializable]
    abstract class CollisionTank : MoveTank
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        /// <param name="velocity">Скорость</param>
        /// <param name="direction">Направление движения</param>
        public CollisionTank(Rectangle rect, int velocity, Direction direction)
            : base(rect, velocity, direction)
        { }

        /// <summary>
        /// Столкновение танка с обектами игры
        /// </summary>
        protected bool CollisionObjLevel()
        {
            foreach (var kv in Level.DictionaryObjGame)
            {
                // Исключаем с проверки Орел, снаряды
                if (kv.Key == KeyObjGame.Shell) continue;
                if (kv.Key == KeyObjGame.Ice) continue;
                if (kv.Key == KeyObjGame.Ohter) continue;
                foreach (var obj in kv.Value)
                {
                    // Исключаем с проверки если obj ссылается на себя
                    if (obj == this) continue;
                    if (obj is Eagle) continue;
                    if (spriteRectangle.IntersectsWith(obj.Rect))
                    {
                        // Смещение к границам обьекта
                        Offset(obj.Rect);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Смещение к границам обьекта
        /// </summary>
        /// <param name="rect">Прямоуголиник обекта</param>
        private void Offset(Rectangle rect)
        {
            if (!spriteRectangle.IntersectsWith(rect))
                return;
            switch (direction)
            {
                case Direction.Up:
                    spriteRectangle.Location = new Point(spriteRectangle.X, spriteRectangle.Y + 1);
                    break;
                case Direction.Right:
                    spriteRectangle.Location = new Point(spriteRectangle.X - 1, spriteRectangle.Y);
                    break;
                case Direction.Down:
                    spriteRectangle.Location = new Point(spriteRectangle.X, spriteRectangle.Y - 1);
                    break;
                case Direction.Left:
                    spriteRectangle.Location = new Point(spriteRectangle.X + 1, spriteRectangle.Y);
                    break;
            }
            Offset(rect);
        }
    }
}

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
    /// Детонация снаряда
    /// </summary>
    [Serializable]
    class DetonationShell : ObjGame
    {
        // Переменная для хранения интервала задержки между сменой действий
        protected int interval = 0;
        private Direction direction;
        private string path;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="position">Позицыя на карте</param>
        public DetonationShell(Point position, Direction direction)
            : base(new Rectangle(position.X, position.Y, 0, 0))
        {
            path = SettingsGame.Content + @"Images\Bullets\";
            this.direction = direction;
            // Установка картинки обекта
            this.spriteImage = Image.FromFile(path + "Detonation.png");
            Position();

            Level.DictionaryObjGame[KeyObjGame.Ohter].Add(this);
        }

        public override void Update()
        {
            if (interval == 2)
            {
                interval++;
                // Меняем изображения взрыва
                spriteImage = Image.FromFile(path + "Detonation2.png");
                // Вычисление положения обьекта
                Position();
            }
            else if (interval == 4)
            {
                interval++;
                // Меняем изображения взрыва
                spriteImage = Image.FromFile(path + "Detonation3.png");
                // Вычисление положения обьекта
                Position();
            }
            else if (interval == 6)
            {
                Level.DictionaryObjGame[KeyObjGame.Ohter].Remove(this);
            }
            else
                interval++;
        }

        /// <summary>
        /// Вычисление положения обьекта при смене изображения и размеров
        /// </summary>
        protected void Position()
        {
            switch (direction)
            {
                case Direction.Up:
                    spriteRectangle.Location = new Point(spriteRectangle.X - ((spriteImage.Width - spriteRectangle.Width) / 2), spriteRectangle.Top - (spriteImage.Height - spriteRectangle.Width) / 2);
                    break;
                case Direction.Right:
                    spriteRectangle.Location = new Point(spriteRectangle.Left - (spriteImage.Width - spriteRectangle.Width) / 2, spriteRectangle.Y - (spriteImage.Height / 2 - spriteRectangle.Height / 2));
                    break;
                case Direction.Down:
                    spriteRectangle.Location = new Point(spriteRectangle.X - (spriteImage.Width / 2 - spriteRectangle.Width / 2), spriteRectangle.Top - (spriteImage.Height - spriteRectangle.Width) / 2);
                    break;
                case Direction.Left:
                    spriteRectangle.Location = new Point(spriteRectangle.Left - (spriteImage.Width - spriteRectangle.Width) / 2, spriteRectangle.Y - (spriteImage.Height / 2 - spriteRectangle.Height / 2));
                    break;
            }
            spriteRectangle.Size = spriteImage.Size;
        }
    }
}

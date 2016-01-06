using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Вода
    /// </summary>
    [Serializable]
    class Water : ObjGame
    {
        private int delay;
        private int carentFrame;
        private Image[] images;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="position">Позицыя на карте</param>
        public Water(Point position)
            : base(new Rectangle(position.X, position.Y, SettingsGame.WidtchSmoll, SettingsGame.HeighSmoll))
        {
            // Установка картинки обекта
            string path = @"..\..\Resources\Content\Images\Immovable Obj\";
            images = new Image[] {
                                    Image.FromFile(path + "Water_1.png"),
                                    Image.FromFile(path + "Water_2.png") };

            delay = 0;
            carentFrame = 0;
            this.spriteImage = images[0];
        }

        /// <summary>
        /// Обновление состояния обьекта
        /// </summary>
        public override void Update()
        {
            if (delay == 0)
            {
                delay = 10;
                spriteImage = images[carentFrame];
                carentFrame = carentFrame == 0 ? 1 : 0;
            }
            else
                delay--;
        }
    }
}

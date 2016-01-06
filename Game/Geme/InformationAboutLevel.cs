using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// отображение уровня игры
    /// </summary>
    [Serializable]
    class InformationAboutLevel : InformationGame
    {
        private Image spriteImage2;
        private bool twoDigits;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        public InformationAboutLevel(int carentLevel, Point position)
            :base(new Rectangle(position.X, position.Y/*28 * SizeGame.WidtchSmoll, 23 * SizeGame.HeighSmoll*/, SettingsGame.WidtchSmoll, SettingsGame.HeighSmoll))
        {
            if (carentLevel / 10 > 0)
            {
                twoDigits = true;
                string path2 = @"..\..\Resources\Content\Images\Other\" + (carentLevel / 10).ToString() + ".png";
                this.spriteImage2 = Image.FromFile(path2);
            }

            string path = @"..\..\Resources\Content\Images\Other\" + (carentLevel % 10).ToString() + ".png";
            this.spriteImage = Image.FromFile(path);            
        }

        public override void Draw(Graphics g, Point offset)
        {
            if (twoDigits)
            {
                g.TranslateTransform(spriteRectangle.X + offset.X - SettingsGame.WidtchSmoll, spriteRectangle.Y + offset.Y);
                g.DrawImage(spriteImage2, 0, 0, spriteRectangle.Width, spriteRectangle.Height);
                g.ResetTransform();
            }
            base.Draw(g, offset);
        }
    }
}

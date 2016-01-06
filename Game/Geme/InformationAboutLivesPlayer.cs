using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// отобразение количества жизней игрока 
    /// </summary>
    [Serializable]
    class InformationAboutLivesPlayer : InformationGame
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        public InformationAboutLivesPlayer(int countLives)
            :base(new Rectangle(28 * SettingsGame.WidtchSmoll, 16 * SettingsGame.HeighSmoll, SettingsGame.WidtchSmoll, SettingsGame.HeighSmoll))
        {
            string path = @"..\..\Resources\Content\Images\Other\" + countLives.ToString() + ".png";
            this.spriteImage = Image.FromFile(path);
        }
    }
}

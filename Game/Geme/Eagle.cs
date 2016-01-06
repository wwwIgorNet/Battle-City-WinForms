using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Орел штаба playera
    /// </summary>
    [Serializable]
    class Eagle : ObjGame, IResponse
    {
        private bool isAlive;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="respawn">Позицыя на карте</param>
        public Eagle(Point respawn)
            : base(new Rectangle(respawn.X, respawn.Y, SettingsGame.WidtchBig, SettingsGame.HeighBig))
        {
            spriteImage = Properties.Resources.Eagle;
            isAlive = true;
        }

        /// <summary>
        /// Вызывается при попадании снаряда в обьект
        /// </summary>
        /// <param name="shellObj">Ссылка на снаряд</param>
        public void Response(ShellObj shellObj)
        {
            if (this.isAlive)
            {
                this.isAlive = false;
                // Устанавливаем картинку убитого орла
                spriteImage = Properties.Resources.Eagle2;
                shellObj.Detonation = true;
                new DetonationShellBig(shellObj.Rect.Location, shellObj.Direction, 0);
                // Миняем состояние Level
                Level.StateOfLevel = StateOfLevel.GameOver;
            }
        }
    }
}

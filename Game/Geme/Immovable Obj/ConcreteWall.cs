using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Бетонная стена
    /// </summary>
    [Serializable]
    class ConcreteWall : ObjGame, IResponse
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="position">Позицыя на карте</param>
        public ConcreteWall(Point position)
            : base(new Rectangle(position.X, position.Y, SettingsGame.WidtchSmoll, SettingsGame.HeighSmoll))
        {
            // Установка картинки обекта
            spriteImage = Properties.Resources.ConcreteWall;
        }
        
        public void Response(ShellObj shellObj)
        {
            shellObj.Detonation = true;
            if(shellObj.NameTank == KeyObjGame.Player) SoundGame.SoundDetonation();
        }
    }
}

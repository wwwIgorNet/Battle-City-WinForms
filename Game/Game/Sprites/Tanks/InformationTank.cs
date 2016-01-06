using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Танк для боковой панели
    /// </summary>
    [Serializable]
    class InformationTank : Sprite
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="position">Позицыя на екране</param>
        public InformationTank(Point position)
            : base(new Rectangle(position, Properties.Resources.information_tank.Size))
        {
            // Установка картинки обекта
            spriteImage = Properties.Resources.information_tank;
        }
    }
}

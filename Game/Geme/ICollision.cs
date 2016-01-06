using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface ICollision
    {
        /// <summary>
        /// Позицыыи на карте, ширины и высоты обьекта
        /// </summary>
        Rectangle Rect { get; }
    }
}

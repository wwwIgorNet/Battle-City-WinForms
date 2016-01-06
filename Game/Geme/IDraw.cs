using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IDraw
    {
        /// <summary>
        /// Рисует обьект игры
        /// </summary>
        /// <param name="g">Graphics екрана игры</param>
        /// <param name="offset">Смещение на екране</param>
        void Draw(Graphics g, Point offset);
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Интерфейс обекта игры
    /// </summary>
    interface IObjGame
    {
        /// <summary>
        /// Рисует обьект игры
        /// </summary>
        /// <param name="g">Graphics екрана игры</param>
        /// <param name="offset">Смещение на екране</param>
        void Draw(Graphics g, Point offset);
        /// <summary>
        /// Позицыыи на карте, ширины и высоты обьекта
        /// </summary>
        Rectangle Rect { get; }

        /// <summary>
        /// Обновление состояния обьекта
        /// </summary>
        void Update();

        /// <summary>
        /// Вызывается при попадании снаряда в обьект
        /// </summary>
        /// <param name="shellObj">Ссылка на снаряд</param>
        void Response(ShellObj shellObj);

    }
}

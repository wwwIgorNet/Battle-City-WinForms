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
    /// Базовый обект игры
    /// </summary>
    [Serializable]
    abstract class ObjGame : InformationGame, ICollision
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        protected ObjGame(Rectangle rect)
            : base(rect)
        { }

        /// <summary>
        /// Возвращает прямоугольник описывающий позицию обьекта на екране, ширину и высоту
        /// </summary>
        public Rectangle Rect { get { return spriteRectangle; } }
        
        /// <summary>
        /// Обновление состояния обьекта
        /// </summary>
        public virtual void Update()
        { }
    }
}

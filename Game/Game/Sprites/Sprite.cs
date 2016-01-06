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
    abstract class Sprite : IObjGame
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        protected Sprite(Rectangle rect)
        {
            spriteRectangle = rect;
        }
        // Картинка с изобрвжением обьекта
        protected Image spriteImage;
        // Прямоугольник описывающий позицию обьекта на екране, ширину и высоту
        protected Rectangle spriteRectangle;

        /// <summary>
        /// Возвращает прямоугольник описывающий позицию обьекта на екране, ширину и высоту
        /// </summary>
        public Rectangle Rect { get { return spriteRectangle; } }

        /// <summary>
        /// Обновление состояния обьекта
        /// </summary>
        public virtual void Update()
        { }

        /// <summary>
        /// Вызывается при попадании снаряда в обьект
        /// </summary>
        /// <param name="shellObj">Ссылка на снаряд</param>
        public virtual void Response(ShellObj shellObj)
        { }

        /// <summary>
        /// Рисует обьект игры
        /// </summary>
        /// <param name="g">Graphics екрана игры</param>
        /// <param name="offset">Смещение на екране</param>
        public virtual void Draw(Graphics g, Point offset)
        {
            g.TranslateTransform(spriteRectangle.X + offset.X, spriteRectangle.Y + offset.Y);
            g.DrawImage(spriteImage, 0, 0, spriteRectangle.Width, spriteRectangle.Height);
            g.ResetTransform();
        }
    }
}

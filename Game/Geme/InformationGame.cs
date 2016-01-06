using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    abstract class InformationGame : IDraw
    {
        // Картинка с изобрвжением обьекта
        protected Image spriteImage;
        // Прямоугольник описывающий позицию обьекта на екране, ширину и высоту
        protected Rectangle spriteRectangle;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        protected InformationGame(Rectangle rect)
        {
            spriteRectangle = rect;
        }

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

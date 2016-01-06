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
    /// Очки
    /// </summary>
    [Serializable]
    class Points : ObjGame
    {
        private int delay;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        public Points(Point position, int count)
            : base(new Rectangle(position.X, position.Y, 0, 0))
        {
            string path =  SettingsGame.Content + @"Images\Other\" + count.ToString() + ".png";
            this.spriteImage = Image.FromFile(path);

            spriteRectangle.Size = spriteImage.Size;

            Level.DictionaryObjGame[KeyObjGame.Ohter].Add(this);
            delay = 10;
        }

        public override void Update()
        {
            if (delay == 0) Level.DictionaryObjGame[KeyObjGame.Ohter].Remove(this);
            else delay--;
        }
    }
}

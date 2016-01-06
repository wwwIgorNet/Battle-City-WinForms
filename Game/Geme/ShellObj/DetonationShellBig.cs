using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Детонация снаряда
    /// </summary>
    [Serializable]
    class DetonationShellBig : DetonationShell
    {
        private int countPoints;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="position">Позицыя на карте</param>
        public DetonationShellBig(Point position, Direction direction, int countPoints)
            : base(position, direction)
        {
            this.countPoints = countPoints;
        }
        
        public override void Update()
        {
            if (interval == 1)
            {
                SoundGame.SoundBigDetonation();
                interval++;
                // Меняем изображения взрыва
                spriteImage = Properties.Resources.Detonation2;
                // Вычисление положения обьекта
                Position();
            }
            else if (interval == 2)
            {
                interval++;
                // Меняем изображения взрыва
                spriteImage = Properties.Resources.Detonation3;
                // Вычисление положения обьекта
                Position();
            }
            else if (interval == 6)
            {
                interval++;
                // Меняем изображения взрыва
                spriteImage = Properties.Resources.DetonationBig;
                // Вычисление положения обьекта
                Position();
            }
            else if (interval == 8)
            {
                interval++;
                // Меняем изображения взрыва
                spriteImage = Properties.Resources.DetonationBig2;
                // Вычисление положения обьекта
                Position();
            }
            else if (interval == 10)
            {
                Level.DictionaryObjGame[KeyObjGame.Ohter].Remove(this);
                if (countPoints != 0)
                    new Points(new Point(spriteRectangle.X + 21, spriteRectangle.Y + 29), countPoints);
            }
            else
                interval++;
        }
    }
}

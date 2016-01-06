using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Стриляющий танк
    /// </summary>
    [Serializable]
    abstract class FireTank : CollisionTank
    {
        // Ссылка на выпущеный снаряд
        protected ShellObj shell;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        /// <param name="velocity">Скорость</param>
        /// <param name="direction">Направление движения</param>
        protected FireTank(Rectangle rect, int velocity, Direction direction)
            : base(rect, velocity, direction)
        { }

        /// <summary>
        /// Стрильба
        /// </summary>
        /// <param name="nameTank">Имя типа танка</param>
        /// <param name="velocity">Скорость снаряда</param>
        protected void Fire(KeyObjGame nameTank, int velocity)
        {
            // Если пуля еще летит 
            if (shell == null || !shell.IsAlive)
            {
                // Создание снаряда в зависимости от направления танка
                switch (direction)
                {
                    case Direction.Up:
                        shell = new AnimationDetonationShell(new Rectangle(spriteRectangle.Left + (spriteRectangle.Width / 2 - SizeGame.WidtchShell / 2), spriteRectangle.Top - SizeGame.HeighShell, SizeGame.WidtchShell, SizeGame.HeighShell), velocity, this.direction, nameTank);
                        break;
                    case Direction.Right:
                        shell = new AnimationDetonationShell(new Rectangle(spriteRectangle.Right + 1, spriteRectangle.Top + (spriteRectangle.Height / 2 - SizeGame.HeighShell / 2), SizeGame.HeighShell, SizeGame.WidtchShell), velocity, this.direction, nameTank);
                        break;
                    case Direction.Down:
                        shell = new AnimationDetonationShell(new Rectangle(spriteRectangle.Left + (spriteRectangle.Width / 2 - SizeGame.WidtchShell / 2), spriteRectangle.Bottom, SizeGame.WidtchShell, SizeGame.HeighShell), velocity, this.direction, nameTank);
                        break;
                    case Direction.Left:
                        shell = new AnimationDetonationShell(new Rectangle(spriteRectangle.Left - SizeGame.WidtchShell, spriteRectangle.Top + (spriteRectangle.Height / 2 - SizeGame.HeighShell / 2), SizeGame.HeighShell, SizeGame.WidtchShell), velocity, this.direction, nameTank);
                        break;
                }
            }
        }
    }
}

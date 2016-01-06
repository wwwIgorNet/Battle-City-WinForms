using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Стриляющий танк
    /// </summary>
    [Serializable]
    abstract class FireTank : CollisionTank
    {
        // Скорость пули
        protected int velosityShel;
        // Ссылка на выпущеный снаряд
        protected ShellObj shell;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        /// <param name="velocity">Скорость</param>
        /// <param name="direction">Направление движения</param>
        protected FireTank(Rectangle rect, int velocity, Direction direction, int velosityShel)
            : base(rect, velocity, direction)
        {
            this.velosityShel = velosityShel;
        }
        
        /// <summary>
        /// Стрильба
        /// </summary>
        /// <param name="nameTank">Имя типа танка</param>
        /// <param name="velocity">Скорость снаряда</param>
        protected void Fire(KeyObjGame nameTank)
        {
            // Если пуля еще летит 
            if (shell == null || !shell.IsAlive)
            {
                if (nameTank == KeyObjGame.Player)
                {
                    SoundGame.SoundFire();
                }
                // Создание снаряда в зависимости от направления танка
                switch (direction)
                {
                    case Direction.Up:
                        shell = new CollisionShell(new Rectangle(spriteRectangle.Left + (spriteRectangle.Width / 2 - SettingsGame.WidtchShell / 2), spriteRectangle.Top - SettingsGame.HeighShell, SettingsGame.WidtchShell, SettingsGame.HeighShell), this.velosityShel, this.direction, nameTank);
                        break;
                    case Direction.Right:
                        shell = new CollisionShell(new Rectangle(spriteRectangle.Right + 1, spriteRectangle.Top + (spriteRectangle.Height / 2 - SettingsGame.HeighShell / 2), SettingsGame.HeighShell, SettingsGame.WidtchShell), this.velosityShel, this.direction, nameTank);
                        break;
                    case Direction.Down:
                        shell = new CollisionShell(new Rectangle(spriteRectangle.Left + (spriteRectangle.Width / 2 - SettingsGame.WidtchShell / 2), spriteRectangle.Bottom, SettingsGame.WidtchShell, SettingsGame.HeighShell), this.velosityShel, this.direction, nameTank);
                        break;
                    case Direction.Left:
                        shell = new CollisionShell(new Rectangle(spriteRectangle.Left - SettingsGame.WidtchShell, spriteRectangle.Top + (spriteRectangle.Height / 2 - SettingsGame.HeighShell / 2), SettingsGame.HeighShell, SettingsGame.WidtchShell), this.velosityShel, this.direction, nameTank);
                        break;
                }
            }
        }
    }
}

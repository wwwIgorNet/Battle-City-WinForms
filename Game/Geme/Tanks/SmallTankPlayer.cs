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
    /// Малый танк Player
    /// </summary>
    [Serializable]
    class SmallTankPlayer : SoundTankPlayer, IResponse
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="position">Положение на карте</param>
        /// <param name="direction">Направление</param>
        public SmallTankPlayer(Point position, Direction direction)
            : base(new Rectangle(position.X, position.Y, SettingsGame.WidtchBig, SettingsGame.HeighBig), 4, direction, 8)
        {
            moweLeft = new Image[] {
                Properties.Resources.SmallTankPlayerLeft_1,
                Properties.Resources.SmallTankPlayerLeft_2 };
            moweRight = new Image[] {
                Properties.Resources.SmallTankPlayerRight_1,
                Properties.Resources.SmallTankPlayerRight_2 };
            moweUp = new Image[] {
                Properties.Resources.SmallTankPlayerUp_1,
                Properties.Resources.SmallTankPlayerUp_2 };
            moweDown = new Image[] {
                Properties.Resources.SmallTankPlayerDown_1,
                Properties.Resources.SmallTankPlayerDown_2 };
            Animation();
        }

        /// <summary>
        /// Вызывается при попадании снаряда в обьект
        /// </summary>
        /// <param name="shellObj">Ссылка на снаряд</param>
        public void Response(ShellObj shellObj)
        {
            // Если снаряд выпущен не етим танком
            if (shellObj.NameTank == KeyObjGame.TankEnemy)
            {
                // Удаление со списка обектов игры
                Level.DictionaryObjGame[KeyObjGame.Player].Remove(this);//todo
                shellObj.Detonation = true;
                // Миняем статус Level на game over
                Level.StateOfLevel = StateOfLevel.GameOver;//todo
                new DetonationShellBig(shellObj.Rect.Location, shellObj.Direction, 0);
                SoundGame.Stop();
            }
        }

        /// <summary>
        /// Обновление состояния обьекта
        /// </summary>
        public override void Update()
        {
            this.Driving();
            if (!this.CollisionObjLevel())
                this.CollisionsBoundariesPlayingField();

            PlaySound();
            if (!isParking)
                Animation();
        }
    }
}

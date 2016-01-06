using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    class UpdateTankEnemy : DrivingTankEnemy, IResponse
    {
        // Количество очков
        private int countPoints;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        /// <param name="velocity">Скорость</param>
        /// <param name="direction">Направление движения</param>
        public UpdateTankEnemy(Rectangle rect, int velocity, Direction direction, int velosityShel, int countPoints)
            : base(rect, velocity, direction, velosityShel)
        {
            this.countPoints = countPoints;
        }

        /// <summary>
        /// Обновление состояния обьекта
        /// </summary>
        public override void Update()
        {
            this.Driving();
            if (!this.CollisionObjLevel())
                this.CollisionsBoundariesPlayingField();
            Animation();
        }

        /// <summary>
        /// Вызывается при попадании снаряда в обьект
        /// </summary>
        /// <param name="shellObj">Ссылка на снаряд</param>
        public virtual void Response(ShellObj shellObj)
        {
            // Если снаряд выпущен не етим танком
            if (shellObj.NameTank != KeyObjGame.TankEnemy)
            {
                // Удаление из списка обьектов игры
                Level.DictionaryObjGame[KeyObjGame.TankEnemy].Remove(this);
                shellObj.Detonation = true;
                new DetonationShellBig(shellObj.Rect.Location, shellObj.Direction, countPoints);
            }
        }
    }
}

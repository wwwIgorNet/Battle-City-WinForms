using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Базовый танк противника
    /// </summary>
    [Serializable]
    abstract class TankEnemy : AnimationTank, IAddTankToDictionary
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        /// <param name="velocity">Скорость</param>
        /// <param name="direction">Направление движения</param>
        public TankEnemy(Rectangle rect, int velocity, Direction direction, int velosityShel)
            : base(rect, velocity, direction, velosityShel)
        { }

        public void AddTankToDictionary()
        {
            Level.DictionaryObjGame[KeyObjGame.TankEnemy].Add(this);
        }
    }
}

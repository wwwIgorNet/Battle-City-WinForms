using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Клас для проверки столкновений снаряда
    /// </summary>
    [Serializable]
    abstract class CollisionShell : ShellObj
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        /// <param name="velocity">Скорость</param>
        /// <param name="direction">Направление движения</param>
        /// <param name="nameTank">Ссылка на танк которому пренадлежит снаряд</param>
        public CollisionShell(Rectangle rect, int velocity, Direction direction, KeyObjGame nameTank)
            : base(rect, velocity, direction, nameTank)
        { }

        /// <summary>
        /// Обновление состояния обьекта
        /// </summary>
        public override void Update()
        {
            // Передвижение
            this.Move();
            // Столкновение с границами карты 
            detonation = this.CollisionsBoundariesPlayingField();
            // Столкновение с обектами игры
            CollisionObjLevel();
        }

        // Ссылка на обьект с которым произошло столкновение
        protected IObjGame objResponse;

        /// <summary>
        /// Столкновение с обектами игры
        /// </summary>
        protected virtual void CollisionObjLevel()
        {
            foreach (var KeyValue in Level.DictionaryObjGame)
            {
                // Исключаем из проверки танки Playera если снаряд выпущеный ево танком
                if (KeyValue.Key == KeyObjGame.TankPlayer && this.nameTank == KeyObjGame.TankPlayer) continue;
                // Исключаем из проверки танки противника если снаряд выпущеный ево танком
                if (KeyValue.Key == KeyObjGame.TankEnemy && this.nameTank == KeyObjGame.TankEnemy) continue;
                // Исключаем из проверки танки для боковой информационной панели
                if (KeyValue.Key == KeyObjGame.InformationTank) continue;

                for (int i = 0; i < KeyValue.Value.Count; i++)
                {
                    // Исключаем из проверки картинку Game Over
                    if (KeyValue.Value[i] is ImgGameOver) continue;

                    // Проверка если обьект снаряд 
                    if (KeyValue.Value[i] is ShellObj)
                    {
                        ShellObj bj = (ShellObj)KeyValue.Value[i];
                        // Исключаем из проверки если пуля принадлежит томуже типу танков
                        if (bj.NameTank == this.nameTank) continue;
                    }
                    // Проверка столкновения
                    if (spriteRectangle.IntersectsWith(KeyValue.Value[i].Rect))
                    {
                        // Записуем ссылку на обьект с которым произошло столкновение 
                        objResponse = KeyValue.Value[i];
                        // Помичаем обьект как сдетонировавший
                        this.detonation = true;
                    }
                }
            }
        }

        /// <summary>
        /// Вызывается при попадании снаряда в обьект
        /// </summary>
        /// <param name="shellObj">Ссылка на снаряд</param>
        public override void Response(ShellObj sp)
        {
            // Помичаем обьект как умерший
            isAlive = false;
            // Удаляем из списка снарядов
            Level.DictionaryObjGame[KeyObjGame.ShellObj].Remove(this);
            // Помичаем обьект как умерший
            sp.IsAlive = false;
            // Удаляем из списка снарядов
            Level.DictionaryObjGame[KeyObjGame.ShellObj].Remove(sp);
        }
    }
}

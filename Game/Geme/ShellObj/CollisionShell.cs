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
    class CollisionShell : ShellObj, IResponse
    {
        private int delay;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rect">Прямоугольник описывающий позицию обьекта на екране, ширину и высоту</param>
        /// <param name="velocity">Скорость</param>
        /// <param name="direction">Направление движения</param>
        /// <param name="nameTank">Ссылка на танк которому пренадлежит снаряд</param>
        public CollisionShell(Rectangle rect, int velocity, Direction direction, KeyObjGame nameTank)
            : base(rect, velocity, direction, nameTank)
        {
            delay = 0;
        }

        /// <summary>
        /// Обновление состояния обьекта
        /// </summary>
        public override void Update()
        {
            if (!detonation)
            {
                // Передвижение
                this.Move();
                // Столкновение с границами карты 
                detonation = this.CollisionsBoundariesPlayingField();
                // Столкновение с обектами игры
                if (!detonation)
                    CollisionObjLevel();
                else if(this.nameTank == KeyObjGame.Player)
                    SoundGame.SoundDetonation();

            }
            // Если обьект сдетонировал
            else if (detonation && delay == 0)
            {
                new DetonationShell(spriteRectangle.Location, direction);
                delay++;
            }
            else if (delay == 7)
            {
                // Помичаем обьект как умерший
                isAlive = false;
                // Удаляем из списка снарядов
                Level.DictionaryObjGame[KeyObjGame.Shell].Remove(this);
            }
            else if (delay > 0)
                delay++;
        }

        /// <summary>
        /// Столкновение с обектами игры
        /// </summary>
        protected virtual void CollisionObjLevel()
        {
            foreach (var KeyValue in Level.DictionaryObjGame)
            {
                for (int i = 0; i < KeyValue.Value.Count; i++)
                {
                    // Проверка если обьект снаряд 
                    if (KeyValue.Value[i] is ShellObj)
                    {
                        ShellObj bj = (ShellObj)KeyValue.Value[i];
                        if (bj == this) continue;

                        //// Исключаем из проверки если пуля принадлежит томуже типу танков
                        if (bj.NameTank == this.nameTank) continue;
                    }

                    IResponse iResponse = KeyValue.Value[i] as IResponse;
                    if (iResponse != null)
                    {
                        // Проверка столкновения
                        if (spriteRectangle.IntersectsWith(KeyValue.Value[i].Rect))
                        {
                            // Записуем ссылку на обьект с которым произошло столкновение 
                            iResponse.Response(this);
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Вызывается при попадании снаряда в обьект
        /// </summary>
        /// <param name="shellObj">Ссылка на снаряд</param>
        public void Response(ShellObj sp)
        {
            if (isAlive)
            {
                // Помичаем обьект как умерший
                isAlive = false;
                // Удаляем из списка снарядов
                Level.DictionaryObjGame[KeyObjGame.Shell].Remove(this);
                // Помичаем обьект как умерший
                sp.IsAlive = false;
                // Удаляем из списка снарядов
                Level.DictionaryObjGame[KeyObjGame.Shell].Remove(sp);
            }
        }
    }
}

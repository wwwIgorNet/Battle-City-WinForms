﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Кирпичная стина
    /// </summary>
    [Serializable]
    class BrickWall : ObjGame, IResponse
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="position">Позицыя на карте</param>
        public BrickWall(Point position)
            : base(new Rectangle(position.X, position.Y, SettingsGame.WidtchSmoll, SettingsGame.HeighSmoll))
        {
            // Установка картинки обекта
            spriteImage = Properties.Resources.BrickWall;
        }

        /// <summary>
        /// Вызывается при попадании пули в обьект
        /// </summary>
        /// <param name="shellObj">Ссылка на пулю</param>
        public void Response(ShellObj shellObj)
        {
            shellObj.Detonation = true;
            // Удаление со списка обьектов игры
            Level.DictionaryObjGame[KeyObjGame.Wall].Remove(this);
        }        
    }
}

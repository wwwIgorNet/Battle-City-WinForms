using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Размеры обектов игры
    /// </summary>
    struct SizeGame
    {
        /// <summary>
        /// Высота большых обьектов
        /// </summary>
        public static readonly int HeighBig = 40;
        /// <summary>
        /// Щирина большых обьектов
        /// </summary>
        public static readonly int WidtchBig = 40;

        /// <summary>
        /// Высота маленьких обьектов
        /// </summary>
        public static readonly int HeighSmoll = 20;
        /// <summary>
        /// Щирина маленьких обьектов
        /// </summary>
        public static readonly int WidtchSmoll = 20;

        /// <summary>
        /// Высота снаряда
        /// </summary>
        public static readonly int HeighShell = 7;
        /// <summary>
        /// Щирина снаряда
        /// </summary>
        public static readonly int WidtchShell = 5;

        /// <summary>
        /// Щирина игрового поля
        /// </summary>
        public static readonly int HeighPlayengFild = 24 * HeighSmoll;
        /// <summary>
        /// Высота игрового поля
        /// </summary>
        public static readonly int WidtshPlayengFild = 26 * WidtchSmoll;

        /// <summary>
        /// Щирина клиенской части окна игры
        /// </summary>
        public static readonly int WidtchWindowGame = 31 * WidtchSmoll;
        /// <summary>
        /// Высота клиенской части окна игры
        /// </summary>
        public static readonly int HeighWindowGame = 26 * HeighSmoll;
    }
}


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

//namespace Game
//{
//    /// <summary>
//    /// Клас игра
//    /// </summary>
//    class Game
//    {
//        // Уровень
//        private Level level;
//        // Екран игры
//        private static ScreenGame screenGame;
//        public static Control ScreenGame { get { return screenGame; } }

//        /// <summary>
//        /// Конструктор
//        /// </summary>
//        /// <param name="control">Родительский Control</param>
//        public Game(Control control)
//        {
//            level = new Level();

//            screenGame = new ScreenGame(control);

//            Init();
//        }

//        /// <summary>
//        /// Очистка игры
//        /// </summary>
//        public void Clear()
//        {
//            level.Clear();
//        }


//        /// <summary>
//        /// инициализация
//        /// </summary>
//        public void Init()
//        {
//            level.LodLevel();
//        }

//        /// <summary>
//        /// Отрисовка
//        /// </summary>
//        public void Drow()
//        {
//            level.Drow();
//        }

//        /// <summary>
//        /// обновление
//        /// </summary>
//        public void Update()
//        {
//            level.Update();
//        }
//    }
//}

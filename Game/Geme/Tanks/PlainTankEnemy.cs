using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Вражеский обычный танк 
    /// </summary>
    [Serializable]
    class PlainTankEnemy : UpdateTankEnemy
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public PlainTankEnemy(Point position, Direction direction)
            : base(new Rectangle(position.X, position.Y, SettingsGame.WidtchBig, SettingsGame.HeighBig), 3, direction, 8, 100)
        {
            moweLeft = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\EnemyPlain\EnemyPlainTankLeft1.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\EnemyPlain\EnemyPlainTankLeft2.png") };
            moweRight = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\EnemyPlain\EnemyPlainTankRight1.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\EnemyPlain\EnemyPlainTankRight2.png") };
            moweUp = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\EnemyPlain\EnemyPlainTankUp1.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\EnemyPlain\EnemyPlainTankUp2.png") };
            moweDown = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\EnemyPlain\EnemyPlainTankDown1.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\EnemyPlain\EnemyPlainTankDown2.png") };

            spriteImage = moweDown[0];
        }
    }
}

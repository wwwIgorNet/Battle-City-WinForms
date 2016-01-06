using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Вражеский скорострельный танк 
    /// </summary>
    [Serializable]
    class RapidFireTanky : UpdateTankEnemy
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public RapidFireTanky(Point position, Direction direction)
            : base(new Rectangle(position.X, position.Y, SettingsGame.WidtchBig, SettingsGame.HeighBig), 3, direction, 12, 300)
        {
            moweLeft = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\RapidFireTank\Left.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\RapidFireTank\Left2.png")};
            moweRight = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\RapidFireTank\Right.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\RapidFireTank\Right2.png")};
            moweUp = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\RapidFireTank\Up.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\RapidFireTank\Up2.png")};
            moweDown = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\RapidFireTank\Down.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\RapidFireTank\Down2.png")};

            spriteImage = moweDown[0];
        }
    }
}

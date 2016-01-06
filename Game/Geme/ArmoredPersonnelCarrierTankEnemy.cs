using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Вражеский бронетранспортёр
    /// </summary>
    [Serializable]
    class ArmoredPersonnelCarrierTankEnemy : UpdateTankEnemy
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public ArmoredPersonnelCarrierTankEnemy(Point position, Direction direction)
            : base(new Rectangle(position.X, position.Y, SettingsGame.WidtchBig, SettingsGame.HeighBig), 6, direction, 8, 200)
        {
            moweLeft = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\ArmoredPersonnelCarrier\Left.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\ArmoredPersonnelCarrier\Left2.png")};
            moweRight = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\ArmoredPersonnelCarrier\Right.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\ArmoredPersonnelCarrier\Right2.png")};
            moweUp = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\ArmoredPersonnelCarrier\Up.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\ArmoredPersonnelCarrier\Up2.png")};
            moweDown = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\ArmoredPersonnelCarrier\Down.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\ArmoredPersonnelCarrier\Down2.png")};

            spriteImage = moweDown[0];
        }   
    }
}

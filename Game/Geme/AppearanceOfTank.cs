using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    /// <summary>
    /// Появление танка в виде звезды
    /// </summary>
    [Serializable]
    class AppearanceOfTank : ObjGame
    {
        private Image[] images;
        private int frame;
        private int cycles;
        private IAddTankToDictionary tank;
        public AppearanceOfTank(Point position, IAddTankToDictionary tank)
            : base(new Rectangle(position.X, position.Y, SettingsGame.WidtchBig, SettingsGame.HeighBig))
        {
            this.tank = tank;
            frame = 0;
            cycles = 0;

            string path = @"..\..\Resources\Content\Images\Tanks\Star";

            images = new Image[]{
                Image.FromFile(path + 1.ToString() + ".png"),
                Image.FromFile(path + 2.ToString() + ".png"),
                Image.FromFile(path + 3.ToString() + ".png"),
                Image.FromFile(path + 4.ToString() + ".png")
            };
            this.spriteImage = images[frame];

            Level.DictionaryObjGame[KeyObjGame.TankEnemy].Add(this);
        }

        public override void Update()
        {
            if (cycles % 4 == 0)
            {
                if (frame == 3) frame = 0;
                else frame++;
            }
            
            spriteImage = images[frame];
            cycles++;

            if(cycles == 36)
            {
                Level.DictionaryObjGame[KeyObjGame.TankEnemy].Remove(this);
                tank.AddTankToDictionary();
            }
        }
    }
}

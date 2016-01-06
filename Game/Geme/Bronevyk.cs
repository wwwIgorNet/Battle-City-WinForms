using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Вражеский броневик
    /// </summary>
    [Serializable]
    class Bronevyk : UpdateTankEnemy
    {
        // Количество попаданий
        private int numberOfHits;

        private Image[] moweLeftGren;
        private Image[] moweRightGren;
        private Image[] moweUpGren;
        private Image[] moweDownGren;

        private Image[] moweLeftYellow;
        private Image[] moweRightYellow;
        private Image[] moweUpYellow;
        private Image[] moweDownYellow;

        private Image[] moweLeftGray;
        private Image[] moweRightGray;
        private Image[] moweUpGray;
        private Image[] moweDownGray;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public Bronevyk(Point position, Direction direction)
            : base(new Rectangle(position.X, position.Y, SettingsGame.WidtchBig, SettingsGame.HeighBig), 3, direction, 8, 400)
        {
            numberOfHits = 0;

            moweLeftGray = moweLeft = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\Left.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\Left2.png")};
            moweRightGray = moweRight = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\Right.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\Right2.png")};
            moweUpGray = moweUp = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\Up.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\Up2.png")};
            moweDownGray = moweDown = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\Down.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\Down2.png")};

            moweLeftGren = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\LeftY.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\LeftY2.png")};
            moweRightGren = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\RightY.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\RightY2.png")};
            moweUpGren = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\UpY.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\UpY2.png")};
            moweDownGren = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\DownY.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\DownY2.png")};

            moweLeftYellow = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\LeftG.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\LeftG2.png")};
            moweRightYellow = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\RightG.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\RightG2.png")};
            moweUpYellow = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\UpG.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\UpG2.png")};
            moweDownYellow = new Image[] {
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\DownG.png"),
                Image.FromFile(SettingsGame.Content + @"Images\Tanks\Bronevyk\DownG2.png")};

            spriteImage = moweDown[0];
        }

        public override void Response(ShellObj shellObj)
        {
            // Если снаряд выпущен не етим танком
            if (shellObj.NameTank != KeyObjGame.TankEnemy)
            {
                if (numberOfHits == 0)
                {
                    SoundGame.SoundDetonation();
                    moweLeft = moweLeftGren;
                    moweRight = moweRightGren;
                    moweUp = moweUpGren;
                    moweDown = moweDownGren;
                    shellObj.Detonation = true;
                    numberOfHits++;
                }
                else if (numberOfHits == 1)
                {
                    SoundGame.SoundDetonation();
                    moweLeft = moweLeftYellow;
                    moweRight = moweRightYellow;
                    moweUp = moweUpYellow;
                    moweDown = moweDownYellow;
                    shellObj.Detonation = true;
                    numberOfHits++;
                }
                else if (numberOfHits == 2)
                {
                    SoundGame.SoundDetonation();
                    moweLeft = moweLeftGray;
                    moweRight = moweRightGray;
                    moweUp = moweUpGray;
                    moweDown = moweDownGray;
                    shellObj.Detonation = true;
                    numberOfHits++;
                }
                else if (numberOfHits == 3)
                {
                    base.Response(shellObj);
                }
            }
        }
    }
}

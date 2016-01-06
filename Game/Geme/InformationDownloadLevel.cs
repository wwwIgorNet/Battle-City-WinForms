using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    /// <summary>
    /// Информация загрузки уровня
    /// </summary>
    [Serializable]
    class InformationDownloadLevel : InformationGame
    {
        private bool isShow;
        private Rectangle bottom;
        private Rectangle top;
        private int countFrame;
        private InformationAboutLevel informationAboutLevel;
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public InformationDownloadLevel(int carentLevel)
            : base(new Rectangle(SettingsGame.WidtchWindowGame / 2 - SettingsGame.WidtchSmoll * 5, SettingsGame.HeighWindowGame / 2 - SettingsGame.HeighSmoll / 2, SettingsGame.WidtchSmoll * 7, SettingsGame.HeighSmoll))
        {
            countFrame = 40;
            isShow = true;
            bottom = new Rectangle(0, SettingsGame.HeighWindowGame, SettingsGame.WidtchWindowGame, SettingsGame.HeighWindowGame / 2);
            top = new Rectangle(0, -(SettingsGame.HeighWindowGame / 2), SettingsGame.WidtchWindowGame, SettingsGame.HeighWindowGame / 2);

            string path = @"..\..\Resources\Content\Images\Other\Stage.png";
            this.spriteImage = Image.FromFile(path);

            informationAboutLevel = new InformationAboutLevel(carentLevel, new Point(SettingsGame.WidtchWindowGame / 2 + SettingsGame.WidtchSmoll * 2, SettingsGame.HeighWindowGame / 2 - SettingsGame.HeighSmoll / 2));

            Level.ListInformation.Add(this);       
        }

        public void Update()
        {
            if (top.Y < 0)
            {
                top.Y += 5;
                bottom.Y -= 5;
            }
            else
                countFrame--;

            if (countFrame == 0)
            {
                isShow = false;
                Level.ListInformation.Remove(this);
            }

            if (countFrame == 39)
            {
                SoundGame.GameStart();
            }
        }
        
        public override void Draw(Graphics g, Point offset)
        {
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(99, 99, 99));
            g.FillRectangle(solidBrush, this.top);
            g.FillRectangle(solidBrush, this.bottom);
            if (top.Y >= 0)
            {
                base.Draw(g, offset);
                informationAboutLevel.Draw(g, offset);
            }
        }

        public bool IsShow()
        {
            return isShow;
        }
    }
}

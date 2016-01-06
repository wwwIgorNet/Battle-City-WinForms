using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    [Serializable]
    class Level
    {
        // Тикуший уровень
        private int carentLevel;
        private ImgGameOver imgGameOver;

        public static StateOfLevel StateOfLevel; // todo

        private InformationDownloadLevel informationDownloadLevel;
        public static Dictionary<KeyObjGame, List<ObjGame>> DictionaryObjGame;
        private Dictionary<KeyObjGame, List<ObjGame>> dictionaryObjGame;
        private List<ObjGame> listTankEnemy;
        private List<ObjGame> listPlayer;
        private List<ObjGame> listWall;
        private List<ObjGame> listWater;
        private List<ObjGame> listShell;
        private List<ObjGame> listIce;
        private List<ObjGame> listOther;

        public static List<IDraw> ListInformation;
        private List<IDraw> listInformation;

        private TankPlayer tankPlayer;
        private Eagle eagle;

        /// <summary>
        /// место постоянного появления объекта
        /// </summary>
        private Point respawnEagle;
        private Point respawnPlayer;

        private Random random;

        private int timerWin;

        private EnemyTanks enemyTanks;
        private string TanksEnemy;

        public Level()
        {
            listInformation = new List<IDraw>();
            dictionaryObjGame = new Dictionary<KeyObjGame, List<ObjGame>>();

            listTankEnemy = new List<ObjGame>();
            listPlayer = new List<ObjGame>();
            listWall = new List<ObjGame>();
            listShell = new List<ObjGame>();
            listWater = new List<ObjGame>();
            listIce = new List<ObjGame>();
            listOther = new List<ObjGame>();

            respawnEagle = new Point(12 * SettingsGame.WidtchSmoll, 24 * SettingsGame.HeighSmoll);
            respawnPlayer = new Point(8 * SettingsGame.WidtchSmoll, 24 * SettingsGame.HeighSmoll);
            random = new Random();

            dictionaryObjGame.Add(KeyObjGame.Ice, listIce);
            dictionaryObjGame.Add(KeyObjGame.TankEnemy, listTankEnemy);
            dictionaryObjGame.Add(KeyObjGame.Player, listPlayer);
            dictionaryObjGame.Add(KeyObjGame.Wall, listWall);
            dictionaryObjGame.Add(KeyObjGame.Water, listWater);
            dictionaryObjGame.Add(KeyObjGame.Shell, listShell);
            dictionaryObjGame.Add(KeyObjGame.Ohter, listOther);

            Level.DictionaryObjGame = dictionaryObjGame;
            Level.ListInformation = listInformation;
        }

        private void TimerWin()
        {
            if (carentLevel == SettingsGame.CountLevel)
                carentLevel = 1;
            else
                carentLevel++;

            this.DownloadLevel(carentLevel);
        }

        public void DownloadLevel(int n)
        {
            timerWin = 50;

            this.Clear();
            carentLevel = n;

            StateOfLevel = StateOfLevel.Download;

            string path = @"..\..\Resources\Content\Maps\" + carentLevel.ToString();
            string[] linesTileMap = File.ReadAllLines(path);
            TanksEnemy = linesTileMap[26];

            for (int i = 1; i <= 10; i++)
            {
                listInformation.Add(new InformationTank(new Point(27 * SettingsGame.WidtchSmoll, i * SettingsGame.HeighSmoll)));
                listInformation.Add(new InformationTank(new Point(28 * SettingsGame.WidtchSmoll, i * SettingsGame.HeighSmoll)));
            }

            listInformation.Add(new InformationAboutLevel(carentLevel, new Point(28 * SettingsGame.WidtchSmoll, 23 * SettingsGame.HeighSmoll)));
            listInformation.Add(new InformationAboutLivesPlayer(1));

            int x = 0, y = 0;
            foreach (string line in linesTileMap)
            {
                foreach (char c in line)
                {
                    switch (c)
                    {
                        case '#':
                            listWall.Add(new BrickWall(new Point(x, y)));
                            break;
                        case '@':
                            listWall.Add(new ConcreteWall(new Point(x, y)));
                            break;
                        case '~':
                            listWater.Add(new Water(new Point(x, y)));
                            break;
                        case '%':
                            listOther.Add(new Forest(new Point(x, y)));
                            break;
                        case '-':
                            listIce.Add(new Ice(new Point(x, y)));
                            break;
                    }
                    x += SettingsGame.WidtchSmoll;
                }
                x = 0;
                y += SettingsGame.HeighSmoll;
            }

            informationDownloadLevel = new InformationDownloadLevel(carentLevel);

            eagle = new Eagle(respawnEagle);
            listPlayer.Add(eagle);
        }

        public void InitStaticFild()
        {
            Level.DictionaryObjGame = dictionaryObjGame;
            Level.ListInformation = listInformation;
        }

        public void Draw()
        {
            BattleCity.ScreenGame.Invalidate(BattleCity.ScreenGame.ClientRectangle);
        }


        public void Update()
        {
            if (StateOfLevel == StateOfLevel.Download)
            {
                if (!informationDownloadLevel.IsShow())
                {
                    listInformation.Remove(informationDownloadLevel);

                    tankPlayer = new SmallTankPlayer(respawnPlayer, Direction.Up);
                    new AppearanceOfTank(respawnPlayer, tankPlayer);

                    enemyTanks = new EnemyTanks(TanksEnemy);
                    enemyTanks.AddEnemy();

                    StateOfLevel = StateOfLevel.Game;
                }
                else
                    informationDownloadLevel.Update();
            }
            if (StateOfLevel != StateOfLevel.GameOver)
            {
                for (int i = 0; i < listPlayer.Count; i++)
                {
                    listPlayer[i].Update();
                }
            }
            for (int i = 0; i < listOther.Count; i++)
            {
                listOther[i].Update();
            }
            foreach (var item in listWater)
            {
                item.Update();
            }
            for (int i = 0; i < listTankEnemy.Count; i++)
            {
                listTankEnemy[i].Update();
            }
            for (int i = 0; i < listShell.Count; i++)
            {
                listShell[i].Update();
            }


            if (StateOfLevel == StateOfLevel.GameOver)
            {
                if (imgGameOver == null)
                {
                    SoundGame.Stop();
                    imgGameOver = new ImgGameOver();
                    listInformation.Add(imgGameOver);
                }
                else
                    imgGameOver.Update();
            }

            if (StateOfLevel == StateOfLevel.Game)
            {
                // Если вражиских танков неосталось
                if (listTankEnemy.Count == 0 && !enemyTanks.IsTanks())
                {
                    if (timerWin == 0)
                    {
                        SoundGame.Stop();
                        TimerWin();
                    }
                    else timerWin--;
                }
                else if (listTankEnemy.Count < 3)
                {
                    enemyTanks.AddEnemy();
                }
            }
        }
        public void Clear()
        {
            imgGameOver = null;
            listInformation.Clear();
            foreach (var list in dictionaryObjGame.Values)
            {
                list.Clear();
            }
        }
    }
}

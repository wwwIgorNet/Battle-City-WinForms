using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    [Serializable]
    class EnemyTanks
    {
        private int selection;
        private Point respawnEnemy1;
        private Point respawnEnemy2;
        private Point respawnEnemy3;
        private int countEnemy;
        Point respawn;

        private string tanksEnemy;
        private int index;

        public EnemyTanks(string tanksEnemy)
        {
            this.tanksEnemy = tanksEnemy;
            index = 0;

            selection = 1;
            respawnEnemy1 = new Point();
            respawnEnemy2 = new Point(12 * SettingsGame.WidtchSmoll, 0);
            respawnEnemy3 = new Point(24 * SettingsGame.WidtchSmoll, 0);

            countEnemy = 20;
        }

        public void AddEnemy()
        {
            if (Level.DictionaryObjGame[KeyObjGame.TankEnemy].Count < 3 && countEnemy > 0)
            {
                if (selection == 3) selection = 1;
                else selection++;

                switch (selection)
                {
                    case 1:
                        respawn = respawnEnemy1;
                        break;
                    case 2:
                        respawn = respawnEnemy2;
                        break;
                    default:
                        respawn = respawnEnemy3;
                        break;
                }
                Rectangle rec = new Rectangle(respawn, new Size(SettingsGame.WidtchBig, SettingsGame.HeighBig));
                foreach (var KeyValue in Level.DictionaryObjGame)
                {
                    if (KeyValue.Key == KeyObjGame.Wall) continue;
                    foreach (var sprite in KeyValue.Value)
                    {
                        if (rec.IntersectsWith(sprite.Rect))
                            return;
                    }
                }

                switch (tanksEnemy[index])
                {
                    case 'P':
                        new AppearanceOfTank(respawn, new PlainTankEnemy(respawn, Direction.Down));
                        break;
                    case 'A':
                        new AppearanceOfTank(respawn, new ArmoredPersonnelCarrierTankEnemy(respawn, Direction.Down));
                        break;
                    case 'R':
                        new AppearanceOfTank(respawn, new RapidFireTanky(respawn, Direction.Down));
                        break;
                    case 'B':
                        new AppearanceOfTank(respawn, new Bronevyk(respawn, Direction.Down));
                        break;
                }
                index++;

                Level.ListInformation.RemoveAt(--countEnemy);
            }
        }

        public bool IsTanks()
        {
            if (countEnemy > 0) return true;
            else return false;
        }
    }
}

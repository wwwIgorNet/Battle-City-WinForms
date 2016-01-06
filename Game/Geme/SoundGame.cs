using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class SoundGame
    {
        static SoundGame()
        {
            soundMove.Open(new Uri(SettingsGame.Content + @"Media\SoundMove.wav", UriKind.Relative));

            soundStop.Open(new Uri(SettingsGame.Content + @"Media\SoundStop.wav", UriKind.Relative));

            gameStart.Open(new Uri(SettingsGame.Content + @"Media\GameStart.wav", UriKind.Relative));

            gameOver.Open(new Uri(SettingsGame.Content + @"Media\GameOver.wav", UriKind.Relative));

            soundFire.Open(new Uri(SettingsGame.Content + @"Media\Fire.wav", UriKind.Relative));

            soundBigDetonation.Open(new Uri(SettingsGame.Content + @"Media\DetonationShellBig.wav", UriKind.Relative));

            soundDetonation.Open(new Uri(SettingsGame.Content + @"Media\Detonation.wav", UriKind.Relative));
        }

        private static System.Windows.Media.MediaPlayer gameOver = new System.Windows.Media.MediaPlayer();
        public static void GameOver()
        {
            gameOver.Stop();
            gameOver.Play();
        }

        private static System.Windows.Media.MediaPlayer gameStart = new System.Windows.Media.MediaPlayer();
        public static void GameStart()
        {
            gameStart.Stop();
            gameStart.Play();
        }

        private static System.Windows.Media.MediaPlayer soundFire = new System.Windows.Media.MediaPlayer();
        public static void SoundFire()
        {
            soundFire.Stop();
            soundFire.Play();
        }

        private static System.Windows.Media.MediaPlayer soundBigDetonation = new System.Windows.Media.MediaPlayer();
        public static void SoundBigDetonation()
        {
            soundBigDetonation.Stop();
            soundBigDetonation.Play();
        }


        private static System.Windows.Media.MediaPlayer soundDetonation = new System.Windows.Media.MediaPlayer();
        public static void SoundDetonation()
        {
            soundDetonation.Stop();
            soundDetonation.Play();
        }

        private static System.Windows.Media.MediaPlayer soundMove = new System.Windows.Media.MediaPlayer();
        private static bool move;
        public static void SoundMove()
        {
            if (!move)
            {
                soundStop.Stop();
                soundMove.Play();
                move = true;
                stop = false;
            }
        }

        private static System.Windows.Media.MediaPlayer soundStop = new System.Windows.Media.MediaPlayer();
        private static bool stop;
        public static void SoundStop()
        {
            if (!stop)
            {
                soundMove.Stop();
                soundStop.Play();
                stop = true;
                move = false;
            }
        }

        public static void Stop()
        {
            SoundGame.soundMove.Stop();
            SoundGame.soundStop.Stop();
            move = false;
            stop = false;
        }

    }
}

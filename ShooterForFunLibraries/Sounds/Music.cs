using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Sounds
{
    public class Music : BaseSound, ISound
    {
        private Song song;

        public void LoadContent()
        {
            song = Content.Load<Song>(Path);
        }

        public void UnloadContent()
        {
            Dispose();
        }

        public void Play(float volume)
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
        }

        public void Stop()
        {
            MediaPlayer.Stop();
        }
    }
}

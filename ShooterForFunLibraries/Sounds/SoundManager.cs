using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Sounds
{
    public class SoundManager
    {
        private static SoundManager instance;
        public static SoundManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new SoundManager();
                return instance;
            }
        }

        public bool IsMuted { get; set; }

        public float MaxVolume { get; set; }

        public SoundManager()
        {
            MaxVolume = 1.0f;
            IsMuted = false;
        }

        public void Play(ISound sound, float volume = 1.0f)
        {
            if (IsMuted)
                return;

            sound.Play(Math.Min(volume, MaxVolume));
        }

        public void Stop(ISound sound)
        {
            sound.Stop();
        }
    }
}

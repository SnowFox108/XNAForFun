using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;

namespace ShooterForFunLibraries.Sounds
{
    public class Sound : BaseSound, ISound
    {

        private SoundEffect sound;

        public void LoadContent()
        {
            sound = Content.Load<SoundEffect>(Path);
        }

        public void UnloadContent()
        {
            //Dispose();
        }

        public void Play(float volume)
        {
            try
            {
                sound.Play(volume, 0.0f, 0.0f);
            }
            catch(Exception ex)
            {
                // sound not work
            }
        }

        public void Stop()
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Sounds
{
    public interface ISound
    {
        string Id { get; set; }
        string Path { get; set; }

        void LoadContent();
        void UnloadContent();
        void Play(float volume);
        void Stop();
    }
}

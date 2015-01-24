using ShooterForFunLibraries.Sounds;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ShooterForFunLibraries
{
    public class MusicContents
    {
        [XmlElement("Music")]
        public List<Music> Musics { get; set; }
    }
}

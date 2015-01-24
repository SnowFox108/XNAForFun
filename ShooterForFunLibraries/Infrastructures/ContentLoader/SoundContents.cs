using ShooterForFunLibraries.Sounds;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ShooterForFunLibraries
{
    public class SoundContents
    {
        [XmlElement("Sound")]
        public List<Sound> Sounds { get; set; }
    }
}

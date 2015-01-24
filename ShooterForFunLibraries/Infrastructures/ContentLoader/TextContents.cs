using ShooterForFunLibraries.Graphics;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ShooterForFunLibraries
{
    public class TextContents
    {
        [XmlElement("TextMessage")]
        public List<TextMessage> TextMessages { get; set; }
    }
}

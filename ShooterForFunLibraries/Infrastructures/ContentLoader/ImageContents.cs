using ShooterForFunLibraries.Graphics;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ShooterForFunLibraries
{
    public class ImageContents
    {
        [XmlElement("Image")]
        public List<Image> Images { get; set; }
    }
}

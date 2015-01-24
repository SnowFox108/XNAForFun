using ShooterForFunLibraries.Graphics;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ShooterForFunLibraries
{
    public class ShapeContents
    {
        [XmlElement("Shape")]
        public List<Shape> Shapes { get; set; }
    }
}

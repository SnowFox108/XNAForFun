using ShooterForFunLibraries.Graphics;
using ShooterForFunLibraries.Sounds;
using System.Collections.Generic;

namespace ShooterForFunLibraries
{
    public class ContentLoader
    {
        public List<Image> LoadImages(string xmlPath)
        {
            XMLManager<ImageContents> xmlManager = new XMLManager<ImageContents>();
            return xmlManager.Load(xmlPath).Images;
        }

        public List<Shape> LoadShapes(string xmlPath)
        {
            XMLManager<ShapeContents> xmlManager = new XMLManager<ShapeContents>();
            return xmlManager.Load(xmlPath).Shapes;
        }

        public List<TextMessage> LoadText(string xmlPath)
        {
            XMLManager<TextContents> xmlManager = new XMLManager<TextContents>();
            return xmlManager.Load(xmlPath).TextMessages;
        }

        public List<Music> LoadMusics(string xmlPath)
        {
            XMLManager<MusicContents> xmlManager = new XMLManager<MusicContents>();
            return xmlManager.Load(xmlPath).Musics;
        }

        public List<Sound> LoadSounds(string xmlPath)
        {
            XMLManager<SoundContents> xmlManager = new XMLManager<SoundContents>();
            return xmlManager.Load(xmlPath).Sounds;
        }
    }
}

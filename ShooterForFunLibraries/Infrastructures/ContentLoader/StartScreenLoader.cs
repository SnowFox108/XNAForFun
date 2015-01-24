using ShooterForFunLibraries.Graphics;
using ShooterForFunLibraries.Sounds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries
{
    public class StartScreenLoader
    {
        internal class ContentName
        {
            // Images
            internal const string imgBackGround = "BackGround";

            // Texts
            internal const string txtStartButton = "StartButton";

            // Shapes
            internal const string shpMenuButton = "MenuButton";

            // Music
            internal const string sndMenuMusic = "MenuMusic";
           
        }

        private const string imagePath = "Data.StartScreen.Images.xml";
        private const string textPath = "Data.StartScreen.Text.xml";
        private const string shapePath = "Data.StartScreen.Shapes.xml";
        private const string musicPath = "Data.StartScreen.Musics.xml";

        private List<Image> images;
        private List<TextMessage> textMessages;
        private List<Shape> shapes;
        private List<Music> musics;

        public StartScreenLoader()
        {
            ContentLoader contentLoader = new ContentLoader();
            images = contentLoader.LoadImages(imagePath);
            textMessages = contentLoader.LoadText(textPath);
            shapes = contentLoader.LoadShapes(shapePath);
            musics = contentLoader.LoadMusics(musicPath);
        }

        #region Images
        public Image GetBackGround()
        {
            return images.Find(i => i.Id == ContentName.imgBackGround);
        }
        #endregion

        #region Texts

        public TextMessage CreateStartButtonText()
        {
            return textMessages.Find(txt => txt.Id == ContentName.txtStartButton).Clone();
        }

        #endregion

        #region Shapes

        public Shape CreateMenuButton()
        {
            return shapes.Find(shp => shp.Id == ContentName.shpMenuButton).Clone();
        }

        #endregion

        #region Sounds

        public Music GetBackGroundMusic()
        {
            return musics.Find(snd => snd.Id == ContentName.sndMenuMusic);
        }

        #endregion
    }
}

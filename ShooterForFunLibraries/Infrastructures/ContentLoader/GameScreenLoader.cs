using Microsoft.Xna.Framework;
using ShooterForFunLibraries.Graphics;
using ShooterForFunLibraries.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries
{
    public class GameScreenLoader
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
            internal const string sndGameMusic = "GameMusic";

        }

        private const string imagePath = "Data.GameScreen.Images.xml";
        private const string textPath = "Data.StartScreen.Text.xml";
        private const string shapePath = "Data.StartScreen.Shapes.xml";
        private const string musicPath = "Data.GameScreen.Musics.xml";

        private List<Image> images;
        private List<TextMessage> textMessages;
        private List<Shape> shapes;
        private List<Music> musics;

        public GameScreenLoader()
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

        public TextMessage GetGameText()
        {
            return textMessages.Find(txt => txt.Id == ContentName.txtStartButton);
        }

        public FPSdisplay GetFPSDisplay()
        {
            return new FPSdisplay()
            {
                Id = "FPS",
                Path = "Fonts/Tahoma",
                Text = "0.0",
                Position = new Vector2(10, 10)
            };
        }

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
            return musics.Find(snd => snd.Id == ContentName.sndGameMusic);
        }

        #endregion

    }
}

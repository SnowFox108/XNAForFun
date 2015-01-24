using Microsoft.Xna.Framework.Content;

namespace ShooterForFunLibraries.Sounds
{
    public class BaseSound
    {
        public string Id { get; set; }
        public string Path { get; set; }

        private ContentManager content;

        public ContentManager Content
        {
            get
            {
                if (content == null)
                    content = ScreenManager.Instance.Content;
                return content;
            }
        }

        public BaseSound()
        {
            Id = string.Empty;
            Path = string.Empty;
        }

        public void Dispose()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Inputs
{
    public class InputManager
    {
        private static InputManager instance;

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputManager();
                return instance;
            }
        }

        private InputKeyboardState keyBoard;
        public InputKeyboardState KeyBoard { get { return keyBoard; } }
        
        private bool enableKeyboard;
        public bool EnableKeyBoard
        {
            get { return enableKeyboard; }
            set
            {
                enableKeyboard = value;
                if (enableKeyboard && keyBoard == null)
                    keyBoard = new InputKeyboardState();
                keyBoard.IsReadingInput = enableKeyboard;
            }
        }

        private InputMouseState mouse;
        public InputMouseState Mouse { get { return mouse; } }

        private bool enableMouse;
        public bool EnableMouse
        {
            get { return enableMouse; }
            set
            {
                enableMouse = value;
                if (enableMouse && mouse == null)
                    mouse = new InputMouseState();
                mouse.IsReadingInput = enableMouse;
            }
        }

        private InputTouchState touch;
        public InputTouchState Touch { get { return touch; } }

        private bool enableTouch;
        public bool EnableTouch
        {
            get { return enableTouch; }
            set
            {
                enableTouch = value;
                if (enableTouch && touch == null)
                    touch = new InputTouchState();
                touch.IsReadingInput = enableTouch;
            }
        }

        public InputManager()
        {
        }

        public void Update()
        {
            if (enableKeyboard)
                keyBoard.Update();
            if (enableMouse)
                mouse.Update();
            if (enableTouch)
                touch.Update();
        }
    }
}

using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Inputs
{
    public class InputKeyboardState
    {
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        private readonly IDictionary<Keys, TimeSpan> keyHeldTimes;

        public bool IsReadingInput { get; set; }

        public InputKeyboardState()
        {
            keyHeldTimes = new Dictionary<Keys, TimeSpan>();
            foreach (var key in Enum.GetValues(typeof(Keys)))
            {
                keyHeldTimes.Add((Keys)key, TimeSpan.Zero);
            }
        }

        public void Update()
        {
            previousKeyboardState = currentKeyboardState;
            if (IsReadingInput)
                currentKeyboardState = Keyboard.GetState();
        }

        public bool KeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key))
                    return true;
            }
            return false;
        }

        public bool KeyHolding(Keys key, TimeSpan timeSpan)
        {
            return GetElapsedHeldTime(key).CompareTo(timeSpan) >= 0;
        }

        public TimeSpan GetElapsedHeldTime(Keys key)
        {
            return keyHeldTimes[key];
        }

        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key))
                    return true;
            }
            return false;
        }

        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyboardState.IsKeyDown(key))
                    return true;
            }
            return false;
        }
    }
}

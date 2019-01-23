using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Sinistar.Input;
using Sinistar.Input.Listeners;
using Sinistar.Input.Binders;

namespace Sinistar.Input
{
    class InputManager
    {
        
        Dictionary<Keys, bool> keyInputs;
        List<GeneralInputListener> generalListeners;
        List<GamepadListener> gamepadListeners;
        List<KeyboardListener> keyboardListeners;
        List<MouseListener> mouseListeners;

        Dictionary<Keys, KeyboardBind> keyboardBinds;
        Dictionary<Keys, GamepadBind> gamepadBinds;
        Dictionary<Keys, MouseBind> mouseBinds;

        GamePadState oldGPDState1;
        GamePadState oldGPDState2;
        GamePadState oldGPDState3;
        GamePadState oldGPDState4;

        KeyboardState oldKeyState;
        MouseState oldMosState;


        public InputManager()
        {
            generalListeners = new List<GeneralInputListener>();
            gamepadListeners = new List<GamepadListener>();
            keyboardListeners = new List<KeyboardListener>();
            mouseListeners = new List<MouseListener>();

            keyboardBinds = new Dictionary<Keys, KeyboardBind>();
            gamepadBinds = new Dictionary<Keys, GamepadBind>();
            mouseBinds = new Dictionary<Keys, MouseBind>();
        }

        /// <summary>
        ///     Registers a listener to this manager
        /// </summary>
        /// <param name="listener">The listener class</param>
        public void addListener(GeneralInputListener listener) 
        {
            generalListeners.Add(listener);
        }
        /// <summary>
        ///     Removes a listener to this manager
        /// </summary>
        /// <param name="listener">The listener class</param>
        public void removeListener(GeneralInputListener listener)
        {
            generalListeners.Remove(listener);
        }

        /// <summary>
        ///     Adds a Gamepad input handler only to this manager
        /// </summary>
        /// <param name="listener">The gamepad listener class</param>
        public void addGamepadListener(GamepadListener listener)
        {
            gamepadListeners.Add(listener);
        }
        /// <summary>
        ///     Removes a Gamepad input handler only to this manager
        /// </summary>
        /// <param name="listener">The gamepad listener class</param>
        public void removeGamepadListener(GamepadListener listener)
        {
            gamepadListeners.Remove(listener);
        }

        /// <summary>
        ///     Adds a Keyboard input handler only to this manager
        /// </summary>
        /// <param name="listener">The keyboard listener class</param>
        public void addKeyboardListener(KeyboardListener listener)
        {
            keyboardListeners.Add(listener);
        }
        /// <summary>
        ///     Removes a Keyboard input handler only to this manager
        /// </summary>
        /// <param name="listener">The keyboard listener class</param>
        public void removeKeyboardListener(KeyboardListener listener)
        {
            keyboardListeners.Remove(listener);
        }

        /// <summary>
        ///     Adds a Mouse input handler only to this manager
        /// </summary>
        /// <param name="listener">The mouse listener class</param>
        public void addMouseListener(MouseListener listener)
        {
            mouseListeners.Add(listener);
        }
        /// <summary>
        ///     Removes a Mouse input handler only to this manager
        /// </summary>
        /// <param name="listener">The mouse listener class</param>
        public void removeMouseListener(MouseListener listener)
        {
            mouseListeners.Remove(listener);
        }

        /// <summary>
        ///     Sets a bind to a specific keyboard key. When this key is pressed the method will be called
        /// </summary>
        /// <param name="bind">The binded class</param>
        /// <param name="key">The key</param>
        public void setKeyboardBind(KeyboardBind bind, Keys key)
        {
            keyboardBinds.Add(key, bind);
        }

        /// <summary>
        ///     Unsets a bind to a specific keyboard key. When this key is pressed the method will be called
        /// </summary>
        /// <param name="bind">The binded class</param>
        /// <param name="key">The key</param>
        public void removeKeyboardBind(Keys key)
        {
            keyboardBinds.Remove(key);
        }



        private void fireInputBegan(InputDeviceType inputType, GamePadState gpdState, KeyboardState keyState, MouseState mosState, Keys keyBtn, GamepadCode gpdBtn, MouseCode mosBtn)
        {
            InputObject input = new InputObject(inputType, gpdState, mosState, keyBtn, gpdBtn, mosBtn);
            //General
            for (int i = 0; i < generalListeners.Count; i++)
            {
                GeneralInputListener listener = generalListeners[i];
                listener.InputBegan(input);
                switch (inputType)
                {
                    case (InputDeviceType.Gamepad):
                        listener.GamepadInputBegan(input);
                        break;
                    case (InputDeviceType.Keyboard):
                        listener.KeyboardInputBegan(input);
                        break;
                    case (InputDeviceType.Mouse):
                        listener.MouseInputBegan(input);
                        break;
                }
            }
            //Others
            switch (inputType)
            {
                case (InputDeviceType.Gamepad):
                    for (int i = 0; i < gamepadListeners.Count; i++)
                    {
                        GamepadListener listener = gamepadListeners[i];
                        listener.InputBegan(input);
                    }
                    break;

                case (InputDeviceType.Keyboard):
                    for (int i = 0; i < keyboardListeners.Count; i++)
                    {
                        KeyboardListener listener = keyboardListeners[i];
                        listener.InputBegan(input);
                    }
                    if (keyboardBinds.ContainsKey(keyBtn))
                    {
                        keyboardBinds[keyBtn].Began();
                    }
                    break;

                case (InputDeviceType.Mouse):
                    for (int i = 0; i < mouseListeners.Count; i++)
                    {
                        MouseListener listener = mouseListeners[i];
                        listener.InputBegan(input);
                    }
                    break;
                default:
                    break;
            }
        }


        private void fireInputEnd(InputDeviceType inputType, GamePadState gpdState, KeyboardState keyState, MouseState mosState, Keys keyBtn, GamepadCode gpdBtn, MouseCode mosBtn)
        {
            InputObject input = new InputObject(inputType, gpdState, mosState, keyBtn, gpdBtn, mosBtn);
            //General
            for (int i = 0; i < generalListeners.Count; i++)
            {
                GeneralInputListener listener = generalListeners[i];
                listener.InputEnded(input);
                switch (inputType)
                {
                    case (InputDeviceType.Gamepad):
                        listener.GamepadInputEnded(input);
                        break;
                    case (InputDeviceType.Keyboard):
                        listener.KeyboardInputEnded(input);
                        break;
                    case (InputDeviceType.Mouse):
                        listener.MouseInputEnded(input);
                        break;
                }
            }
            //Others
            switch (inputType)
            {
                case (InputDeviceType.Gamepad):
                    for (int i = 0; i < gamepadListeners.Count; i++)
                    {
                        GamepadListener listener = gamepadListeners[i];
                        listener.InputEnded(input);
                    }
                    break;

                case (InputDeviceType.Keyboard):
                    for (int i = 0; i < keyboardListeners.Count; i++)
                    {
                        KeyboardListener listener = keyboardListeners[i];
                        listener.InputEnded(input);
                    }
                    if (keyboardBinds.ContainsKey(keyBtn))
                    {
                        keyboardBinds[keyBtn].Ended();
                    }
                    break;

                case (InputDeviceType.Mouse):
                    for (int i = 0; i < mouseListeners.Count; i++)
                    {
                        MouseListener listener = mouseListeners[i];
                        listener.InputEnded(input);
                    }
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        ///     Updates the input
        /// </summary>
        public void updateInput()
        {
            GamePadState newGPDState1 = GamePad.GetState(PlayerIndex.One); //I guess we are only using one...
            //...
            KeyboardState newKeyState = Keyboard.GetState();
            MouseState newMosState = Mouse.GetState();

            //Keyboard
            if (newKeyState != oldKeyState)
            {
                Keys[] oldKeys = oldKeyState.GetPressedKeys();
                Keys[] newKeys = newKeyState.GetPressedKeys();
                Dictionary<Keys, bool> keyDiff = new Dictionary<Keys, bool>(); //Key : IsPressed

                List<Keys> pressed = new List<Keys>();
                List<Keys> released = new List<Keys>();

                int numPressed = 0;
                int numReleased = 0;
                for (int i=0; i<newKeys.Length; i++)
                {
                    numPressed++;
                    keyDiff.Add(newKeys[i], true);
                }
                for (int i = 0; i < oldKeys.Length; i++)
                {
                    Keys oldKey = oldKeys[i];
                    if (keyDiff.ContainsKey(oldKey)) //Could use contains method for a list? But performace?
                    {
                        numPressed--;
                        keyDiff.Remove(oldKey); 
                    }
                    else
                    {
                        numReleased++;
                        fireInputEnd(InputDeviceType.Keyboard, newGPDState1, newKeyState, newMosState, oldKey, GamepadCode.None, MouseCode.None);
                    }
                }
                for (int i = 0; i < keyDiff.Keys.Count; i++)
                {
                    Keys key = keyDiff.Keys.ElementAt(i);
                    bool isPressed = keyDiff[key];
                    if (isPressed)
                        fireInputBegan(InputDeviceType.Keyboard, newGPDState1, newKeyState, newMosState, key, GamepadCode.None, MouseCode.None);
                }
            }

            //Gamepad
            if (oldGPDState1 != newGPDState1)
            {

            }

            oldGPDState1 = newGPDState1;
            oldKeyState = newKeyState;
            oldMosState = newMosState;
        }

    }
    
}

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


namespace Sinistar.Input
{
    class InputManager
    {
        
        Dictionary<Keys, bool> keyInputs;
        List<InputListener> inputListeners;

        GamePadState oldGPDState1;
        GamePadState oldGPDState2;
        GamePadState oldGPDState3;
        GamePadState oldGPDState4;

        KeyboardState oldKeyState;
        MouseState oldMosState;


        public InputManager()
        {
            inputListeners = new List<InputListener>();
        }

        public void addListener(InputListener listener) 
        {
            inputListeners.Add(listener);
        }
        public void removeListener(InputListener listener)
        {
            inputListeners.Remove(listener);
        }

        public void fireInputBegan(InputObject inObj)
        {

        }
        public void fireInputEnd(InputObject inObj)
        {

        }

        public void updateInput()
        {
            GamePadState newGPDState1 = GamePad.GetState(PlayerIndex.One); //I guess we are only using one...
            //...
            KeyboardState newKeyState = Keyboard.GetState();
            MouseState newMosState = Mouse.GetState();


            if (newKeyState != oldKeyState)
            {
                Keys[] oldKeys = oldKeyState.GetPressedKeys();
                Keys[] newKeys = newKeyState.GetPressedKeys();
                Dictionary<Keys, bool> keyDiff = new Dictionary<Keys, bool>(); //Key : IsPressed

                int numPressed = 0;
                int numReleased = 0;
                for (int i=0; i<newKeys.Length; i++)
                {
                    keyDiff.Add(newKeys[i], true);
                }
                //Lets remove ones that are already pressed then add the ones that were released
                for (int i = 0; i<oldKeys.Length; i++)
                {
                    Keys oldKey = oldKeys[i];
                    if (keyDiff.ContainsKey(oldKey))
                        keyDiff.Remove(oldKey);
                    else
                        keyDiff.Add(newKeys[i], false);
                }

                Keys[] pressed = new Keys[];
                Keys[] released;

            }


            oldGPDState1 = newGPDState1;
            oldKeyState = newKeyState;
            oldMosState = newMosState;
        }


    }

    interface InputListener {

        void InputBegan();
        void InputEnded();

    }


    public class InputObject
    {
        enum KeyCode
        {
            GamepadX, GamepadA, GamepadB, GamepadY,
            GamepadRB, GamepadLB, GamepadRT, GamepadLT,
            GamepadStart, GamepadBack, GamepadBigButton,
            DPadL, DPadR, DPadU, DPadD,

            MouseLeft, MouseRight, MouseMiddle,
            MouseScrollUp, MouseScrollDown, Mouse2, Mouse3, Mouse4,

            KeyboardInput
        }

        private KeyboardState keyState;
        private GamePadState gpdState;
        private MouseState msState;


        
        public InputObject(KeyboardState keyState, GamePadState gpdState, MouseState msState)
        {
            this.keyState = keyState;
            this.gpdState = gpdState;
            this.msState = msState;
            
        }


        public KeyCode getKeyCode()
        {
            
        }

        public Keys getKeyboardCode()
        {
            return keyState.
        }


    }

}

using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;

namespace Common.Helpers.System
{
    public static class WaldemInput
    {
        public static bool IsButtonDown(WaldemButtons _button){
            var intButton = (int)_button;
            if(intButton < 8){
                return MouseExtended.GetState().IsButtonDown((MouseButton)intButton);
            }
            else if(intButton > 7){
                return KeyboardExtended.GetState().IsKeyDown((Keys)intButton);
            }

            return false;
        }

        public static bool IsButtonUp(WaldemButtons _button){
            var intButton = (int)_button;
            if(intButton < 8){
                return MouseExtended.GetState().IsButtonUp((MouseButton)intButton);
            }
            else if(intButton > 7){
                return KeyboardExtended.GetState().IsKeyUp((Keys)intButton);
            }

            return false;
        }

        public static bool WasButtonJustDown(WaldemButtons _button){
            var intButton = (int)_button;
            if(intButton < 8){
                return MouseExtended.GetState().WasButtonJustDown((MouseButton)intButton);
            }
            else if(intButton > 7){
                return KeyboardExtended.GetState().WasKeyJustUp((Keys)intButton);
            }

            return false;
        }
        
        public static bool WasButtonJustUp(WaldemButtons _button){
            var intButton = (int)_button;
            if(intButton < 8){
                return MouseExtended.GetState().WasButtonJustUp((MouseButton)intButton);
            }
            else if(intButton > 7){
                return KeyboardExtended.GetState().WasKeyJustDown((Keys)intButton);
            }

            return false;
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGame.Utils
{
    public static class Global
    {
        public static ContentManager TextureLoader;
        public static SpriteFont Font;

        public static T Load<T>(string Filename)
        {
            try
            {
                return TextureLoader.Load<T>(Filename);
            }
            catch
            {
                return TextureLoader.Load<T>("Default");
            }         
        }
        public static T LoadFont<T>(string Filename)
        {
            try
            {
                return TextureLoader.Load<T>(Filename);
            }
            catch
            {
                return TextureLoader.Load<T>("DefaultFont");
                
            }
        }

        public static MouseState CurrMState;
        public static MouseState LastMState;
        public static void UpdateMstate()
        {
            LastMState = CurrMState;
            CurrMState = Mouse.GetState();
        }
        public static Rectangle MouseHitBox() 
        {
            return new Rectangle(CurrMState.Position.X, CurrMState.Position.Y, 16, 16);
        }

        public static KeyboardState CurrKBState;
        public static KeyboardState LastKBState;
        public static void UpdateKBState()
        {
            LastKBState = CurrKBState;
            CurrKBState = Keyboard.GetState();
        }

        public static Vector2 currResolution;
    }
}

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGame
{
    public static class Desktop
    {
        private static Texture2D Bg;
        private static Controls.DesktopIcon TestWindow;

        public static void Load()
        {
            Bg = Utils.Global.Load<Texture2D>("DBackground");
            TestWindow = new Controls.DesktopIcon(new Vector2(64, 64), "Test", "TestIcon");
        }

        public static void Update()
        {
            if(TestWindow.Update() == true)
            {
                Windows.Manager.AddWindow(new Windows.Window());
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Bg, Vector2.Zero, Color.White);
            TestWindow.Draw(spriteBatch);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGame.Controls
{
    class TextDrawer
    {
        public Vector2 Position;
        public SpriteFont font;
        public String Text;

        public TextDrawer(Vector2 Position, String Text)
        {
            this.Position = Position;
            this.Text = Text;
            font = Utils.Global.LoadFont<SpriteFont>("Font");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, Text,
                new Vector2(Position.X, Position.Y), Color.White);
        }
    }
}

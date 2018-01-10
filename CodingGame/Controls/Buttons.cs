using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGame.Controls
{
   public class Buttons
    {
        public Vector2 Position;
        public Texture2D Texture;
        String Text;
        Vector2 Size;
        public Vector2 Scale;
        public Rectangle Hitbox
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y); }
        }

        public Buttons(Vector2 Position, Vector2 Size, String TextureName)
        {
            this.Position = Position;
            this.Size = Size;
            Texture = Utils.Global.Load<Texture2D>(TextureName);
            Text = null;         
            Scale = new Vector2(Size.X / Utils.Global.currResolution.X, Size.Y / Utils.Global.currResolution.Y);
            this.Position.X -= (Texture.Width * Scale.X);
        }
        public Buttons(Vector2 Position, String TextureName, String ButtonText)
        {
            this.Position = Position;
            Utils.Global.Load<Texture2D>(TextureName);
            Text = ButtonText;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Utils.Global.MouseHitBox().Intersects(Hitbox))
            {
                spriteBatch.Draw(Texture, Position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 1); //White if mouse on button
            }
            else
            {
                spriteBatch.Draw(Texture, Position, null, Color.Black, 0, Vector2.Zero, Scale, SpriteEffects.None, 1); //Black if mouse not on button
            }
        }
    }
}

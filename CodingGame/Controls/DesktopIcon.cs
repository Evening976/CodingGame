using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGame.Controls
{
    public class DesktopIcon
    {
        TextDrawer Name;
        Vector2 Position;
        Texture2D Icon;
        Vector2 scale;

        Rectangle Hitbox
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, 128,  72); }
        }

        public DesktopIcon(Vector2 Position, string IconName, String IconTextureName)
        {
            scale = new Vector2
                (128 / Utils.Global.currResolution.X,72 / Utils.Global.currResolution.Y);

            this.Position = Position;
            Icon = Utils.Global.Load<Texture2D>(IconTextureName);

            Name = new TextDrawer
                (new Vector2((Position.X + ((Icon.Width * scale.X) / 2)) - (Utils.Global.Font.MeasureString(IconName).X / 2),
                Position.Y + (Icon.Height * scale.Y)), IconName);
        }

        public bool Update()
        {
            //If mouse is in the icon and has his button pressed, the icon has been pressed !
            if (Hitbox.Intersects(Utils.Global.MouseHitBox()) 
                && Utils.Global.CurrMState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed
                && Utils.Global.LastMState.LeftButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                return true;
            }

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Icon, Position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 1);
            Name.Draw(spriteBatch);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGame.Windows
{
    public class Window
    {
        public bool tokill = false;
        public string Type = "BaseWindow";
        Controls.Buttons ExitButton;
        // Controls.Readbox rBox;
        Controls.Textbox tBox;
        Vector2 Position, Size;
        Texture2D Texture;
        public Rectangle Hitbox
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y); }
        }
        public Rectangle moveHBox
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y,
                (int)Size.X - (int)(ExitButton.Texture.Width * ExitButton.Scale.X), 16); }
        }

        public Window()
        {
            this.Position = Utils.Global.currResolution / 2;
            this.Size = new Vector2(300, 300);
            Texture = Utils.Global.Load<Texture2D>("WindowBG");
            ExitButton = new Controls.Buttons
                (new Vector2((Position.X+Texture.Width), Position.Y), new Vector2(32,18), "ExitButton");
            tBox = new Controls.Textbox(new Vector2(Position.X + 12, Position.Y + Texture.Height / 2));
            //rBox = new Controls.Readbox(new Vector2(Position.X + 12, (Position.Y + Texture.Height / 2)), "Drape sacre leurs on echos qu leurs trois. Un se troupeau veterans contient victoire je criaient amoureux. Certitude une incapable apprendre des abondance citadelle direction. Retombait escadrons annoncait portieres en ma boulevard he. Remit du parut treve subir il la xv. Noces jet saute oui rirez ete parce.");
        }

        public virtual void Update()
        {
            if (moveHBox.Intersects(new Rectangle(Utils.Global.CurrMState.X, Utils.Global.CurrMState.Y, 16, 16)) 
                && Utils.Global.CurrMState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                Position = new Vector2(Utils.Global.CurrMState.X - (Texture.Width / 2), Utils.Global.CurrMState.Y);
                ExitButton.Position = 
                    new Vector2((Position.X + Texture.Width) - ExitButton.Texture.Width * ExitButton.Scale.X, Position.Y);
               // rBox.Position = new Vector2(Position.X + 12, (Position.Y + Texture.Height / 2));
            }

            if(ExitButton.Hitbox.Intersects(Utils.Global.MouseHitBox()) 
                && Utils.Global.CurrMState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                //if mouse button clicks on the little cross up-right the window, kill it!
                tokill = true;
            }

            tBox.Update();
            //rBox.Update();
        } 

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            ExitButton.Draw(spriteBatch);
            tBox.Draw(spriteBatch);
            //rBox.Draw(spriteBatch);
        }


    }
}

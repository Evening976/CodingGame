using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGame.Controls
{
    class Readbox
    {
        Texture2D Texture;
        public Vector2 Position;
        private float offsetx, offsety;
        TextDrawer text;
        //String Text;

        public Readbox(Vector2 Position, String Text)
        {
            Texture = Utils.Global.Load<Texture2D>("ReadBoxBG");
            this.Position = Position;
            offsetx = 5;
            offsety = 2;


            text = new TextDrawer(new Vector2(this.Position.X + offsetx, this.Position.Y + offsety), Text);

            //Met des sauts de lignes quand le texte > la taille de notre box.
            char[] textchr = text.Text.ToCharArray();
            List<string> lines = new List<string>(); int offset = 0; //int nLine = 0;

            if(text.font.MeasureString(text.Text).X > this.Texture.Width)
            {
                for (int i = 1; offset < text.Text.Length; i++)
                {
                    char[] selectedtextchr = textchr.Skip(offset).Take(i).ToArray();
                    float j = text.font.MeasureString(new string(selectedtextchr)).X + offsetx;

                    if (j >= Texture.Width)
                    {
                        lines.Add(new string(selectedtextchr));
                        offset += i;
                        i = 1;
                    }

                    if(i + offset == text.Text.Length)
                    {
                        lines.Add(new string(selectedtextchr = textchr.Skip(offset).Take(i).ToArray()));
                        text.Text = String.Join(Environment.NewLine, lines);
                        break;
                    }
                }
            }          
        }

        public void Update()
        {
            if(Position != new Vector2(text.Position.X+offsetx, text.Position.Y + offsety))
            {
                text.Position = new Vector2(Position.X + offsetx, Position.Y + offsety);
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            text.Draw(spriteBatch);
        }
    }
}

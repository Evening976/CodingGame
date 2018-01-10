using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CodingGame.Utils;

namespace CodingGame.Controls
{
    class Textbox
    {
        Texture2D Texture;
        public Vector2 Position;
        private float offsetx, offsety; //Position + offset = Text.Position;
        TextDrawer Text;

        public event EventHandler<KeyboardInput.KeyEventArgs> EnterDown;



        public Textbox(Vector2 Position)
        {
            Texture = Utils.Global.Load<Texture2D>("TextBoxBG");
            offsetx = 5; offsety = 2;
            Text = new TextDrawer(new Vector2(Position.X + offsetx, Position.Y + offsety), "");

            KeyboardInput.CharPressed += CharacterTyped;
            KeyboardInput.KeyPressed += KeyPressed;
            //KeyboardInput.Initialize(, 150, 1, true);
        }

        private void KeyPressed(object sender, KeyboardInput.KeyEventArgs e)
        {
           switch (e.KeyCode)
            {
                case Keys.Enter:
                    EnterDown?.Invoke(this, e);
                    break;
                case Keys.Left:
                    if (KeyboardInput.CtrlDown)
                    {
                        //Move cursor ((Ctrl + Left)
                    }
                    else
                    {
                        //Cursor--;
                    }
                    break;
                case Keys.Right:
                    if(KeyboardInput.CtrlDown)
                    {
                        //Move cursor ((Ctrl+Right))
                    }
                    else
                    {
                        //Cursor--;
                    }
                    break;
                case Keys.Home:
                    //Cursor = 0;
                    break;
                case Keys.Delete:
                    Text.Text = Text.Text.Remove(Text.Text.Length - 1, 1);
                    break;
                case Keys.Back:
                    if(Text.Text.Length > 0) Text.Text = Text.Text.Remove(Text.Text.Length - 1, 1);
                    break;
            }
        }

        public static bool IsLegalCharacter(char c)
        {
            return Utils.Global.Font.Characters.Contains(c) || c == '\r' || c == '\n';
        }

        private void CharacterTyped(object sender, KeyboardInput.CharacterEventArgs e)
        {
            if (!KeyboardInput.CtrlDown)
            {
                if (IsLegalCharacter(e.Character) && !e.Character.Equals('\r') &&
                    !e.Character.Equals('\n'))
                {
                    // DelSelection();

                    // Text.InsertCharacter(Cursor.TextCursor, e.Character);
                    //Cursor.TextCursor++;
                    Text.Text += e.Character.ToString();
                }
            }
        }

        public void Update()
        {
            if (Utils.Global.CurrKBState.GetPressedKeys().Length > 0
                && Utils.Global.LastKBState.GetPressedKeys() != Utils.Global.CurrKBState.GetPressedKeys())
            {

            }

            KeyboardInput.Update();
        }

        public void CharEntered(char c)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            Text.Draw(spriteBatch);
        }


    }
}


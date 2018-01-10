using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGame.Controls
{
    /// <summary>
    /// Curseur qui sert à selectionner du texte
    /// </summary>
    class Cursor
    {
        Vector2 Position;
        Texture2D Texture;
        Controls.TextDrawer text;

        public Cursor(TextDrawer Text)
        {
            text = Text;
            Position = text.Position;
        }

    }
}

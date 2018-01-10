using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingGame.Windows;
using Microsoft.Xna.Framework.Graphics;

namespace CodingGame.Windows
{
    public static class Manager
    {
       static List<Window> Windows;

        public static void InitManager()
        {
            Windows = new List<Window>();
        }


        public static void AddWindow(Window Window)
        {
            if(Windows.Count != 0)
            {
                foreach (Window w in Windows)
                {
                    if (w.Type != Window.Type)
                    {
                        Windows.Add(Window);
                    }
                }
            }
            else
            {
                Windows.Add(Window);
            }

        }

        public static void Update()
        {
                foreach (Window w in Windows)
                {
                    w.Update();
                    if (w.tokill == true)
                    {
                        Windows.Remove(w);
                    break;
                    }
                }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if(Windows.Count > 0)
            {
                foreach (Window w in Windows)
                {
                    w.Draw(spriteBatch);
                }
            }
        }


    }
}

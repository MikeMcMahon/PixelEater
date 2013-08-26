using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PixelEater.Core.Game.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game
{
    class PEGame
    {
        Sprite background = new Sprite();
        GameCursor mouseCursor = new GameCursor();

        public void LoadContent(GraphicsDevice device, ContentManager manager)
        {
            background.Texture = new Texture2D(device, 1, 1);
            background.Color = Color.White;
            background.Texture.SetData(new Color[] { background.Color });
            background.Position = new Vector2(0, 0);
            int width = device.Viewport.Width / 2;
            int height = device.Viewport.Height / 2;

            background.Size = new Rectangle(width - (width / 2), height - (height / 2), width, height);


            // center the mouse on screen
            Mouse.SetPosition(device.Viewport.Width / 2, device.Viewport.Height / 2);

            mouseCursor.Texture = new Texture2D(device, 1, 1);
            mouseCursor.Color = Color.DarkSalmon;
            mouseCursor.Texture.SetData(new Color[] { mouseCursor.Color });
            mouseCursor.Size = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 20, 20);

        }

        public void UnloadContent()
        {
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Begin();
            batch.Draw(background.Texture, background.Size, Color.White);

            if (mouseCursor.Show)
            {
                batch.Draw(mouseCursor.Texture, mouseCursor.Size, mouseCursor.Color);
            }
            batch.End();
        }

        Random rand = new Random();
        public void Update(GameTime gameTime)
        {
            mouseCursor.HandleInput(gameTime, null);
            mouseCursor.Update(gameTime);    
        }
    }
}

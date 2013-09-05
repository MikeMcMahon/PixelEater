using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PixelEater.Core.Game.Sprites;
using PixelEater.Core.Game.Sprites.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game
{
    class PEGame
    {
        internal Sprite background = new Sprite();
        internal GameCursor mouseCursor = new GameCursor();
        internal GameState _state = new GameState();
        internal MenuItem startGame = new MenuItem();

        public void LoadContent(GraphicsDevice device, ContentManager manager)
        {
            { // Background
                background.Texture = new Texture2D(device, 1, 1);
                background.Color = Color.White;
                background.Texture.SetData(new Color[] { Color.White });
                background.Position = new Vector2(0, 0);

                background.Size = new Rectangle(0, 0, device.Viewport.Width, device.Viewport.Height);
            }

            // center the mouse on screen
            Mouse.SetPosition(device.Viewport.Width / 2, device.Viewport.Height / 2);

            { // The mouse cursor
                mouseCursor.Texture = new Texture2D(device, 1, 1);
                mouseCursor.Color = Color.DarkSalmon;
                mouseCursor.Texture.SetData(new Color[] { mouseCursor.Color });
                mouseCursor.Size = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 20, 20);
                mouseCursor.WindowBounds = device.Viewport.Bounds; // the window bounds
            }

            { // Main menu sprites
                { // Start Game
                    startGame.Position = new Vector2(device.Viewport.Width / 2, device.Viewport.Height / 2);
                    startGame.Show = false;
                    startGame.Texture = new Texture2D(device, 1, 1);
                    startGame.Texture.SetData(new Color[] { Color.Black });
                    startGame.Color = Color.White;
                }
                { // load game
                }
                { // settings
                }
                { // high score
                }
            }

            _state.PushState(this, new SplashScreenState());

        }

        public void UnloadContent()
        {
        }

        Random rand = new Random();
        public void Update(GameTime gameTime)
        {

            mouseCursor.HandleInput(gameTime, null);
            mouseCursor.Update(gameTime);

            _state.HandleInput(this, gameTime, null);
            _state.Update(this, gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Begin();
            batch.Draw(background.Texture, background.Size, background.Color);

            if (startGame.Show)
            {
                batch.Draw(startGame.Texture, startGame.Size, startGame.Color);
            }

            if (mouseCursor.Show)
            {
                batch.Draw(mouseCursor.Texture, mouseCursor.Size, mouseCursor.Color);
            }
            batch.End();
        }
    }
}

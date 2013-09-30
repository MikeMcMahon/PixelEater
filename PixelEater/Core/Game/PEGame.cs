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
        internal MenuItem loadGame = new MenuItem();
        internal MenuItem settings = new MenuItem();
        internal MenuItem highScore = new MenuItem();

        internal Sprite[] _gameSprites = new Sprite[1024];
        private Matrix SpriteScale { get; set; }

        public void LoadContent(GraphicsDevice device, ContentManager manager)
        {
            // Default resolution is 800x600; scale sprites up or down based on
            // current viewport
            float screenscale =
                (float)device.Viewport.Width / 1366;
            // Create the scale transform for Draw. 
            // Do not scale the sprite depth (Z=1).
            SpriteScale = Matrix.CreateScale(screenscale, screenscale, 1);

            { // Background
                background.Texture = new Texture2D(device, 1, 1);
                background.Color = Color.White;
                background.Texture.SetData(new Color[] { Color.White });
                background.Bounds = new Rectangle(0, 0, device.Viewport.Width, device.Viewport.Height);
            }

            // center the mouse on screen
            Mouse.SetPosition(device.Viewport.Width / 2, device.Viewport.Height / 2);

            { // The mouse cursor
                mouseCursor.Texture = new Texture2D(device, 1, 1);
                mouseCursor.Color = Color.DarkSalmon;
                mouseCursor.Texture.SetData(new Color[] { mouseCursor.Color });
                mouseCursor.Bounds = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 20, 20);
                mouseCursor.WindowBounds = device.Viewport.Bounds; // the window bounds
                mouseCursor.CollisionWhenHidden = false;
            }

            { // Main menu sprites
                int height = 60;
                int width = 300;
                { // Start Game
                    startGame.Bounds = new Rectangle((device.Viewport.Width / 2) - 150, (device.Viewport.Height / 2) - (height / 2), width, height);
                    startGame.Show = false;
                    startGame.Texture = new Texture2D(device, 1, 1);
                    startGame.Texture.SetData(new Color[] { Color.Black });
                    startGame.Color = Color.White;
                    startGame.Highlight = Color.DarkOliveGreen;
                }
                { // load game
                    loadGame.Bounds = new Rectangle((device.Viewport.Width / 2) - 150, (device.Viewport.Height / 2) - (height / 2) + height + 10, width, height);
                    loadGame.Show = false;
                    loadGame.Texture = new Texture2D(device, 1, 1);
                    loadGame.Texture.SetData(new Color[] { Color.Black });
                    loadGame.Color = Color.White;
                    loadGame.Highlight = Color.Aqua;

                }
                { // settings
                    settings.Bounds = new Rectangle((device.Viewport.Width / 2) - 150, (device.Viewport.Height / 2) - (height / 2) + (height * 2) + (10 * 2), width, height);
                    settings.Show = false;
                    settings.Texture = new Texture2D(device, 1, 1);
                    settings.Texture.SetData(new Color[] { Color.Black });
                    settings.Color = Color.White;
                }
                { // high score
                    highScore.Bounds = new Rectangle((device.Viewport.Width / 2) - 150, (device.Viewport.Height / 2) - (height / 2) + (height * 3) + (10 * 3), width, height);
                    highScore.Show = false;
                    highScore.Texture = new Texture2D(device, 1, 1);
                    highScore.Texture.SetData(new Color[] { Color.Black });
                    highScore.Color = Color.White;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            
            // Pass handle to the states to begin drawing
            _state.Draw(this, spriteBatch);

            // always draw the mouse last... 
            mouseCursor.StateManager.Draw(mouseCursor, spriteBatch);
            spriteBatch.End();
        }
    }
}

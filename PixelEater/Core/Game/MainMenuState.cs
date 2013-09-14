using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelEater.Core.Game.Sprites;
using PixelEater.Core.Game.Sprites.Cursor;
using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game
{
    class MainMenuState : IStateObject<PEGame>
    {
        // Navigate about the menus.... 
        public void HandleInput(PEGame super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            super.startGame.HandleInput(gameTime, input);
            super.loadGame.HandleInput(gameTime, input);
            super.settings.HandleInput(gameTime, input);
            super.highScore.HandleInput(gameTime, input);
        }

        // Do update stuff... 
        public void Update(PEGame super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            super.startGame.Update(gameTime);
            super.loadGame.Update(gameTime);
            super.settings.Update(gameTime);
            super.highScore.Update(gameTime);
        }

        // Setup all of the resources to be shown 
        public void Enter(PEGame super)
        {
            super.mouseCursor.IgnoreInput = false;
            super.mouseCursor.StateManager.PushState(super.mouseCursor, new VisibleCursorState());

            super.background.Color = Color.White;
            super.background.Texture.SetData(new Color[] { Color.Purple });

            super.startGame.Show = true;
            super.loadGame.Show = true;
            super.settings.Show = true;
            super.highScore.Show = true;
        }

        // hide all of the resources we don't need to show anymore
        public void Exit(PEGame super)
        {
            
        }


        public void Draw(PEGame super, SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, super.background);

            super.loadGame.Draw(spriteBatch);
            super.startGame.Draw(spriteBatch);
            super.settings.Draw(spriteBatch);
            super.highScore.Draw(spriteBatch);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        }

        // Do update stuff... 
        public void Update(PEGame super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            super.startGame.Update(gameTime);
        }

        // Setup all of the resources to be shown 
        public void Enter(PEGame enter)
        {
            enter.mouseCursor.IgnoreInput = false;
            enter.mouseCursor._state.PushState(enter.mouseCursor, new VisibleCursorState());

            enter.background.Color = Color.White;
            enter.background.Texture.SetData(new Color[] { Color.Purple });

            enter.startGame.Show = true;
        }

        // hide all of the resources we don't need to show anymore
        public void Exit(PEGame exit)
        {
            
        }
    }
}

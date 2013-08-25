using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game.Sprites.Cursor
{
    class HiddenCursorState : IStateObject<GameCursor>
    {
        double ellapsedTime = 0.0d;
        public void HandleInput(GameCursor super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            // return to the previous state
            if (Mouse.GetState().RightButton == ButtonState.Pressed & ellapsedTime > 1000.0d)
            {
                super._state.PopState(super);
                ellapsedTime = 0;
            }

            ellapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds; 
        }

        public void Update(GameCursor super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            super.Show = false;
            // Keep the mouse cursor moving/updating :) 
            super.Size = new Rectangle(
                Mouse.GetState().X,
                Mouse.GetState().Y,
                super.Size.Width,
                super.Size.Height);
        }

        public void Enter(GameCursor enter)
        {
            return;
        }

        public void Exit(GameCursor exit)
        {
            return;
        }
    }
}

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
    class HiddenCursorState : InvisibleState<GameCursor>
    {
        double ellapsedTime = 0.0d;
        public override void HandleInput(GameCursor super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            if (super.IgnoreInput)
            {
                return;
            }
            // return to the previous state
            if (Mouse.GetState().RightButton == ButtonState.Pressed & ellapsedTime > 1000.0d)
            {
                super.StateManager.PopState(super);
                ellapsedTime = 0;
            }

            ellapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            base.HandleInput(super, gameTime, input);
        }

        public override void Update(GameCursor super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            // Keep the mouse cursor moving/updating :) 
            super.Bounds = new Rectangle(
                Mouse.GetState().X,
                Mouse.GetState().Y,
                super.Bounds.Width,
                super.Bounds.Height);
            base.Update(super, gameTime);
        }

        public override void Enter(GameCursor enter)
        {
            base.Enter(enter);
        }

        public override void Exit(GameCursor exit)
        {
            base.Exit(exit);
        }
    }
}

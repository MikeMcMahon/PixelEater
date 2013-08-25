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
    class VisibleCursorState : IStateObject<GameCursor>
    {
        Random rand = new Random();
        double prevClickTime = 0.0f;
        double ellapsedTime = 0.0f;
        ButtonState prevState = ButtonState.Released; 
        public void HandleInput(GameCursor super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed & prevClickTime > 500f & prevState == ButtonState.Released)
            {
                // just for funsies we put a random color on the screen! 
                super.Color = new Color(1 + rand.Next() % 255, 1 + rand.Next() % 255, 1 + rand.Next() % 255);
                super.Texture.SetData(new Color[] { super.Color });
                super.Size = new Rectangle(
                    Mouse.GetState().X,
                    Mouse.GetState().Y,
                    1 + rand.Next() % 20,
                    1 + rand.Next() % 20);
                prevClickTime = 0;
            }

            if (Mouse.GetState().RightButton == ButtonState.Pressed & ellapsedTime > 1000)
            {
                super._state.PushState(super, new HiddenCursorState());
                ellapsedTime = 0;
            }

            ellapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds; 
            prevState = Mouse.GetState().LeftButton; 
            prevClickTime += gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void Update(GameCursor super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            super.Show = true;
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

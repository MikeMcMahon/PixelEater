using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
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
        int prevX = 0;
        int prevY = 0; 
        ButtonState prevState = ButtonState.Released;
        public void HandleInput(GameCursor super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            if (super.IgnoreInput)
            {
                return;
            }

            { // detecting touch 
                var touches = TouchPanel.GetState();

                if (touches.Count > 0 && touches[0].State == TouchLocationState.Pressed)
                {
                    // pop the state
                    super.Show = false;
                }
            }

            { // handling mouse input
                // If we detect any mouse movement or button press then show the mouse
                if (prevX != Mouse.GetState().X |
                    prevY != Mouse.GetState().Y |
                    Mouse.GetState().LeftButton == ButtonState.Pressed |
                    Mouse.GetState().RightButton == ButtonState.Pressed)
                {
                    this.Enter(super);
                }
                prevX = Mouse.GetState().X;
                prevY = Mouse.GetState().Y;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed & prevClickTime > 500f & prevState == ButtonState.Released)
                {
                    // just for funsies we put a random color on the screen! 
                    super.Color = new Color(1 + rand.Next() % 255, 1 + rand.Next() % 255, 1 + rand.Next() % 255);
                    super.Texture.SetData(new Color[] { super.Color });
                    super.Bounds = new Rectangle(
                        0,
                        0,
                        1 + rand.Next() % 20,
                        1 + rand.Next() % 20);
                    prevClickTime = 0;
                }

                if (Mouse.GetState().RightButton == ButtonState.Pressed & ellapsedTime > 1000)
                {
                    super.StateManager.PushState(super, new HiddenCursorState());
                    ellapsedTime = 0;
                }

                ellapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
                prevState = Mouse.GetState().LeftButton;
                prevClickTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }


        public void Update(GameCursor super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            // Keep the mouse cursor moving/updating :) 
            super.Bounds = new Rectangle(
                Mouse.GetState().X,
                Mouse.GetState().Y,
                super.Bounds.Width,
                super.Bounds.Height);
        }

        public void Enter(GameCursor enter)
        {
            if (!enter.Show) { enter.Show = true; }
        }

        public void Exit(GameCursor exit)
        {
            return;
        }


        public void Draw(GameCursor super, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, super);
        }
    }
}

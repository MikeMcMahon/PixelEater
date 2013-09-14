using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PixelEater.Core.State;
using PixelEater.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game.Sprites.MainMenu
{
    class HoverMenuItemState : IStateObject<MenuItem>
    {
        int mouseX = 0;
        int mouseY = 0;
        public void HandleInput(MenuItem super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            { // mouse input
                mouseX = Mouse.GetState().X;
                mouseY = Mouse.GetState().Y;

                if (CollisionDetection.RectangleCollision(super.Bounds, new Microsoft.Xna.Framework.Point(mouseX, mouseY)))
                {
                    super.Texture.SetData(new Color[] { super.Highlight });
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        super.Texture.SetData(new Color[] { super.Active });
                    }
                }
                else
                {
                    super.Texture.SetData(new Color[] { super.Default });
                }
            }
            { // handle the touch input
            }
        }

        public void Update(MenuItem super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            // update the gfx colors based on the state handled from the input
        }

        public void Enter(MenuItem enter)
        {
            //
        }

        public void Exit(MenuItem exit)
        {
            // 
        }


        public void Draw(MenuItem super, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, super);
        }
    }
}

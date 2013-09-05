using Microsoft.Xna.Framework.Input;
using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game.Sprites.MainMenu
{
    class HoverMenuItemState : IStateObject<MenuItem>
    {

        public void HandleInput(MenuItem super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            { // handle mouse over
                
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
    }
}

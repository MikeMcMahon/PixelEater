using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game
{
    class MainMenuState : IStateObject<Game>
    {
        // Navigate about the menus.... 
        public void HandleInput(Game super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            throw new NotImplementedException();
        }

        // Do update stuff... 
        public void Update(Game super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        // Setup all of the resources to be shown 
        public void Enter(Game enter)
        {
            throw new NotImplementedException();
        }

        // hide all of the resources we don't need to show anymore
        public void Exit(Game exit)
        {
            throw new NotImplementedException();
        }
    }
}

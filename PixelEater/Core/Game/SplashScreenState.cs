using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game
{
    class SplashScreenState : IStateObject<Game>
    {
        // Ignore all input
        public void HandleInput(Game super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            // Ignore all input
        }

        // Set the background and fade in from black
        // After 2 seconds go to the main game screen
        public void Update(Game super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Enter(Game enter)
        {
            // Do nothing
        }

        public void Exit(Game exit)
        {
            // cleanup or hide resources... 
        }
    }
}

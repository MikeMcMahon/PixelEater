using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game
{
    /// <summary>
    /// My controversial loading "state" hmmmmm 
    /// </summary>
    class LoadingScreenState : IStateObject<PEGame>
    {
        // Should take a structure of what sprites to prepare, and where to place them, maybe even what textures to load...etc anything like that
        public LoadingScreenState() { }
        public void HandleInput(PEGame super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            //throw new NotImplementedException();
        }

        public void Update(PEGame super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            //throw new NotImplementedException();
        }

        public void Enter(PEGame enter)
        {
            // nothing fancy
        }

        public void Exit(PEGame exit)
        {
            // nothing fancy
        }
    }
}

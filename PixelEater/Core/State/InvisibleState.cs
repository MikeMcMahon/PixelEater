using PixelEater.Core.Game.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.State
{
    class InvisibleState<T> : IStateObject<T> where T : Sprite
    {

        public virtual void HandleInput(T super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            return;
        }

        public virtual void Update(T super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (super.Show)
            {
                super.Show = false;
            }
        }

        public virtual void Enter(T enter)
        {
            return;
        }

        public virtual void Exit(T exit)
        {
            return;
        }
    }
}

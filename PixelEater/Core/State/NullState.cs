using PixelEater.Core.Game.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.State
{
    class NullState<K> : IStateObject<K> 
        where K : Sprite
    {

        public void HandleInput(K super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            // do nothing
        }

        public void Update(K super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            // do nothing
        }

        public void Draw(K super, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            // do nothing
        }

        public void Enter(K super)
        {
            // do nothing
        }

        public void Exit(K super)
        {
            // 
        }
    }
}

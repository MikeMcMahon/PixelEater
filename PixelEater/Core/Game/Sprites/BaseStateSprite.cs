using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelEater.Core.State;
using PixelEater.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game.Sprites
{
    class BaseStateSprite<K> : Sprite
        where K : Sprite
    {
        public BaseStateSprite()
        {
            StateManager = new BaseState<K, IStateObject<K>>();
            StateManager.PushState((K)(Sprite)this, new NullState<K>());
        }

        internal virtual BaseState<K, IStateObject<K>> StateManager { get; set; }

        public virtual void HandleInput(GameTime gameTime, IPEGameInput input)
        {
            throw new NotImplementedException("base sprites do nothing!");
        }
        public virtual void Update(GameTime gameTime)
        {
            throw new NotImplementedException("base sprites do nothing!");
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException("Base sprites do nothing!");
        }
    }
}

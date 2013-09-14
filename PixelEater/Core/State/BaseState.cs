using PixelEater.Core.Game.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.State
{
    /// <summary>
    /// Provides the most basic of implementations for a state manager for a sprite... 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="Y"></typeparam>
    class BaseState<K,Y> : IState<K> 
        where K : Sprite
        where Y : IStateObject<K>
    {

        private IList<Y> _state = new List<Y>();

        public virtual void HandleInput(K super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            if (_state.Count > 0) _state.Last().HandleInput(super, gameTime, input);
        }

        public virtual void Update(K super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (_state.Count > 0) _state.Last().Update(super, gameTime);
        }

        public virtual void Draw(K super, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            if (_state.Count > 0) _state.Last().Draw(super, spriteBatch);
        }

        public virtual void PushState(K super, IStateObject<K> state)
        {
            if (_state.Count > 0) _state.Last().Exit(super);
            _state.Add((Y) state);
            _state.Last().Enter(super);
        }

        public virtual void PopState(K super)
        {
            if (_state.Count > 0)
            {
                _state.Last().Exit(super);
                _state.RemoveAt(_state.Count - 1);

                if (_state.Count > 0) _state.Last().Enter(super);
            }
        }

    }
}

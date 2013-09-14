using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game.Sprites.MainMenu
{
    class MenuItemState : IState<MenuItem>
    {
        internal List<IStateObject<MenuItem>> _state = new List<IStateObject<MenuItem>>();

        public void HandleInput(MenuItem super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            if (_state.Count < 0)
            {
                return;
            }

            _state.Last().HandleInput(super, gameTime, input);
        }

        public void Update(MenuItem super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (_state.Count < 0)
            {
                return;
            }

            _state.Last().Update(super, gameTime);
        }

        public void PushState(MenuItem super, IStateObject<MenuItem> state)
        {
            if (_state.Count > 0)
            {
                _state.Last().Exit(super);
            }
            _state.Add(state);
            _state.Last().Enter(super);
        }

        public void PopState(MenuItem super)
        {
            if (_state.Count > 0)
            {
                _state.Last().Exit(super);
                _state.RemoveAt(_state.Count - 1);
            }
        }

        public void Draw(MenuItem super, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            if (_state.Last() != null)
            {
                _state.Last().Draw(super, spriteBatch);
            }
        }
    }
}

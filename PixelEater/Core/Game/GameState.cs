﻿using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game
{
    class GameState : IState<PEGame>
    {
        List<IStateObject<PEGame>> _state = new List<IStateObject<PEGame>>();

        public void HandleInput(PEGame super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            _state.Last().HandleInput(super, gameTime, input);
        }

        public void Update(PEGame super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            _state.Last().Update(super, gameTime);
        }

        public void PushState(PEGame super, IStateObject<PEGame> state)
        {
            if (_state.Count > 0)
            {
                _state.Last().Exit(super);
            }
            _state.Add(state);
            _state.Last().Enter(super);
        }

        public void PopState(PEGame super)
        {
            // there are no states to pop
            if (_state.Count() == 0)
            {
                return;
            }
            _state.Last().Exit(super);
            _state.RemoveAt(_state.Count - 1);

            // re-enter any remaining state
            if (_state.Count() > 0)
            {
                _state.Last().Enter(super);
            }
        }


        public void Draw(PEGame super, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            if (_state.Last() != null) _state.Last().Draw(super, spriteBatch);
        }
    }
}

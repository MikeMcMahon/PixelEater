using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game
{
    class GameState : IState<Game>
    {
        List<IStateObject<Game>> _state = new List<IStateObject<Game>>();

        public void HandleInput(Game super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            _state.Last().HandleInput(super, gameTime, input);
        }

        public void Update(Game super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            _state.Last().Update(super, gameTime);
        }

        public void PushState(Game super, IStateObject<Game> state)
        {
            _state.Last().Exit(super);
            _state.Add(state);
            _state.Last().Enter(super);
        }

        public void PopState(Game super)
        {
            _state.Last().Exit(super);
            _state.RemoveAt(_state.Count);
            _state.Last().Enter(super);
        }
    }
}

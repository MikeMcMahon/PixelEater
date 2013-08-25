using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game.Sprites.Cursor
{
    class CursorState : IState<GameCursor>
    {
        List<IStateObject<GameCursor>> _state = new List<IStateObject<GameCursor>>();

        public CursorState()
        {
            _state.Add(new VisibleCursorState());
        }

        public void HandleInput(GameCursor super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            _state.Last().HandleInput(super, gameTime, null);
        }

        public void Update(GameCursor super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            _state.Last().Update(super, gameTime);
        }

        public void PushState(GameCursor super, IStateObject<GameCursor> state)
        {
            _state.Add(state);
        }

        public void PopState(GameCursor super)
        {
            _state.RemoveAt(_state.Count - 1);
        }
    }
}

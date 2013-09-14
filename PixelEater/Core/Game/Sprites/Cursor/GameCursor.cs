using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PixelEater.Core.Game.Sprites.Cursor;
using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game.Sprites
{
    class GameCursor : BaseStateSprite<GameCursor>
    {
        public GameCursor()
        {
            base.StateManager = new BaseState<GameCursor, IStateObject<GameCursor>>();
            base.StateManager.PushState(this, new VisibleCursorState());
        }
        
        public override void HandleInput(GameTime gameTime, Input.IPEGameInput input)
        {
            base.StateManager.HandleInput(this, gameTime, input);
        }

        public override void Update(GameTime gameTime)
        {
            base.StateManager.Update(this, gameTime);
        }
    }
}

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
    class GameCursor : Sprite
    {
        Random rand = new Random();
        internal CursorState _state = new CursorState();
        public override void HandleInput(GameTime gameTime, Input.IPEGameInput input)
        {
            _state.HandleInput(this, gameTime, input);
        }

        public override void Update(GameTime gameTime)
        {
            _state.Update(this, gameTime);
        }
    }
}

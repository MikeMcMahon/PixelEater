using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game.Sprites.PixelEater
{
    class PixelEater : BaseStateSprite<PixelEater>
    {

        public PixelEater()
        {
            base.Bounds = new Rectangle(0, 0, 32, 32);
            base.Color = Color.White;
            base.StateManager = new State.BaseState<PixelEater, State.IStateObject<PixelEater>>();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            StateManager.Update(this, gameTime);
        }

        public override void HandleInput(Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            StateManager.HandleInput(this, gameTime, input);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            StateManager.Draw(this, spriteBatch);
        }
    }
}

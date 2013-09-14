using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game.Sprites.MainMenu
{
    class MenuItem : BaseStateSprite<MenuItem>
    {
        public MenuItem()
        {
            base.Bounds = new Rectangle(0, 0, 400, 30);
            base.Color = Color.White;
            this.Highlight = Color.White;
            this.Default = Color.Black;
            this.Active = Color.Green;

            // Default state for a menu item
            StateManager = new BaseState<MenuItem, IStateObject<MenuItem>>();
            StateManager.PushState(this, new HoverMenuItemState());
        }

        public Color Highlight { get; set; }
        public Color Active { get; set; }
        public Color Default { get; set; }


        public override void HandleInput(Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input) {
            StateManager.HandleInput(this, gameTime, input);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            StateManager.Update(this, gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            StateManager.Draw(this, spriteBatch);
        }
    }
}

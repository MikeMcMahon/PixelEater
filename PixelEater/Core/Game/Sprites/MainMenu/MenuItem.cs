using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game.Sprites.MainMenu
{
    class MenuItem : Sprite
    {
        public MenuItem()
        {
            base.Size = new Rectangle(0, 0, 400, 30);
            base.Color = Color.White;

            // Default state for a menu item
            _state.PushState(this, new HoverMenuItemState()); 
        }

        MenuItemState _state = new MenuItemState();

        public override void HandleInput(Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input){
            _state.HandleInput(this, gameTime, input);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            _state.Update(this, gameTime);
        } 
    }
}

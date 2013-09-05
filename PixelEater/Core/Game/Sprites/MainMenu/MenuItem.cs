using Microsoft.Xna.Framework;
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
            base.Bounds = new Rectangle(0, 0, 400, 30);
            base.Color = Color.White;
        }

        public override void HandleInput(Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
        } 
    }
}

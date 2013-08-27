using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelEater.Core.State;
using PixelEater.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game.Sprites
{
    class Sprite : IDisposable
    {
        public Sprite()
        {
            // Should register itself with the spritedisposer that will handle disposing of and cleaning up all sprites... 
        }
        public string Name { get; set; }
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Size { get; set; }
        public bool Show { get; set; }
        public void HandleInput(IPEGameInput input) { }
        public void Update() { }

        /// <summary>
        /// Cleanup the sprite resource
        /// </summary>
        public void Dispose()
        {
            if (this.Texture != null)
            {
                this.Texture.Dispose();
            }
        }
    }
}

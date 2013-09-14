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
            this.IgnoreInput = false;
            this.Show = true;
            this.Color = Color.White;
            this.Name = "Sprite"; // needs to be set... 
        }

        public string Name { get; set; }
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }
        public Rectangle Bounds { get; set; }
        public bool Show { get; set; }
        public bool IgnoreInput { get; set; }
        public bool CollisionWhenHidden { get; set; }
        public Rectangle WindowBounds { get; set; }

        public virtual void HandleInput(GameTime gameTime, IPEGameInput input)
        {
            throw new NotImplementedException("Base sprites do nothing!");
        }
        public virtual void Update(GameTime gameTime)
        {
            throw new NotImplementedException("base sprites do nothing!");
        }

        // Generic draw that can be overriden
        public static void Draw(SpriteBatch spriteBatch, Sprite sprite)
        {
            if (sprite.Show)
            {
                spriteBatch.Draw(sprite.Texture, sprite.Bounds, sprite.Color);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException("Base sprites do nothing!");
        }

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

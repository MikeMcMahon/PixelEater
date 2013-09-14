using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelEater.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.State
{
    interface IStateObject<T>
    {
        void HandleInput(T super, GameTime gameTime, IPEGameInput input);
        void Update(T super, GameTime gameTime);
        void Draw(T super, SpriteBatch spriteBatch);
        void Enter(T super);
        void Exit(T super); 
    }
}

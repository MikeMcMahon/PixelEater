using Microsoft.Xna.Framework;
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
        void Enter(T enter);
        void Exit(T exit); 
    }
}

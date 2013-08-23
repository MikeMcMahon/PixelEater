using Microsoft.Xna.Framework;
using PixelEater.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.State
{
    interface IState<T>
    {
        void HandleInput(T super, GameTime gameTime, IPEGameInput input);
        void Update(T super, GameTime gameTime);
        void PushState(T super, IStateObject<T> state);
        void PopState(T super);
    }
}

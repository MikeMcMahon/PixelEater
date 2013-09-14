using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game.Sprites
{
    class BaseStateSprite<K> : Sprite
        where K : Sprite
    {
        internal virtual BaseState<K, IStateObject<K>> StateManager { get; set; }
    }
}

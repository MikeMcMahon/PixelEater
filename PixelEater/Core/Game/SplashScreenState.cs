using Microsoft.Xna.Framework;
using PixelEater.Core.Game.Sprites.Cursor;
using PixelEater.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Game
{
    // Fade in from black
    // show for 3 seconds
    // fade out to black
    class SplashScreenState : IStateObject<PEGame>
    {
        // ignore input, so don't pass to any children sprites... 
        public void HandleInput(PEGame super, Microsoft.Xna.Framework.GameTime gameTime, Input.IPEGameInput input)
        {
            
            
        }

        // fade from black over 1 sec, show for 3 sec, fade over 500ms to black
        float lastRgb = 0;
        double timeElapseTotal = 0;
        float fadeTime = 2500;
        bool fadeIn = true;
        bool fadeOut = false;
        public void Update(PEGame super, Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (fadeIn)
            {
                if (timeElapseTotal <= fadeTime)
                {
                    lastRgb = (float)(255 * ((float)timeElapseTotal / fadeTime)) / 100;
                    lastRgb = (float)Math.Round(lastRgb, 2);
                    timeElapseTotal += gameTime.ElapsedGameTime.TotalMilliseconds;
                }
                else
                {
                    lastRgb = 1.0f;
                    timeElapseTotal = 0;
                    fadeIn = false;
                }
            }

            if (!fadeIn && !fadeOut)
            {
                if (timeElapseTotal <= 3000)
                {
                    // wait three seconds
                    timeElapseTotal += gameTime.ElapsedGameTime.TotalMilliseconds;
                }
                {
                    fadeOut = true;
                }
            }

            if (fadeOut)
            {
                if (timeElapseTotal <= fadeTime)
                {
                    lastRgb = (float)1 - ((255 * ((float)timeElapseTotal / fadeTime)) / 100);
                    lastRgb = (float)Math.Round(lastRgb, 2);
                    timeElapseTotal += gameTime.ElapsedGameTime.TotalMilliseconds;
                }
                else
                {
                    // time to leave this state and go to a loading screen!
                    super._state.PopState(super);
                    super._state.PushState(super, new MainMenuState());
                }
            }

            Color bgColor = new Color(lastRgb, lastRgb, lastRgb, 1);
            super.background.Texture.SetData(new Color[] { bgColor });
            //super.background.Color = bgColor;
        }

        public void Enter(PEGame enter)
        {
            // hide the mouse cursor
            enter.mouseCursor._state.PushState(enter.mouseCursor, new HiddenCursorState());
            enter.mouseCursor.IgnoreInput = true;
            enter.background.Texture.SetData(new Color[] { Color.Black });
        }

        public void Exit(PEGame exit)
        {
            // cleanup or hide resources... 
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEater.Core.Util
{
    class CollisionDetection
    {
        public static bool RectangleCollision(Rectangle rect1, Rectangle rect2)
        {
            // we know that the x coord is somewhere within the bounds
            if (rect1.X <= rect2.X && rect1.X + rect1.Width >= rect2.X)
            {
                if (rect1.Y <= rect2.Y && rect1.Y + rect1.Height >= rect2.Y)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool RectangleCollision(Rectangle rect1, Point p)
        {
            // we know that the x coord is somewhere within the bounds
            if (rect1.X <= p.X && rect1.X + rect1.Width >= p.X)
            {
                if (rect1.Y <= p.Y && rect1.Y + rect1.Height >= p.Y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

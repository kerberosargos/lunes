using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BitmapPlayground.Filters
{
    /// <summary>
    /// Filters the red component from an image.
    /// </summary>
    public class MovingAvarageFilter : IFilter
    {
        public Color[,] Apply(Color[,] input)
        {
            int width = input.GetLength(0);
            int height = input.GetLength(1);
            Color[,] result = new Color[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var left = 0;
                    var right = 0;

                    if (x > 0 && x <= (width-4))
                    {
                        left = x - 4;
                        right = x + 4;
                    }
                    else
                    {
                        left = x;
                        right = x;
                    }

                    var top = 0;
                    var bottom = 0;

                    if (y > 4 && y < (height-4))
                    {
                        top = y - 4;
                        bottom = y + 4;
                    }
                    else
                    {
                        top = y;
                        bottom = y;

                    }


                    var p = input[((left + right) / 2), ((top + bottom) / 2)];
                    result[x, y] = Color.FromArgb(p.A, p.R, p.G, p.B);
                }
            }

            return result;
        }

        public string Name => "Moving Avarage Filter";

        public override string ToString()
            => Name;
    }
}

using System.Drawing;
using System.Drawing.Drawing2D;

namespace PixelModdingFramework
{
    public static partial class Rendering
    {
        /// <summary>
        /// Scales an image up
        /// </summary>
        /// <param name="i">Source image</param>
        /// <param name="scale">Scale multiplier</param>
        /// <param name="mode">How the upscale will look</param>
        /// <returns>The upscaled image</returns>
        public static Image ScaleImage(Image i, int scale, InterpolationMode mode = InterpolationMode.NearestNeighbor)
        {
            Bitmap o = new Bitmap(i.Width * scale, i.Height * scale);
            using (Graphics g = Graphics.FromImage(o))
            {
                g.InterpolationMode = mode;
                g.DrawImage(i, 0, 0, o.Width, o.Height);
            }
            return o;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PixelModdingFramework
{
    public static partial class Rendering
    {

        public const int TilesetWidth = 16;
        public const int TilesetHeight = 16;

	         #region Byte
	    public static Image RenderTiles<T>(IMap<Int16, T, Byte> tileSource, Bitmap tileset, int tileSize, CompositingMode mode = CompositingMode.SourceOver) where T : IList<Byte>
        {
            Image img = new Bitmap(tileSource.Width * tileSize, tileSource.Height * tileSize);
            RenderTiles(img, tileSource, tileset, tileSize, mode);
            return img;
        }
        public static void RenderTiles<T>(Image i, IMap<Int16, T, Byte> tileSource, Bitmap tileset, int tileSize, CompositingMode mode = CompositingMode.SourceOver) where T : IList<Byte>
        {
            using(Graphics g = Graphics.FromImage(i))
            {
                g.CompositingMode = mode;
                RenderTiles(g, tileSource, tileset, tileSize);
            }
        }
        public static void RenderTiles<T>(Graphics g, IMap<Int16, T, Byte> tileSource, Bitmap tileset, int tileSize) where T : IList<Byte>
        {
            for (int i = 0; i < (tileSource.Width * tileSource.Height); i++)
            {
                                DrawTile(g, tileSource, i, tileset, tileSize);
            }
        }

        public static void DrawTile<T>(Image img, IMap<Int16, T, Byte> tileSource, int i, Bitmap tileset, int tileSize, CompositingMode mode = CompositingMode.SourceOver) where T : IList<Byte>
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                g.CompositingMode = mode;
                DrawTile(g, tileSource, i, tileset, tileSize);
            }
        }
        public static void DrawTile<T>(Graphics g, IMap<Int16, T, Byte> tileSource, int i, Bitmap tileset, int tileSize) where T : IList<Byte>
        {
            var x = (i % tileSource.Width) * tileSize;
            var y = (i / tileSource.Width) * tileSize;
            g.DrawImage(GetTile((Byte)tileSource.Tiles[i], tileset, tileSize), x, y, tileSize, tileSize);
        }

        #endregion Byte

                #region Nullable<Byte>
	    public static Image RenderTiles<T>(IMap<Int16, T, Nullable<Byte>> tileSource, Bitmap tileset, int tileSize, CompositingMode mode = CompositingMode.SourceOver) where T : IList<Nullable<Byte>>
        {
            Image img = new Bitmap(tileSource.Width * tileSize, tileSource.Height * tileSize);
            RenderTiles(img, tileSource, tileset, tileSize, mode);
            return img;
        }
        public static void RenderTiles<T>(Image i, IMap<Int16, T, Nullable<Byte>> tileSource, Bitmap tileset, int tileSize, CompositingMode mode = CompositingMode.SourceOver) where T : IList<Nullable<Byte>>
        {
            using(Graphics g = Graphics.FromImage(i))
            {
                g.CompositingMode = mode;
                RenderTiles(g, tileSource, tileset, tileSize);
            }
        }
        public static void RenderTiles<T>(Graphics g, IMap<Int16, T, Nullable<Byte>> tileSource, Bitmap tileset, int tileSize) where T : IList<Nullable<Byte>>
        {
            for (int i = 0; i < (tileSource.Width * tileSource.Height); i++)
            {
                                DrawTile(g, tileSource, i, tileset, tileSize);
            }
        }

        public static void DrawTile<T>(Image img, IMap<Int16, T, Nullable<Byte>> tileSource, int i, Bitmap tileset, int tileSize, CompositingMode mode = CompositingMode.SourceOver) where T : IList<Nullable<Byte>>
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                g.CompositingMode = mode;
                DrawTile(g, tileSource, i, tileset, tileSize);
            }
        }
        public static void DrawTile<T>(Graphics g, IMap<Int16, T, Nullable<Byte>> tileSource, int i, Bitmap tileset, int tileSize) where T : IList<Nullable<Byte>>
        {
            var x = (i % tileSource.Width) * tileSize;
            var y = (i / tileSource.Width) * tileSize;
            g.DrawImage(GetTile((Byte)tileSource.Tiles[i], tileset, tileSize), x, y, tileSize, tileSize);
        }

        #endregion Nullable<Byte>

        
        /// <summary>
        /// Gets a single tile from a tileset
        /// </summary>
        /// <param name="tileSource"></param>
        /// <param name="i"></param>
        /// <param name="tileset"></param>
        /// <param name="tileSize"></param>
        /// <returns></returns>
        public static Image GetTile(Byte tileValue, Bitmap tileset, int tileSize)
        {
            //yes, this is intentional to not use TilesetHeight
            var tilesetX = (tileValue % TilesetWidth) * tileSize;
            var tilesetY = (tileValue / TilesetWidth) * tileSize;
            return tileset.Clone(new Rectangle(tilesetX, tilesetY, tileSize, tileSize), PixelFormat.DontCare);
        }

		}
}
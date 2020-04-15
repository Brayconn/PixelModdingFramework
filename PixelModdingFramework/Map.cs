using System.Collections.Generic;

namespace PixelModdingFramework
{
    public interface IMap<T> where T : IList<byte>
    {
        short Width { get; set; }
        short Height { get; set; }
        T Tiles { get; set; }
    }
}

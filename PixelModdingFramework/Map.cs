using System.Collections.Generic;

namespace PixelModdingFramework
{
    public interface IMap<T> where T : IList<byte>
    {
        short Width { get; }
        short Height { get; }
        T Tiles { get; }
    }
}

using System.Collections.Generic;

namespace PixelModdingFramework
{
    public interface IMap<S,L,T> where L : IList<T>
    {
        S Width { get; }
        S Height { get; }
        L Tiles { get; }
    }
}

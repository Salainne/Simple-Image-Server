using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_image_server.Model
{
    public class ImageCache
    {
        private readonly Dictionary<ImageCacheKey, byte[]> _cache = new Dictionary<ImageCacheKey, byte[]>();
        private readonly long _maxMemoryBytes;
        private long _currentMemoryBytes;

        public ImageCache(long maxMemoryBytes = 500L * 1024 * 1024) // 500 MB
        {
            _maxMemoryBytes = maxMemoryBytes;
        }

        public byte[] GetOrAdd(string filePath, bool cropToSquare, int width, Func<byte[]> valueFactory)
        {
            var key = new ImageCacheKey(filePath, cropToSquare, width);

            byte[] cachedBytes;
            if (_cache.TryGetValue(key, out cachedBytes))
            {
                return cachedBytes;
            }

            var bytes = valueFactory();

            if (bytes == null) return null;

            if (_currentMemoryBytes + bytes.LongLength > _maxMemoryBytes)
            {
                _cache.Clear();
                _currentMemoryBytes = 0;
            }

            _cache[key] = bytes;
            _currentMemoryBytes += bytes.LongLength;

            return bytes;
        }

        public void Clear()
        {
            _cache.Clear();
            _currentMemoryBytes = 0;
        }

        public int Count
        {
            get { return _cache.Count; }
        }

        public long CurrentMemoryUsage
        {
            get { return _currentMemoryBytes; }
        }
    }
}

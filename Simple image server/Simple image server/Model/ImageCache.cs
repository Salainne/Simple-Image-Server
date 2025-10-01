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
        private long _maxMemoryBytes;
        private long _currentMemoryBytes;

        public ImageCache(long maxMemoryBytes = 500L * 1024 * 1024) // 500 MB
        {
            _maxMemoryBytes = maxMemoryBytes;
        }

        public void SetMaxMemoryBytes(long maxMemoryBytes)
        {
            if (maxMemoryBytes <= 0) throw new ArgumentOutOfRangeException(nameof(maxMemoryBytes), "Max memory bytes must be greater than zero.");
            _maxMemoryBytes = maxMemoryBytes;
            if (_currentMemoryBytes > _maxMemoryBytes)
            {
                _cache.Clear();
                _currentMemoryBytes = 0;
            }
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

        public override string ToString()
        {
            return string.Format("Current memory use: {0}. {1:P}", BytesToReadableSize(_currentMemoryBytes), ((decimal)_currentMemoryBytes / _maxMemoryBytes));
        }

        public static string BytesToReadableSize(long bytes)
        {
            string[] størrelser = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            double len = bytes;
            int orden = 0;

            while (len >= 1024 && orden < størrelser.Length - 1)
            {
                orden++;
                len /= 1024;
            }

            return $"{len:0.##} {størrelser[orden]}";
        }
    }
}

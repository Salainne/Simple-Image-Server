using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_image_server.Model
{
    public class ImageCacheKey
    {
        public string FilePath { get; private set; }
        public bool CropToSquare { get; private set; }
        public int Width { get; private set; }

        public ImageCacheKey(string filePath, bool cropToSquare, int width)
        {
            FilePath = filePath;
            CropToSquare = cropToSquare;
            Width = width;
        }

        public override bool Equals(object obj)
        {
            var other = obj as ImageCacheKey;
            if (other == null) return false;

            return string.Equals(FilePath, other.FilePath, StringComparison.OrdinalIgnoreCase)
                   && CropToSquare == other.CropToSquare
                   && Width == other.Width;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (FilePath != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(FilePath) : 0);
                hash = hash * 23 + CropToSquare.GetHashCode();
                hash = hash * 23 + Width.GetHashCode();
                return hash;
            }
        }
    }

}

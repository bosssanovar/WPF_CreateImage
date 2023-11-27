using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class GridImage
    {
        #region Constants -------------------------------------------------------------------------------------

        private const int BlockSize = 20;

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        private bool[,] _values;

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        public int Width
        {
            get
            {
                return _values.GetLength(0) * BlockSize;
            }
        }

        public int Height
        {
            get
            {
                return _values.GetLength(1) * BlockSize;
            }
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        public GridImage(bool[,] values)
        {
            _values = values;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods ---------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        public byte[] GetImageArray()
        {
            byte[,] image = new byte[_values.GetLength(0) * BlockSize, _values.GetLength(1) * BlockSize];

            InitImage(ref image);

            for (var d1 = 0; d1 < _values.GetLength(0); d1++)
            {
                for (var d2 = 0; d2 < _values.GetLength(1); d2++)
                {
                    if (_values[d1, d2])
                    {
                        WritePoint(ref image, d1, d2);
                    }
                }
            }

            return ToOneDimensional(image);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        private void InitImage(ref byte[,] image)
        {
            for (var d1 = 0; d1 < image.GetLength(0); d1++)
            {
                for (var d2 = 0; d2 < image.GetLength(1); d2++)
                {
                    image[d1, d2] = byte.MaxValue;
                }
            }
        }

        private static void WritePoint(ref byte[,] image, int x, int y)
        {
            for (var i = 1; i < BlockSize - 1; i++)
            {
                for (var j = 1; j < BlockSize - 1; j++)
                {
                    image[(x * BlockSize) + i, (y * BlockSize) + j] = 0;
                }
            }
        }

        private static byte[] ToOneDimensional(byte[,] source)
        {
            int ymax = source.GetLength(0);
            int xmax = source.GetLength(1);
            int len = xmax * ymax;
            var dest = new byte[len];

            for (int y = 0, i = 0; y < ymax; y++)
            {
                for (int x = 0; x < xmax; x++, i++)
                {
                    dest[i] = source[y, x];
                }
            }
            return dest;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

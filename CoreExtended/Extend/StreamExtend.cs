using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreExtended.Extend
{
    /// <summary>
    /// 流扩展
    /// </summary>
    public static class StreamExtend
    {
        /// <summary>
        /// 将流转成字节数组
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>如果Stream为null返回null.</returns>
        public static byte[] ToByteArray(this Stream stream)
        {
            byte[] array;
            if (stream == null)
            {
                array = null;
            }
            else
            {
                array = new byte[(int)stream.Length];
                stream.Read(array, 0, array.Length);
            }
            return array;
        }
    }
}

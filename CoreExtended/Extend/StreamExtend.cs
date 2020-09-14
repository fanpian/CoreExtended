using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            if (stream == null)
            {
                return null;
            }
            byte[] array = new byte[(int)stream.Length];
            stream.Read(array, 0, array.Length);
            return array;
        }

        /// <summary>
        /// 将流写入文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool ToFile(this Stream stream, string filePath)
        {
            if (stream == null)
            {
                return false;
            }
            byte[] array = ToByteArray(stream);
            File.WriteAllBytes(filePath, array);
            return true;
        }
    }
}

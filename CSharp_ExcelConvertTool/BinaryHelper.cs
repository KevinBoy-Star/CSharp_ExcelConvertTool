using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharp_ExcelConvertTool
{
    public static class BinaryHelper
    {
        /// <summary>
        /// 保存二进制
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="binaryTarget">二进制对象</param>
        public static void SaveBinary(string filePath, object binaryTarget)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Create(filePath);
            binaryFormatter.Serialize(fileStream, binaryTarget);
            fileStream.Close();
        }

        /// <summary>
        /// 二进制反序列化
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="stream">流</param>
        /// <returns></returns>
        public static T ToObject<T>(Stream stream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return (T)binaryFormatter.Deserialize(stream);
        }
    }
}

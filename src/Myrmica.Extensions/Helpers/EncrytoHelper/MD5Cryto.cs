using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Helpers.EncrytoHelper
{
    public static class MD5Cryto
    {
        public static async Task<string> Md5Hash(this string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            var bt = Encoding.ASCII.GetBytes(text);
            //compute hash from the bytes of text
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            return await bt.Md5Hash();
        }

        public static async Task<string> Md5Hash(this Stream stream)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text

            var bt = stream.ReadToEnd();

            return await bt.Md5Hash();
            //return BitConverter.ToString(result).Replace("-", "").ToLowerInvariant();
        }

        /// <summary>
        /// Lấy chuỗi băm md5 của file
        /// </summary>
        /// <param name="bt">mảng bytes</param>
        /// <returns>chuỗi string là mã băm md5 của file</returns>
        public static async Task<string> Md5Hash(this byte[] bt)
        {
            return await Task.Run(() =>
            {
                MD5 md5 = new MD5CryptoServiceProvider();

                //compute hash from the bytes of text

                md5.ComputeHash(bt);

                //stream.Close();
                //get hash result after compute it
                var result = md5.Hash;
                var strBuilder = new StringBuilder();
                foreach (var t in result)
                {
                    //change it into 2 hexadecimal digits
                    //for each byte
                    strBuilder.Append(t.ToString("x2"));
                }

                GC.Collect();

                return strBuilder.ToString();
            });
            //return BitConverter.ToString(result).Replace("-", "").ToLowerInvariant();
        }

        /// <summary>
        /// đọc từ stream thành mảng byte
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ReadToEnd(this Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
    }
}

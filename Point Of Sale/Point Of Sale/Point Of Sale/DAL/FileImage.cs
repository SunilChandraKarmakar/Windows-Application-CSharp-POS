using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    static class FileImage
    {
        public static Byte[] ImageToByte(System.Drawing.Image image)
        {
            System.Drawing.ImageConverter imgConverter = new System.Drawing.ImageConverter();
            Byte[] bytes;
            bytes = (Byte[])(imgConverter.ConvertTo(image, typeof (Byte[])));
            return bytes;
        }

        public static System.Drawing.Image ImageFromByte(object bytes)
        {
            try
            {
                System.IO.MemoryStream memoryStream = new MemoryStream((Byte[])(bytes));
                return System.Drawing.Image.FromStream(memoryStream);
            }
            catch (Exception)
            {
                
                return null;
            }
        }

       /* public static Byte[] FileToByte(string fileName)
        {
            if (fileName == "")
            {
                return null;
            }

            System.IO.FileStream fileStream = new System.IO.FileStream(fileName, System.IO.FileStream);
            byte[] imageData = new byte[fileStream.Length];
            fileStream.Read(imageData, 0, System.Convert.ToInt32(fileStream.Length));
            fileStream.Close();
            return imageData;
        }

        public static void FileFromByte(Byte[] Files, string savepath)
        {
            String LPath = savepath;
            System.IO.FileStream fileStream = new FileStream(LPath, System.IO.FileMode);
            fileStream.Write(Files, 0, Files.Length);
            fileStream.Flush();
            fileStream.Close();
        } */

        
    }
}

using System;
using System.IO;

namespace Storage.Controllers
{
    public static class FileController
    {
        public static void Write(string path, string content)
        {
            try
            {
                File.WriteAllText(path, content);
            }
            catch (Exception e)
            {
                throw new IOException();
            }
        }

        public static string Read(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception e)
            {
                throw new IOException();
            }
        }
    }
}
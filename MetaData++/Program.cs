using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaData__
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Obtiene la información de la unidad C:
            DriveInfo driveInfo = new DriveInfo("C:\\");

            // Obtiene la raíz de la unidad C:
            DirectoryInfo root = driveInfo.RootDirectory;
            // Recorre todos los directorios y subdirectorios de la raíz de la unidad C:
            RecursiveDirectorySearch(root);
            // Obtiene todos los archivos y carpetas de la raíz de la unidad C:
            FileSystemInfo[] fileSystemInfos = root.GetFileSystemInfos();
            FileInfo[] fileInfos = root.GetFiles();
            // Recorre cada archivo y carpeta y muestra su información de metadata
            foreach (FileInfo fileInfo in fileInfos)
            {
                Console.WriteLine("Nombre: " + fileInfo.Name);
                Console.WriteLine("Tamaño: " + ifilesize(fileInfo));
                Console.WriteLine("Extension: " + fileInfo.Extension);
                Console.WriteLine("Última modificación: " + fileInfo.LastWriteTime);
                Console.WriteLine("Fecha Creación: " + fileInfo.CreationTime);
                Console.WriteLine("Tipo: " + fileInfo.Attributes);
                Console.WriteLine();
              
            }
            Console.ReadLine();
        }
        static int ifilesize(FileInfo fileInfo)
        {
            long fileSize = fileInfo.Length;

            if (fileSize < 1024)
            {
                Console.WriteLine("Tamaño del archivo: " + fileSize + " bytes");
            }
            else if (fileSize < 1024 * 1024)
            {
                Console.WriteLine("Tamaño del archivo: " + fileSize / 1024 + " KB");
            }
            else
            {
                Console.WriteLine("Tamaño del archivo: " + fileSize / (1024 * 1024) + " MB");
            }
            return 0;
        }
        static void RecursiveDirectorySearch(DirectoryInfo directoryInfo)
        {
            // Muestra el nombre del directorio
            Console.WriteLine(directoryInfo.Name);

            // Obtiene todos los subdirectorios del directorio
            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();

            // Recorre cada subdirectorio y llama a la función de forma recursiva
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                RecursiveDirectorySearch(subDirectory);
            }
        }
    }
}

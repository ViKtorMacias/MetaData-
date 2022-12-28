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

            // Obtiene todos los archivos y carpetas de la raíz de la unidad C:
            FileSystemInfo[] fileSystemInfos = root.GetFileSystemInfos();

            // Recorre cada archivo y carpeta y muestra su información de metadata
            foreach (FileSystemInfo fileSystemInfo in fileSystemInfos)
            {
                Console.WriteLine("Nombre: " + fileSystemInfo.Name);
                Console.WriteLine("Última modificación: " + fileSystemInfo.LastWriteTime);
                Console.WriteLine("Tamaño: " + fileSystemInfo.CreationTime);
                Console.WriteLine("Tipo: " + fileSystemInfo.Attributes);
                Console.WriteLine();
              
            }
            Console.ReadLine();
        }
    }
}

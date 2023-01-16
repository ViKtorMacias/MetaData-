using NLog;
using System;
using System.IO;
using System.Reflection;

namespace MetaData__
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
           // var CurrentDirectory = Directory.GetCurrentDirectory();
            //foreach (DriveInfo d in allDrives)
            //{
            DriveInfo driveInfo = new DriveInfo(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

<<<<<<< HEAD
                // Obtiene la raíz de la unidad C:
                DirectoryInfo root = driveInfo.RootDirectory;
                // Recorre todos los directorios y subdirectorios de la raíz de la unidad C:
                RecursiveDirectorySearch(root);
                // Obtiene todos los archivos y carpetas de la raíz de la unidad C:
                FileSystemInfo[] fileSystemInfos = root.GetFileSystemInfos();
            //}
            Console.ReadLine();
        }
        static string ifilesize(FileInfo fileInfo)
        {
            long fileSize = fileInfo.Length;
            string sfilesize;
=======
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
>>>>>>> a0f11fd776d42feed761ccbf15f325014beb4ed0

            if (fileSize < 1024)
            {
                Console.WriteLine("Tamaño del archivo: " + fileSize + " bytes");
<<<<<<< HEAD
                sfilesize = fileSize + " bytes";
=======
>>>>>>> a0f11fd776d42feed761ccbf15f325014beb4ed0
            }
            else if (fileSize < 1024 * 1024)
            {
                Console.WriteLine("Tamaño del archivo: " + fileSize / 1024 + " KB");
<<<<<<< HEAD
                sfilesize = fileSize / 1024 + " KB";
=======
>>>>>>> a0f11fd776d42feed761ccbf15f325014beb4ed0
            }
            else
            {
                Console.WriteLine("Tamaño del archivo: " + fileSize / (1024 * 1024) + " MB");
<<<<<<< HEAD
                sfilesize = fileSize / (1024 * 1024) + " MB";
            }
            //if (fileSize < 1024 * 1024 * 1024)
            //{
            //    Console.WriteLine("Tamaño del archivo: " + fileSize / (1024 * 1024 * 1024) + " GB");
            //    sfilesize = fileSize / (1024 * 1024 * 1024) + " GB";
            //}
            return sfilesize;
        }
        static void RecursiveDirectorySearch(DirectoryInfo directoryInfo)
        {
            Logger log = LogManager.GetCurrentClassLogger();
            try
            {
                // Muestra el nombre del directorio
                Console.WriteLine(directoryInfo.Name);

                // Obtiene todos los subdirectorios del directorio
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                //directoryInfo.LastAccessTime
                // Recorre cada archivo y carpeta y muestra su información de metadata
                foreach (FileInfo fileInfo in fileInfos)
                {
                    Console.WriteLine("Nombre: " + fileInfo.Name);
                    Console.WriteLine("Tamaño: " + ifilesize(fileInfo));
                    Console.WriteLine("Extension: " + fileInfo.Extension);
                    Console.WriteLine("DirectoryName: " + fileInfo.DirectoryName);
                    Console.WriteLine("Última modificación: " + fileInfo.LastAccessTimeUtc);
                    Console.WriteLine("Fecha Creación: " + fileInfo.CreationTime);
                    Console.WriteLine("Fecha escritura: " + fileInfo.LastWriteTimeUtc);
                    Console.WriteLine("Tipo: " + fileInfo.Attributes);
                    Console.WriteLine();
                    MetaData.DataAccess.Model.InfoFileServerDataContext infoFileServer = new MetaData.DataAccess.Model.InfoFileServerDataContext();

                    infoFileServer.SP_FileInfo(fileInfo.Name, ifilesize(fileInfo).ToString(), fileInfo.Extension, fileInfo.DirectoryName, fileInfo.LastAccessTimeUtc.ToString(), fileInfo.CreationTime.ToString(), fileInfo.LastWriteTimeUtc.ToString(), fileInfo.Attributes.ToString());
                }
                // Recorre cada subdirectorio y llama a la función de forma recursiva
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    RecursiveDirectorySearch(subDirectory);
                }
            }
            catch (Exception)
            {
                log.Debug("This is a debug message");
                log.Error(new Exception(), "This is an error message");
                log.Fatal("This is a fatal message");

               
            }
            
=======
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
>>>>>>> a0f11fd776d42feed761ccbf15f325014beb4ed0
        }
    }
}

using System;
using System.IO;
using System.Reflection;

namespace MetaData
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

            // Obtiene la raiz de la unidad C:
            DirectoryInfo root = driveInfo.RootDirectory;
            // Recorre todos los directorios y subdirectorios de la raiz de la unidad C:
            RecursiveDirectorySearch(root);
            // Obtiene todos los archivos y carpetas de la raiz de la unidad C:
            FileSystemInfo[] fileSystemInfos = root.GetFileSystemInfos();
            //}
            Console.ReadLine();
        }
               
        static string ifilesize(FileInfo fileInfo)
        {
            long fileSize = fileInfo.Length;
            string sfilesize;

            if (fileSize < 1024)
            {
                Console.WriteLine("Tamano del archivo: " + fileSize + " bytes");
                sfilesize = fileSize + " bytes";

            }
            else if (fileSize < 1024 * 1024)
            {
                Console.WriteLine("Tamano del archivo: " + fileSize / 1024 + " KB");
                sfilesize = fileSize / 1024 + " KB";

            }
            else
            {
                Console.WriteLine("Tamano del archivo: " + fileSize / (1024 * 1024) + " MB");
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
            //Logger log = LogManager.GetCurrentClassLogger();
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
                    Console.WriteLine("Tamanno: " + ifilesize(fileInfo));
                    Console.WriteLine("Extension: " + fileInfo.Extension);
                    Console.WriteLine("DirectoryName: " + fileInfo.DirectoryName);
                    Console.WriteLine("ultima modificacio: " + fileInfo.LastAccessTimeUtc);
                    Console.WriteLine("Fecha Creacion: " + fileInfo.CreationTime);
                    Console.WriteLine("Fecha escritura: " + fileInfo.LastWriteTimeUtc);
                    Console.WriteLine("Tipo: " + fileInfo.Attributes);
                    Console.WriteLine();
                    DataAccess.Model.InfoFileServerDataContext infoFileServer = new MetaData.DataAccess.Model.InfoFileServerDataContext();

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
            //    log.Debug("This is a debug message");
            //    log.Error(new Exception(), "This is an error message");
            //    log.Fatal("This is a fatal message");


            }
        
            
        }
      
    }
}
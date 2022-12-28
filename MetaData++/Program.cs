﻿using NLog;
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
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                DriveInfo driveInfo = new DriveInfo(d.Name);

                // Obtiene la raíz de la unidad C:
                DirectoryInfo root = driveInfo.RootDirectory;
                // Recorre todos los directorios y subdirectorios de la raíz de la unidad C:
                RecursiveDirectorySearch(root);
                // Obtiene todos los archivos y carpetas de la raíz de la unidad C:
                FileSystemInfo[] fileSystemInfos = root.GetFileSystemInfos();
            }
            Console.ReadLine();
        }
        static string ifilesize(FileInfo fileInfo)
        {
            long fileSize = fileInfo.Length;
            string sfilesize;

            if (fileSize < 1024)
            {
                Console.WriteLine("Tamaño del archivo: " + fileSize + " bytes");
                sfilesize = fileSize + " bytes";
            }
            else if (fileSize < 1024 * 1024)
            {
                Console.WriteLine("Tamaño del archivo: " + fileSize / 1024 + " KB");
                sfilesize = fileSize / 1024 + " KB";
            }
            else
            {
                Console.WriteLine("Tamaño del archivo: " + fileSize / (1024 * 1024) + " MB");
                sfilesize = fileSize / (1024 * 1024) + " MB";
            }
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
                    Console.WriteLine("Última modificación: " + fileInfo.DirectoryName);
                    Console.WriteLine("Última modificación: " + fileInfo.LastAccessTimeUtc);
                    Console.WriteLine("Fecha Creación: " + fileInfo.CreationTime);
                    Console.WriteLine("Fecha Creación: " + fileInfo.LastWriteTimeUtc);
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
            
        }
    }
}

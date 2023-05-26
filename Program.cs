using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8 {
  class Program {
    static void Main(string[] args) {
      Folder FolderBase = new Folder(@"C:\Users\vyati\source\repos\Lab_8\textfile1");
      Folder FolderSync = new Folder(@"C:\Users\vyati\source\repos\Lab_8\textfile2");

      Console.WriteLine(FolderBase.FolderPath);
      FolderBase.PrintFolderFiles();
      Console.WriteLine();
      Console.WriteLine(FolderSync.FolderPath);
      FolderSync.PrintFolderFiles();

      if (FolderBase.SynchronizationWithFolder(FolderSync.FolderInfo)) {
        Console.WriteLine("Синхронизация прошла успешно!");
      } else {
        Console.WriteLine("Файлы уже синхронизированы!");
      }


      Console.ReadKey();
    }
  }
}

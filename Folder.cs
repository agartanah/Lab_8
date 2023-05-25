using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8 {
  public class Folder {
    public string FolderPath { get; set; }
    public DirectoryInfo FolderInfo { get; set; }
    public List<FileInfo> FolderFiles;

    public Folder(string FolderPath) {
      this.FolderPath = FolderPath;
      FolderInfo = new DirectoryInfo(FolderPath);
      FolderFiles = ReadFolderFiles(FolderPath);
    }

    public List<FileInfo> ReadFolderFiles(string FolderPath) {
      List<FileInfo> Files = new List<FileInfo>();

      FileInfo[] FolderFilesArray = FolderInfo.GetFiles();

      foreach (var File in FolderFilesArray) {
        Files.Add(File);
      }

      return Files;
    }

    public void PrintFolderFiles() {
      foreach (var File in FolderFiles) {
        Console.WriteLine(File);
      }
    }
  }
}
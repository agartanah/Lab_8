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
      FolderFiles = ReadFolderFiles(FolderInfo);
    }

    public List<FileInfo> ReadFolderFiles(DirectoryInfo FolderInfo) {
      List<FileInfo> Files = new List<FileInfo>();

      FileInfo[] FolderFilesArray = FolderInfo.GetFiles();

      foreach (var File in FolderFilesArray) {
        Files.Add(File);
      }

      return Files;
    }

    public bool SynchronizationWithFolder(DirectoryInfo FolderSync) {
      List<FileInfo> FolderSyncFiles = ReadFolderFiles(FolderSync);
      bool Sync = false;

      if (FolderFiles.Count != 0) {
        foreach (var FolderFile in FolderFiles) {
          string FolderSyncFilePath = FolderSync.FullName + @"\" + FolderFile.Name;

          if (File.Exists(FolderSyncFilePath)) {
            if (!Enumerable.SequenceEqual(File.ReadAllBytes(FolderFile.FullName), File.ReadAllBytes(FolderSyncFilePath))) {
              File.Delete(FolderFile.FullName);
              File.Copy(FolderSyncFilePath, FolderFile.FullName);

              Sync = true;
              continue;
            }
          } else {
            File.Copy(FolderFile.FullName, FolderSyncFilePath);
            Sync = true;
          }

          
          foreach (var FolderSyncFile in FolderSyncFiles) {
            if (!File.Exists(FolderInfo.FullName + @"\" + FolderSyncFile.Name)) {
              File.Copy(FolderSyncFile.FullName, (FolderInfo.FullName + @"\" + FolderSyncFile.Name));

              Sync = true;
            }
          }
        }
      } else if (FolderSyncFiles.Count != 0) {
        foreach (var FolderSyncFile in FolderSyncFiles) {
          File.Copy(FolderSyncFile.FullName, (FolderInfo.FullName + @"\" + FolderSyncFile.Name));

          Sync = true;
        }
      }

      return Sync;
    }

    public void PrintFolderFiles() {
      foreach (var File in FolderFiles) {
        Console.WriteLine(File);
      }
    }
  }
}
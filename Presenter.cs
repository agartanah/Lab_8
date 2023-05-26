using System.IO;

namespace Lab_8 {
  public static class Presenter {
    public static bool Accept(string FolderBasePath, string FolderSyncPath) {
      Folder FolderBase = new Folder(FolderBasePath);
      Folder FolderSync = new Folder(FolderSyncPath);

      return FolderBase.SynchronizationWithFolder(FolderSync.FolderInfo);
    }

    public static bool Delete(string FilePath) {
      if (File.Exists(FilePath)) {
        File.Delete(FilePath);
        
        return true;
      } else {
        return false;
      }
    }

    public static bool Create(string FilePath) {
      if (!File.Exists(FilePath)) {
        File.Create(FilePath).Close();

        return true;
      } else {
        return false;
      }
    }
  }
}

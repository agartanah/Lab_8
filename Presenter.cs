using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Lab_8 {
  
  public static class Presenter {
    public static string XmlFilePath = Path.Combine(Environment.CurrentDirectory, @"logs\StatusSync.xml");
    public static string JsonFilePath = @"C:\Users\vyati\source\repos\Lab_8\bin\Debug\logs\StatusSync.json";/*Path.Combine(Environment.CurrentDirectory, @"logs\StatusSync.json");*/
    public static XmlDocument XmlFile;
    public static JArray JsonFile;
    private static List<string> filesJson = new List<string>();
    private static List<string> foldersJson = new List<string>();
    private static XmlElement session;
    private static List<XmlElement> filesXml = new List<XmlElement>();
    private static List<XmlElement> foldersXml = new List<XmlElement>();
    public static bool Accept(string FolderBasePath, string FolderSyncPath) {
      Folder FolderBase = new Folder(FolderBasePath);
      Folder FolderSync = new Folder(FolderSyncPath);

      if (session.ChildNodes.Count == 0) {
        bool Success = FolderBase.SynchronizationWithFolder(FolderSync.FolderInfo);

        FolderBase = new Folder(FolderBasePath);
        FolderSync = new Folder(FolderSyncPath);

        FoldersToXml(FolderBase, FolderSync);
        return Success;
      }

      return AcceptWithXml(FolderBasePath, FolderSyncPath);
    }

    private static void FoldersToXml(Folder FolderBase, Folder FolderSync) {
      string FileStatus = "sync";

      foreach (var FolderFile in FolderBase.FolderFiles) {
        AddXmlLog(FolderFile.FullName, FileStatus, FolderSync.FolderPath);
      }

      foreach (var FolderFile in FolderSync.FolderFiles) {
        AddXmlLog(FolderFile.FullName, FileStatus, FolderBase.FolderPath);
      }
    }

    public static bool AcceptWithXml(string FolderBasePath, string FolderSyncPath) {
      Folder FolderBase = new Folder(FolderBasePath);
      Folder FolderSync = new Folder(FolderSyncPath);
      bool Succsess = false;

      foreach (var FileElement in filesXml) {
        if (FileElement.GetAttribute("Status") != "sync") {
          Succsess = FolderBase.SynchronizationWithFolder(FolderSync.FolderInfo);
          FileElement.SetAttribute("Status", "sync");
          FoldersToXml(FolderBase, FolderSync);
        }
      }

      //foreach (var FolderFile in FolderBase.FolderFiles) {
      //  Console.WriteLine(FolderFile.FullName);
      //  foreach (var FileElement in files) {
      //    Console.WriteLine(FileElement.GetAttribute("Path"));
      //    Console.WriteLine(FileElement.GetAttribute("Status"));
      //    Console.WriteLine((FileElement.GetAttribute("Status") != "sync"));
      //    if (FolderFile.FullName == FileElement.GetAttribute("Path") && FileElement.GetAttribute("Status") != "sync") {
      //      FileElement.SetAttribute("Status", "sync");

      //      Succsess = FolderBase.SynchronizationWithFolder(FolderSync.FolderInfo);

      //      FoldersToXml(FolderBase, FolderSync);

      //      return Succsess;
      //    }
      //  }
      //}

      //foreach (var FolderFile in FolderSync.FolderFiles) {
      //  Console.WriteLine(FolderFile.FullName);
      //  foreach (var FileElement in files) {
      //    Console.WriteLine(FileElement.GetAttribute("Path"));
      //    Console.WriteLine(FileElement.GetAttribute("Status"));
      //    Console.WriteLine((FileElement.GetAttribute("Status") != "sync"));
      //    if (FolderFile.FullName == FileElement.GetAttribute("Path") && (FileElement.GetAttribute("Status") != "sync")) {
      //      FileElement.SetAttribute("Status", "sync");

      //      Succsess = FolderSync.SynchronizationWithFolder(FolderBase.FolderInfo);

      //      FoldersToXml(FolderSync, FolderBase);

      //      return Succsess;
      //    }
      //  }
      //}

      return Succsess;
    }

    public static bool Create(string FilePath) {
      if (!File.Exists(FilePath)) {
        File.Create(FilePath).Close();

        string FileStatus = "create";

        AddJsonLog(FilePath, FileStatus);
        AddXmlLog(FilePath, FileStatus);

        return true;
      } else {
        return false;
      }
    }

    public static bool Delete(string FilePath) {
      if (File.Exists(FilePath)) {
        File.Delete(FilePath);

        string FileStatus = "del";

        AddJsonLog(FilePath, FileStatus);
        AddXmlLog(FilePath, FileStatus);

        return true;
      } else {
        return false;
      }
    }

    public static void AddXmlLog(string FilePath, string FileStatus, string FolderSyncPath = "none") {
      FileInfo File = new FileInfo(FilePath);

      foreach (var FileElement in filesXml) {
        if (FileElement.GetAttribute("Path") == FilePath) {
          FileElement.SetAttribute("Status", FileStatus);

          XmlFile.Save(XmlFilePath);
          return;
        }
      }

      foreach (var FolderElement in foldersXml) {
        if (FolderElement.GetAttribute("Path") == File.Directory.FullName) {
          XmlElement FileElement = AddXmlFile(FolderElement, File, FileStatus);
          filesXml.Add(FileElement);

          XmlFile.Save(XmlFilePath);
          return;
        }
      }

      XmlElement FolderFiles = AddXmlFolder(File, FileStatus, FolderSyncPath);
      foldersXml.Add(FolderFiles);

      XmlElement FolderFile = AddXmlFile(FolderFiles, File, FileStatus);
      filesXml.Add(FolderFile);

      XmlFile.Save(XmlFilePath);
    }

    private static XmlElement AddXmlFolder(FileInfo File, string FileStatus, string FolderSyncPath) {
      XmlElement FolderFiles = XmlFile.CreateElement("Folder");
      FolderFiles.SetAttribute("Path", File.Directory.FullName);
      FolderFiles.SetAttribute("FolderSync", FolderSyncPath);
      session.AppendChild(FolderFiles);

      return FolderFiles;
    }

    private static XmlElement AddXmlFile(XmlElement FolderFiles, FileInfo File, string FileStatus) {
      XmlElement FolderFile = XmlFile.CreateElement("File");
      FolderFile.SetAttribute("Path", File.FullName);
      FolderFile.SetAttribute("Name", File.Name);
      FolderFile.SetAttribute("Status", FileStatus);
      FolderFiles.AppendChild(FolderFile);

      return FolderFile;
    }

    public static void CreateXmlFile() {
      XmlFile = new XmlDocument();

      XmlDeclaration XmlDeclaration = XmlFile.CreateXmlDeclaration("1.0", "utf-8", null);
      XmlFile.AppendChild(XmlDeclaration);

      session = XmlFile.CreateElement("Session");
      XmlFile.AppendChild(session);

      XmlFile.Save(XmlFilePath);
    }

    public static void AddJsonLog(string FilePath, string FileStatus, string FolderSyncPath = "none") {
      FileInfo FolderFile = new FileInfo(FilePath);

      foreach (var FolderElement in JsonFile) {
        foreach (var FileElement in FolderElement["files"]) {
          if (FileElement.Path == "path" && FileElement["path"].ToString() == FilePath) {
            FileElement["status"] = FileStatus;

            File.WriteAllText(JsonFilePath, JsonFile.ToString());
            return;
          }
        }
      }

      foreach (var FolderElement in JsonFile) {
        if (FolderElement["path"].ToString() == FolderFile.Directory.FullName) {
          JObject FileJObject = new JObject();
          FileJObject["path"] = FilePath;
          FileJObject["name"] = FolderFile.Name;
          FileJObject["status"] = FileStatus;

          JArray Files = (JArray)FolderElement["files"];

          Files.Add(FileJObject);

          File.WriteAllText(JsonFilePath, JsonFile.ToString());
          return;
        }
      }

      JObject FolderObject = new JObject();
      FolderObject["path"] = FolderFile.Directory.FullName;
      FolderObject["foldersync"] = FolderSyncPath;

      JArray FolderFiles = new JArray();
      FolderObject["files"] = FolderFiles;

      JsonFile.Add(FolderObject);

      JObject FileObject = new JObject();
      FileObject["path"] = FilePath;
      FileObject["name"] = FolderFile.Name;
      FileObject["status"] = FileStatus;

      FolderFiles.Add(FileObject);

      Console.WriteLine(JsonFilePath);

      File.WriteAllText(JsonFilePath, JsonFile.ToString());

      //foreach (var FileElement in files) {
      //  if (FileElement.GetAttribute("Path") == FilePath) {
      //    FileElement.SetAttribute("Status", FileStatus);

      //    XmlFile.Save(XmlFilePath);
      //    return;
      //  }
      //}

      //foreach (var FolderElement in folders) {
      //  if (FolderElement.GetAttribute("Path") == File.Directory.FullName) {
      //    XmlElement FileElement = AddXmlFile(FolderElement, File, FileStatus);
      //    files.Add(FileElement);

      //    XmlFile.Save(XmlFilePath);
      //    return;
      //  }
      //}

      //XmlElement FolderFiles = AddXmlFolder(File, FileStatus, FolderSyncPath);
      //folders.Add(FolderFiles);

      //XmlElement FolderFile = AddXmlFile(FolderFiles, File, FileStatus);
      //files.Add(FolderFile);

      //XmlFile.Save(XmlFilePath);
    }

    public static void CreateJsonFile() {
      string StartString = "[]";

      JsonFile = JsonConvert.DeserializeObject<JArray>(StartString);

      File.WriteAllText(JsonFilePath, StartString);
    }
  }
}

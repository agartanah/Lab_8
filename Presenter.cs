using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace Lab_8 {
  
  public static class Presenter {
    public static string XmlFilePath = Path.Combine(Environment.CurrentDirectory, @"logs\StatusSync.xml");
    public static XmlDocument XmlFile;
    private static XmlElement session;
    private static List<XmlElement> files = new List<XmlElement>();
    private static List<XmlElement> folders = new List<XmlElement>();
    public static bool Accept(string FolderBasePath, string FolderSyncPath) {
      Folder FolderBase = new Folder(FolderBasePath);
      Folder FolderSync = new Folder(FolderSyncPath);

      return FolderBase.SynchronizationWithFolder(FolderSync.FolderInfo);
    }

    public static bool AcceptWithXml(string FolderBasePath, string FolderSyncPath) {
      if (XmlFile == null) {

      }
      return false;
    }

    public static bool Create(string FilePath) {
      if (!File.Exists(FilePath)) {
        File.Create(FilePath).Close();

        string FileStatus = "create";

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

        AddXmlLog(FilePath, FileStatus);

        return true;
      } else {
        return false;
      }
    }

    public static void AddXmlLog(string FilePath, string FileStatus) {
      FileInfo File = new FileInfo(FilePath);

      foreach (var FileElement in files) {
        if (FileElement.GetAttribute("Path") == FilePath) {
          FileElement.SetAttribute("Status", FileStatus);

          XmlFile.Save(XmlFilePath);
          return;
        }
      }

      foreach (var FolderElement in folders) {
        if (FolderElement.GetAttribute("Path") == File.Directory.FullName) {
          XmlElement FileElement = AddXmlFile(FolderElement, File, FileStatus);
          files.Add(FileElement);

          XmlFile.Save(XmlFilePath);
          return;
        }
      }

      XmlElement FolderFiles = AddXmlFolder(File, FileStatus);
      folders.Add(FolderFiles);

      XmlElement FolderFile = AddXmlFile(FolderFiles, File, FileStatus);
      files.Add(FolderFile);

      XmlFile.Save(XmlFilePath);
    }

    private static XmlElement AddXmlFolder(FileInfo File, string FileStatus) {
      XmlElement FolderFiles = XmlFile.CreateElement("Folder");
      FolderFiles.SetAttribute("Path", File.Directory.FullName);
      FolderFiles.SetAttribute("FolderSync", "none");
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
  }
}

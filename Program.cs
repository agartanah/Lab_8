using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Lab_8 {
  class Program {
    [STAThread]
    static void Main(string[] args) {
      //XmlDocument XmlFile = new XmlDocument();

      //Presenter.CreateXmlFile();
      //Presenter.AddXmlLog(@"C:\Users\vyati\source\repos\Lab_8\textfile1\text1.txt", "del");

      //// Создаем новый XML-документ
      //XmlDocument xmlDoc = new XmlDocument();

      //// Создаем XML-заголовок <?xml version="1.0" encoding="utf-8"?>
      //XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
      //xmlDoc.AppendChild(xmlDeclaration);

      //// Создаем корневой элемент
      //XmlElement rootElement = xmlDoc.CreateElement("Root");
      //xmlDoc.AppendChild(rootElement);

      //// Создаем элементы внутри корневого элемента
      //XmlElement element1 = xmlDoc.CreateElement("Element1");
      //element1.InnerText = "Value1";
      //rootElement.AppendChild(element1);

      //XmlElement element2 = xmlDoc.CreateElement("Element2");
      //element2.SetAttribute("Attribute1", "Value2");
      //rootElement.AppendChild(element2);

      //// Сохраняем XML-документ в файл
      //xmlDoc.Save(@"C:\Users\vyati\source\repos\Lab_8\logs\StatusSync.xml");

      //Console.WriteLine("XML-файл создан.");
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());

      //string FilePath = Path.Combine(Environment.CurrentDirectory, @"logs\StatusSync.json");

      //string JsonContent = @File.ReadAllText(FilePath);

      //JArray JsonFile = JsonConvert.DeserializeObject<JArray>(JsonContent);
      //foreach (var item in JsonFile) {
      //  item["path"] = "djkslqjd";
      //  foreach(var el in item["files"]) {
      //    el["path"] = "dsqdrrrrrr";
      //  }
      //}

      //JObject Token = new JObject();
      //JObject Files = new JObject();
      //JArray arr = new JArray();


      //Token["path"] = "djjsds";
      //Files["path"] = "ffffff";
      //Token["files"] = arr;


      //JsonFile.Add(Token);

      //string Result = JsonFile.ToString();

      //Console.WriteLine(Result);

      //File.WriteAllText(FilePath, Result);

      //Console.ReadKey();
    }
  }
}

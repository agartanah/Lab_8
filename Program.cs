using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8 {
  class Program {
    static void Main(string[] args) {
      Folder Dictionary = new Folder(@"C:\Users\vyati\source\repos\Lab5\textfiles");

      Dictionary.PrintFolderFiles();

      Console.ReadKey();
    }
  }
}

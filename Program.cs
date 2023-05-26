using System;
using System.Windows.Forms;

namespace Lab_8 {
  class Program {
    [STAThread]
    static void Main(string[] args) {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }
  }
}

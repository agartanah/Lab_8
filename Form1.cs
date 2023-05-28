using System;
using System.Windows.Forms;

namespace Lab_8 {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
      Presenter.CreateXmlFile();
    }

    private void Form1_Load(object sender, EventArgs e) {

    }

    private void Syncron_Click(object sender, EventArgs e) {
      if (FolderBase.Text != string.Empty && FolderSync.Text != string.Empty) {
        if (Presenter.Accept(FolderBase.Text, FolderSync.Text)) {
          Console.WriteLine("Синхронизация прошла успешно!");
          State.Text = "Синхронизация прошла успешно!";
        } else {
          Console.WriteLine("Файлы уже синхронизированы!");
          State.Text = "Файлы уже синхронизированы!";
        }
      } else {
        Console.WriteLine("Введите оба пути к директориям!");
        State.Text = "Введите оба пути к директориям!";
      }
    }

    private void FolderBase_TextChanged(object sender, EventArgs e) {

    }

    private void FolderSync_TextChanged(object sender, EventArgs e) {

    }

    private void DeleteFile_Click(object sender, EventArgs e) {
      if (Presenter.Delete(FilePath.Text)) {
        FileState.Text = "Файл УДАЛЁН!";
        Console.WriteLine("Файл УДАЛЁН!");
      } else {
        FileState.Text = "Такого файла НЕ существует!";
        Console.WriteLine("Такого файла НЕ существует!");
      }
    }

    private void CreateFile_Click(object sender, EventArgs e) {
      if (FilePath.Text != string.Empty) {
        if (Presenter.Create(FilePath.Text)) {
          FileState.Text = "Файл СОЗДАН!";
          Console.WriteLine("Файл СОЗДАН!");
        } else {
          FileState.Text = "Файл УЖЕ создан!";
          Console.WriteLine("Файл УЖЕ создан!");
        }
      } else {
        FileState.Text = "Введите путь вашего ФАЙЛА!";
        Console.WriteLine("Введите путь вашего ФАЙЛА!");
      }
    }
  }
}

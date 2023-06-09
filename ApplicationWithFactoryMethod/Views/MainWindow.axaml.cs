using ApplicationWithFactoryMethod.ViewModels;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System.Linq;

namespace ApplicationWithFactoryMethod.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(DragDrop.DropEvent, Drop);
        }

        private async void OnOpenMenuClick(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });

            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });

            string[]? path = await openFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.LoadPeople(path[0]);
                }
            }
        }

        private void Drop(object? sender, DragEventArgs dragEventArgs)
        {
            if(dragEventArgs.Data.Contains(DataFormats.FileNames) == true)
            {
                string? fileName = dragEventArgs.Data.GetFileNames()?.FirstOrDefault();

                if (fileName != null)
                {
                    if(this.DataContext is MainWindowViewModel dataContext)
                    {
                        dataContext.LoadPeople(fileName);
                    }
                }
            }
        }
    }
}
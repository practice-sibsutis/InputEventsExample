
using Avalonia.Media;
using MouseAndPointerDeviceExample.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;

namespace MouseAndPointerDeviceExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<AbstractShape> shapesCollection;
        private ObservableCollection<ISolidColorBrush> coloredBrush;
        private ISolidColorBrush currentStroke;
        private ISolidColorBrush currentFill;
        private int strokeThickness;
        private bool isDrag;
        private bool isLine;
        private bool isEllipse;
        private bool isRectangle;

        public MainWindowViewModel()
        {
            shapesCollection = new ObservableCollection<AbstractShape>();
            ColoredBrush = new ObservableCollection<ISolidColorBrush>(
                typeof(Brushes)
                .GetProperties()
                .Select(propertyInfo => (ISolidColorBrush)propertyInfo.GetValue(propertyInfo))
                );

            CurrentFill = CurrentStroke = ColoredBrush[0];
            StrokeThickness = 1;
            IsDrag = true;
        }

        public int StrokeThickness
        {
            get => strokeThickness;
            set => this.RaiseAndSetIfChanged( ref strokeThickness, value );
        }

        public ISolidColorBrush CurrentStroke
        {
            get => currentStroke;
            set => this.RaiseAndSetIfChanged( ref currentStroke, value );
        }

        public ISolidColorBrush CurrentFill
        {
            get => currentFill;
            set => this.RaiseAndSetIfChanged(ref currentFill, value);
        }

        public ObservableCollection<ISolidColorBrush> ColoredBrush
        {
            get => coloredBrush;
            set => this.RaiseAndSetIfChanged(ref coloredBrush, value);
        }

        public bool IsDrag
        {
            get => isDrag;
            set => this.RaiseAndSetIfChanged(ref isDrag, value);
        }

        public bool IsLine
        {
            get => isLine;
            set => this.RaiseAndSetIfChanged(ref isLine, value);
        }

        public bool IsEllipse
        {
            get => isEllipse;
            set => this.RaiseAndSetIfChanged(ref isEllipse, value);
        }

        public bool IsRectangle
        {
            get => isRectangle;
            set => this.RaiseAndSetIfChanged(ref isRectangle, value);
        }

        public ObservableCollection<AbstractShape> ShapesCollection
        {
            get => shapesCollection;
            set => this.RaiseAndSetIfChanged(ref shapesCollection, value);
        }
    }
}
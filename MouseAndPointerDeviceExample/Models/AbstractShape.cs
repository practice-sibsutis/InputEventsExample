using Avalonia;
using Avalonia.Media;
using DynamicData;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAndPointerDeviceExample.Models
{
    public abstract class AbstractShape : AbstractNotifyPropertyChanged
    {
        private string name;
        private Point startPoint;
        private double scaleX;
        private double scaleY;
        private IBrush? stroke;
        private IBrush? fill;
        private double strokeThickness;
        public string Name
        {
            get => name;
            set => SetAndRaise(ref name, value);
        }
        public Point StartPoint
        {
            get => startPoint;
            set => SetAndRaise(ref startPoint, value);
        }
        public double ScaleX
        {
            get => scaleX;
            set => SetAndRaise(ref scaleX, value);
        }
        public double ScaleY
        {
            get => scaleX;
            set => SetAndRaise(ref scaleX, value);
        }
        public IBrush? Stroke
        {
            get => stroke;
            set => SetAndRaise(ref stroke, value);
        }
        public IBrush? Fill
        {
            get => fill;
            set => SetAndRaise(ref fill, value);
        }
        public double StrokeThickness
        {
            get => strokeThickness;
            set => SetAndRaise(ref strokeThickness, value);
        }

    }
}

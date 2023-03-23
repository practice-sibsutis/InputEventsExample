using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAndPointerDeviceExample.Models
{
    public class MyLine : AbstractShape
    {
        private Point endPoint;

        public Point EndPoint
        {
            get => endPoint;
            set => SetAndRaise(ref endPoint, value);
        }
    }
}

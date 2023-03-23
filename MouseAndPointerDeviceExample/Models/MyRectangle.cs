using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAndPointerDeviceExample.Models
{
    public class MyRectangle : AbstractShape
    {
        private double height;
        private double width;

        public double Height
        {
            get => height;
            set => SetAndRaise(ref height, value);
        }

        public double Width
        {
            get => width;
            set => SetAndRaise(ref width, value);
        }
    }
}

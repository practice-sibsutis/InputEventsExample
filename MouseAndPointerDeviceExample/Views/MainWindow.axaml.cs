using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.LogicalTree;
using Avalonia.Media;
using Avalonia.VisualTree;
using MouseAndPointerDeviceExample.Models;
using MouseAndPointerDeviceExample.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace MouseAndPointerDeviceExample.Views
{
    public partial class MainWindow : Window
    {
        private Point pointPointerPressed;
        private Point pointerPositionIntoShape;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PointerPressedOnCanvas(object sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            pointPointerPressed = pointerPressedEventArgs
                .GetPosition(
                this.GetVisualDescendants()
                .OfType<Canvas>()
                .FirstOrDefault());

            if (this.DataContext is MainWindowViewModel viewModel)
            {
                if (viewModel.IsRectangle == true)
                {
                    viewModel.ShapesCollection.Add(
                        new MyRectangle
                        {
                            StartPoint = pointPointerPressed,
                            Fill = viewModel.CurrentFill,
                            ScaleX = 1,
                            ScaleY = 1,
                            Stroke = viewModel.CurrentStroke,
                            StrokeThickness = viewModel.StrokeThickness,
                        });

                    this.PointerMoved += PointerMoveDrawRectangle;
                    this.PointerReleased += PointerPressedReleasedDrawRectangle;
                }
                else if (viewModel.IsEllipse == true)
                {
                    viewModel.ShapesCollection.Add(
                        new MyEllipse
                        {
                            StartPoint = pointPointerPressed,
                            Fill = viewModel.CurrentFill,
                            ScaleX = 1,
                            ScaleY = 1,
                            Stroke = viewModel.CurrentStroke,
                            StrokeThickness = viewModel.StrokeThickness,
                        });

                    this.PointerMoved += PointerMoveDrawEllipse;
                    this.PointerReleased += PointerPressedReleasedDrawEllipse;
                }
                else if(viewModel.IsLine == true)
                {
                    viewModel.ShapesCollection.Add(
                        new MyLine
                        {
                            StartPoint = pointPointerPressed,
                            EndPoint = pointPointerPressed,
                            ScaleX = 1,
                            ScaleY = 1,
                            Stroke = viewModel.CurrentStroke,
                            StrokeThickness = viewModel.StrokeThickness,
                        });

                    this.PointerMoved += PointerMoveDrawLine;
                    this.PointerReleased += PointerPressedReleasedDrawLine;
                }
                else if(viewModel.IsDrag == true)
                {
                    if(pointerPressedEventArgs.Source is Shape shape)
                    {
                        pointerPositionIntoShape = pointerPressedEventArgs.GetPosition(shape);
                        this.PointerMoved += PointerMoveDragShape;
                        this.PointerReleased += PointerPressedReleasedDragShape;
                    }
                }
            }
        }

        private void PointerMoveDrawRectangle(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                MyRectangle editRectangle = viewModel.ShapesCollection[viewModel.ShapesCollection.Count - 1] as MyRectangle;
                Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                editRectangle.Width = currentPointerPosition.X - pointPointerPressed.X;
                editRectangle.Height = currentPointerPosition.Y - pointPointerPressed.Y;
            }
        }

        private void PointerPressedReleasedDrawRectangle(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDrawRectangle;
            this.PointerReleased -= PointerPressedReleasedDrawRectangle;
        }

        private void PointerMoveDrawEllipse(object? sender, PointerEventArgs pointerEventArgs)
        {

            if (this.DataContext is MainWindowViewModel viewModel)
            {
                MyEllipse editEllipse = viewModel.ShapesCollection[viewModel.ShapesCollection.Count - 1] as MyEllipse;
                Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                editEllipse.Width = currentPointerPosition.X - pointPointerPressed.X;
                editEllipse.Height = currentPointerPosition.Y - pointPointerPressed.Y;
            }
        }

        private void PointerPressedReleasedDrawEllipse(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDrawEllipse;
            this.PointerReleased -= PointerPressedReleasedDrawEllipse;
        }

        private void PointerMoveDrawLine(object? sender, PointerEventArgs pointerEventArgs)
        {

            if (this.DataContext is MainWindowViewModel viewModel)
            {
                MyLine editLine = viewModel.ShapesCollection[viewModel.ShapesCollection.Count - 1] as MyLine;
                Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                editLine.EndPoint = currentPointerPosition;
            }
        }

        private void PointerPressedReleasedDrawLine(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDrawLine;
            this.PointerReleased -= PointerPressedReleasedDrawLine;
        }

        private void PointerMoveDragShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            if(pointerEventArgs.Source is Shape shape)
            {
                Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                if (shape.DataContext is AbstractShape myShape)
                {
                    myShape.StartPoint = new Point(
                        currentPointerPosition.X - pointerPositionIntoShape.X,
                        currentPointerPosition.Y - pointerPositionIntoShape.Y);
                }
            }
        }

        private void PointerPressedReleasedDragShape(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDragShape;
            this.PointerReleased -= PointerPressedReleasedDragShape;
        }

        private void PointerWheelChangedShape(object? sender, PointerWheelEventArgs pointerWheelEventArgs)
        {
            if(pointerWheelEventArgs.Source is Shape shape)
            {
                if(shape.DataContext is AbstractShape myShape)
                {
                    myShape.ScaleX += pointerWheelEventArgs.Delta.Y * 0.01;
                    myShape.ScaleY += pointerWheelEventArgs.Delta.Y * 0.01;
                }
            }
        }
    }
}
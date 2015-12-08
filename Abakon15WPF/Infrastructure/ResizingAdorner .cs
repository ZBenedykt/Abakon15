using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Abakon15WPF.Infrastructure
{
    class ResizingAdorner : Adorner
    {
        Thumb resizer;
        VisualCollection visualChildren;

        public ResizingAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
            visualChildren = new VisualCollection(this);
            BuildAdornerResizer(ref resizer, Cursors.SizeWE);

            resizer.DragDelta += new DragDeltaEventHandler(HandleResizer);
        }

        void HandleResizer(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;
            Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;
            FrameworkElement parentElement = adornedElement.Parent as FrameworkElement;

            // Ensure that the Width and Height are properly initialized after the resize.
            EnforceSize(adornedElement);

            // Change the size by the amount the user drags the mouse, as long as it's larger 
            // than the width or height of an adorner, respectively.
            adornedElement.Width = Math.Max(adornedElement.Width + args.HorizontalChange, hitThumb.DesiredSize.Width);

        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double desiredWidth = AdornedElement.DesiredSize.Width;
            double desiredHeight = AdornedElement.DesiredSize.Height;

            double adornerWidth = this.DesiredSize.Width;
            double adornerHeight = this.DesiredSize.Height;

            resizer.Arrange(new Rect(desiredWidth - adornerWidth / 2, -adornerHeight / 2, adornerWidth, adornerHeight * 2));

            return finalSize;
        }

        void BuildAdornerResizer(ref Thumb resizerThumb, Cursor customizedCursor)
        {
            if (resizerThumb != null) return;
            resizerThumb = new Thumb();
            resizerThumb.Style = (Style)Application.Current.Resources["ColumnHeaderRightGripperStyle"];
            //   resizerThumb.Cursor = customizedCursor;
            resizerThumb.Height = 25;
            resizerThumb.Width = 2;
            resizerThumb.Opacity = 0.50;

            resizerThumb.Background = (SolidColorBrush)Application.Current.Resources["BalanceRectangleBrush"]; // new SolidColorBrush(Colors.Maroon);

            visualChildren.Add(resizerThumb);
        }

        void EnforceSize(FrameworkElement adornedElement)
        {
            if (adornedElement.Width.Equals(Double.NaN))
                adornedElement.Width = adornedElement.DesiredSize.Width;
        }
        protected override int VisualChildrenCount { get { return visualChildren.Count; } }
        protected override Visual GetVisualChild(int index) { return visualChildren[index]; }

        //protected override void OnRender(DrawingContext drawingContext)
        //{
        //    // Get a rectangle that represents the desired size of the rendered element
        //    // after the rendering pass.  This will be used to draw at the corners of the 
        //    // adorned element.
        //    Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);

        //    // Some arbitrary drawing implements.
        //    SolidColorBrush renderBrush = new SolidColorBrush(Colors.Maroon);
        //    renderBrush.Opacity = 0.2;
        //    Pen renderPen = new Pen(new SolidColorBrush(Colors.Maroon), 0.5);
        //    double renderRadius = 3.0;

        //    // Just draw a circle at each corner.
        ////    drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius, renderRadius);
        //    drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius, renderRadius);
        // //   drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius, renderRadius);
        //    drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius, renderRadius);
        //}
    }
}

using System.Collections.Generic;
using Xamarin.Forms;
using TouchTracking;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Essentials;

namespace dream
{
    public partial class MainPage : ContentPage
    {
        Dictionary<long, SKPoint> inProgressCircles = new Dictionary<long, SKPoint>();
        List<SKPoint> completedCircles = new List<SKPoint>();

        SKPaint paintCircle = new SKPaint
        {
            Style = SKPaintStyle.StrokeAndFill,
            Color = Color.Black.ToSKColor(),
            StrokeWidth = 5
        };

        public MainPage()
        {
            InitializeComponent();
        }

        
        private void SkCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKSurface surface;
            SKCanvas canvas;

            surface = e.Surface;
            canvas = surface.Canvas;

            canvas.Clear(SKColors.SandyBrown); // 바탕색

            SKPaint pathStroke = new SKPaint // 선 정의
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Black,
                StrokeWidth = 5
            };
            SKPath path = new SKPath();

            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            for (int x = 0; x < mainDisplayInfo.Width; x += (int)mainDisplayInfo.Width/10)
            {
                path.MoveTo(x, 0);
                path.LineTo(x, (float)mainDisplayInfo.Height);
            }
            for (int y = 0; y < mainDisplayInfo.Height; y += (int)mainDisplayInfo.Width / 10)
            {
                path.MoveTo(0, y);
                path.LineTo((float)mainDisplayInfo.Width, y);
            }
            canvas.DrawPath(path, pathStroke);

            foreach (SKPoint point in completedCircles)
            {
                canvas.DrawCircle(point, 25, paintCircle);
            }
        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    if (!inProgressCircles.ContainsKey(args.Id))
                    {
                        inProgressCircles.Add(args.Id, ConvertToPixel(args.Location));
                        //DisplayAlert(null, "x: " + ConvertToPixel(args.Location).X + "  y: " + ConvertToPixel(args.Location).Y, "cancel");

                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Moved:
                    break;

                case TouchActionType.Released:
                    
                    if (inProgressCircles.ContainsKey(args.Id))
                    {
                        completedCircles.Add(inProgressCircles[args.Id]);
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Cancelled:
                    break;
            }
        }
        

        SKPoint ConvertToPixel(Point pt)
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            int x = (int)((int)canvasView.CanvasSize.Width * pt.X / canvasView.Width / (mainDisplayInfo.Width/10));
            int y= (int)((int)canvasView.CanvasSize.Height * pt.Y / canvasView.Height / (mainDisplayInfo.Width / 10));

            return new SKPoint((float)x* (float)(mainDisplayInfo.Width / 10) + (float)(mainDisplayInfo.Width / 10)-1,
                               (float)y* (float)(mainDisplayInfo.Width / 10) + (float)(mainDisplayInfo.Width / 10)-1);
        }
    }
}

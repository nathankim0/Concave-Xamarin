using System;
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
        Dictionary<long, SKPath> inProgressPaths = new Dictionary<long, SKPath>();
        List<SKPath> completedPaths = new List<SKPath>();

        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Blue,
            StrokeWidth = 10,
            StrokeCap = SKStrokeCap.Round,
            StrokeJoin = SKStrokeJoin.Round
        };

        public MainPage()
        {
            InitializeComponent();
        }

        
        private void SkCanvas_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
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

            for (int x = 10; x < mainDisplayInfo.Width; x += 100)
            {
                path.MoveTo(x, 0);
                path.LineTo(x, (float)mainDisplayInfo.Height);
            }
            for (int y = 10; y < mainDisplayInfo.Height; y += 100)
            {
                path.MoveTo(0, y);
                path.LineTo((float)mainDisplayInfo.Width, y);
            }
            canvas.DrawPath(path, pathStroke);

            foreach (SKPath path2 in completedPaths)
            {
                canvas.DrawPath(path2, paint);
            }

            foreach (SKPath path2 in inProgressPaths.Values)
            {
                canvas.DrawPath(path2, paint);
            }
        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    if (!inProgressPaths.ContainsKey(args.Id))
                    {
                        SKPath path = new SKPath();
                        path.MoveTo(ConvertToPixel(args.Location));
                        inProgressPaths.Add(args.Id, path);
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Moved:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        SKPath path = inProgressPaths[args.Id];
                        path.LineTo(ConvertToPixel(args.Location));
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Released:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        completedPaths.Add(inProgressPaths[args.Id]);
                        inProgressPaths.Remove(args.Id);
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Cancelled:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        inProgressPaths.Remove(args.Id);
                        canvasView.InvalidateSurface();
                    }
                    break;
            }
        }
        

        SKPoint ConvertToPixel(Point pt)
        {
            return new SKPoint((float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width),
                               (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));
        }
    }
}

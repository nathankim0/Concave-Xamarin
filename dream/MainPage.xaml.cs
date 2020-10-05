using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Xamarin.Forms;

namespace dream
{

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        private void SkCanvas_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.SandyBrown); // 바탕색

            SKPaint pathStroke = new SKPaint // 선 정의
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Black,
                StrokeWidth = 5
            };
            SKPath path = new SKPath();

            for(int x = 10; x < 1080; x += 100)
            {
                path.MoveTo(x, 0);
                path.LineTo(x, 2000);
            }
            for (int y = 10; y < 2000; y += 100)
            {
                path.MoveTo(0, y);
                path.LineTo(1080, y);
            }
            canvas.DrawPath(path, pathStroke);
        }

    }
}

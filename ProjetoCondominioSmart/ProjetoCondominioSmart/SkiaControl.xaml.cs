using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoCondominioSmart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkiaControl : ContentView
    {
        public SkiaControl()
        {
            InitializeComponent();
        }

        //background brush (Pincel?)
        SKPaint backgrundColor = new SKPaint()
        {
            Style = SKPaintStyle.Fill, //preenchimento
            //Style = SKPaintStyle.Stroke, // borda
            //Style = SKPaintStyle.StrokeAndFill, // os dois
            Color = Color.Red.ToSKColor(),
        };


        private void SkiaCanvas_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            //--> Desenhando um circulo:
            //canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, backgrundColor);


            //--> Desenhando um retangulo:

            SKRect retangulo = new SKRect(0,0,info.Width, info.Height);
            canvas.DrawRect(retangulo, backgrundColor);

            //gradiente background
            //backgrundColor.Shader = SKShader.CreateLinearGradient(
            //                                new SKPoint(0, 0),
            //                                new SKPoint(info.Width, info.Height),
            //                                new SKColor[] { Color.FromHex("98C1FF").ToSKColor(), Color.FromHex("fc7c7e").ToSKColor() }, //cores
            //                                new float[] { 0, 1 }, // posiçao
            //                                SKShaderTileMode.Clamp);

            //desenhando tela de fundo

            //SKRect = retangulo
            //SKRect retangulo = new SKRect(0, 0, info.Width, info.Height);
            //canvas.DrawRoundRect(retangulo, 20, 20, backgrundColor);

        }
    }
}
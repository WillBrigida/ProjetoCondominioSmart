using Android.Content;
using Android.Support.Design.Widget;
using ProjetoCondominioSmart.Controls;
using ProjetoCondominioSmart.Droid.Controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FormsFloatingActionButton), typeof(FormsFloatingActionButtonRenderer))]

namespace ProjetoCondominioSmart.Droid.Controls
{
    public class FormsFloatingActionButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<FormsFloatingActionButton, FloatingActionButton>
    {
        public FormsFloatingActionButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<FormsFloatingActionButton> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var fab = new FloatingActionButton(Context);
                fab.UseCompatPadding = true;
                fab.Click += OnFabClick;

                SetNativeControl(fab);

                var elementImage = Element.Image;
                var imageFile = elementImage?.File;

                if (imageFile != null)
                {
                    fab.SetImageDrawable(Context.Resources.GetDrawable("imgSelect.png"));
                }
            }

        }

        private void OnFabClick(object sender, EventArgs e)
        {
            Element?.Command?.Execute(null);
        }
    }
}
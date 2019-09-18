using Android.Content;
using ProjetoCondominioSmart.Droid.Renderes;
using ProjetoCondominioSmart.Others.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PickerExt), typeof(PickerExtRenderer))]

namespace ProjetoCondominioSmart.Droid.Renderes
{
    public class PickerExtRenderer : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
    {
        protected PickerExt PickerExt { get; private set; }

        public PickerExtRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;

            PickerExt = (PickerExt)Element;
            PickerExt.ShowPicker = () => Control.PerformClick();
        }
    }
}
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFUtils.Effects;

namespace ProjetoCondominioSmart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaTestePage : ContentPage
    {
        public ListaTestePage()
        {
            InitializeComponent();
            var eff = new XFUtils.Effects.ScrollReporterEffect();
            eff.ScrollChanged += Eff_ScrollChanged;
            ListViewListaPessoa.Effects.Add(eff);
        }

        private void Eff_ScrollChanged(object sender, ScrollEventArgs args)
        {
            Debug.WriteLine($" ====={args.Y}=====");
            if (args.Y > 60)
            {
                boxView.TranslateTo(0, -60, 100);
                ListViewListaPessoa.TranslateTo(0, -60, 100);
            }
            else
            {
                boxView.TranslateTo(0, 0);
                ListViewListaPessoa.TranslateTo(0, 0);
            }
        }
    }
}
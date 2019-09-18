using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoCondominioSmart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestePage : ContentPage
    {
        public TestePage()
        {
            InitializeComponent();
        }


        void OnToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == false)
            {
                picker.Unfocus();
                picker.IsEnabled = false;
            }
            else
            {
                picker.Focus();
                picker.IsEnabled = false;
            }
        }
    }
}
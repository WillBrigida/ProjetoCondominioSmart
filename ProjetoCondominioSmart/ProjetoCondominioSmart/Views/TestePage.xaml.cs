﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoCondominioSmart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestePage : ContentPage
    {
        public TestePage()
        {
            InitializeComponent();
            picker.IsEnabled = false;
        }

        void OnToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                picker.Focus();
                picker.IsEnabled = true;
                picker.Unfocus();
            }
            else
            {
                picker.Unfocus();
                picker.IsEnabled = false;
            }
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    if (picker.IsFocused == true)
        //    {
        //        picker.Unfocus();
        //    }
        //    return false;
        //}
    }
}
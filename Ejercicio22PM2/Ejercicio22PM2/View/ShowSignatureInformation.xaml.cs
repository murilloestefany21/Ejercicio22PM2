using Ejercicio22PM2.Controller;
using Ejercicio22PM2.Model;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio22PM2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowSignatureInformation : ContentPage
    {
        public ShowSignatureInformation(Signatures signatures)
        {
            InitializeComponent();
            name.Text = signatures.name;
            description.Text = signatures.description;
            imageSignature.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(signatures.imageCode)));
        }
    }
}
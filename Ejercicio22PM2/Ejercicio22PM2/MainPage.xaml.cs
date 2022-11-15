using SignaturePad.Forms;
using Ejercicio22PM2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Ejercicio22PM2.View;

namespace Ejercicio22PM2
{
    public partial class MainPage : ContentPage
    {
        string valueBase64;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            Stream image = await PadView.GetImageStreamAsync(SignatureImageFormat.Png);
            // var image = await signature.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            var mStream = (MemoryStream)image;
            byte[] data = mStream.ToArray();
            valueBase64 = Convert.ToBase64String(data);


            if (String.IsNullOrWhiteSpace(name.Text) || String.IsNullOrWhiteSpace(description.Text))
            {
                await DisplayAlert("Error", "Se deben llenar los campos de nombre y descripcion", "Aceptar");
            }

            var signatureToSave = new Signatures
            {
                imageCode = valueBase64,
                name = name.Text,
                description = description.Text
            };

            var result = await App.BaseDatos.saveSignature(signatureToSave);

            if (result != 1)
            {
                await DisplayAlert("Error", "Ocurrio un error, porfavor intente de nuevo", "Aceptar");
            }

            await DisplayAlert("Aviso", "Se ha guardado correctamente", "Aceptar");
        }

        private async void ViewSignaturesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignaturesList());
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            PadView.Clear();
        }
    }
}

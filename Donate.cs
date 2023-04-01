using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nodo_Tecnologico
{
    [Activity(Label = "Donacion")]
    public class Donate : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Establecer el archivo de diseño XML como el contenido de la actividad
            SetContentView(Resource.Layout.donate);

            //donaciones boton
            Button btndonate = FindViewById < Button > (Resource.Id.btndonate);
            btndonate.Click += delegate
            {
                string text = "0000007900204193753156";

                ClipboardManager clipboardManager = (ClipboardManager)GetSystemService(ClipboardService);

                ClipData clipData = ClipData.NewPlainText("Texto copiado", text);

                clipboardManager.PrimaryClip = clipData;

                Toast.MakeText(this, "Texto copiado al portapapeles", ToastLength.Short).Show();
            };
        }


    }
}
﻿using Android.App;
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
    [Activity(Label = "ubicacion_nodo")]
    public class UbicacionNodo : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Establecer el archivo de diseño XML como el contenido de la actividad
            SetContentView(Resource.Layout.ubicacion);
        }
    }
}
using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Navigation;
using Google.Android.Material.Snackbar;
using static Android.Content.ClipData;

namespace Nodo_Tecnologico
{
    [Activity(Label = "@string/app_name",Icon = "@mipmap/nodoportada", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //modificado (por defecto)  toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            var toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            //Sustituye el nombre de app_name y lo coloca en blanco dentro del navbar
            SupportActionBar.Title = "";

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }
        //segundo archivo
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }


        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            //View view = (View) sender;
            //Snackbar.Make(view, "Replace MS", Snackbrar.LengthLong)
            //    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show(); informes@nodosde.gob.ar

            FloatingActionButton fab = (FloatingActionButton)sender;

            string recipente = "informes@nodosde.gob.ar";

            var emailIntent = new Intent(Intent.ActionSendto, Android.Net.Uri.Parse("mailto:" + recipente));

            emailIntent.SetFlags(ActivityFlags.NewTask);

            PackageManager packageManager = PackageManager;

            IList<ResolveInfo> activities = packageManager.QueryIntentActivities(emailIntent, 0);

            bool isIntentSafe = activities.Count > 0;

            if (isIntentSafe)
            {
                emailIntent.SetPackage("com.google.android.gm");
                StartActivity(emailIntent);
            }
            else
            {
                Snackbar.Make(fab, "No se encontró una aplicación de correo electronico instalada", Snackbar.LengthLong).SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            }
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;




            //if (id == Resource.Id.nav_camera)
            //{
            //    // Handle the camera action
            //}

            if (id == Resource.Id.nav_gallery)
            {
                var intent = new Intent(this, typeof(UbicacionNodo));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_share)
            {
                var intent = new Intent(this, typeof(Web_Site));
               StartActivity(intent);
            }
            else if (id == Resource.Id.nav_send)
            {
                var intent = new Intent(this, typeof(Donate));
                StartActivity(intent);
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}


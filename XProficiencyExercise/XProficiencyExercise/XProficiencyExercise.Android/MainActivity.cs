using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content;
using FFImageLoading.Forms.Droid;
using FFImageLoading;

namespace XProficiencyExercise.Droid
{
    [Activity(
        Label = "XProficiencyExercise", 
        Icon = "@drawable/icon", 
        Theme = "@style/MainTheme", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //many other configuration do exist for this control that can smoothen scrolling,file caching,
            //lazy loading of image etc.
            CachedImageRenderer.Init(true);
            LoadApplication(new App());
        }

        public override void OnTrimMemory([GeneratedEnum] TrimMemory level)
        {
            ImageService.Instance.InvalidateMemoryCache();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            base.OnTrimMemory(level);
        }

        protected override void JavaFinalize()
        {
            //SetImageDrawable(null);
            //SetImageBitmap(null);
            //ImageService.Instance.InvalidateCacheEntryAsync(this.DataLocationUri, FFImageLoading.Cache.CacheType.Memory);
            base.JavaFinalize();
        }
    }
}


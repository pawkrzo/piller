using Android.App;
using Android.OS;
using Piller.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using Piller.Resources;
using MvvmCross.Binding.BindingContext;
using Android.Support.Design.Widget;
using Android.Views;

using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Piller.Droid.Views
{
    [Activity]
    public class MedicationDosageView : MvxAppCompatActivity<MedicationDosageViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MedicationDosageView);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
           
            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = AppResources.MedicationDosageViewModel_Title;


        }

    }
}

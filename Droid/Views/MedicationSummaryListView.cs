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
    public class MedicationSummaryListView : MvxAppCompatActivity<MedicationSummaryListViewModel>
    {


        FloatingActionButton newMedicationDosage;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MedicationSummaryListView);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            newMedicationDosage = FindViewById<FloatingActionButton>(Resource.Id.newMedicationDosage);

            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = AppResources.MedicationSummaryListViewModel_Title;

            SetBinding();
        }

        private void SetBinding()
        {
            var bindingSet = this.CreateBindingSet<MedicationSummaryListView, MedicationSummaryListViewModel>();

            bindingSet.Bind(newMedicationDosage)
                      .For(nameof(View.Click))
                      .To(x => x.AddNew);

            bindingSet.Apply();
        }
    }
}

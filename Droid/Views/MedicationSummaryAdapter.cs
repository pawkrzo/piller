using System;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.Views;

namespace Piller.Droid.Views
{
	public class MedicationSummaryAdapter : MvxAdapter
	{
		public MedicationSummaryAdapter(Android.Content.Context context) : base(context)
        {
		}

		public MedicationSummaryAdapter(Android.Content.Context context, MvvmCross.Binding.Droid.BindingContext.IMvxAndroidBindingContext bindingContext) : base(context, bindingContext)
        {
		}

		public MedicationSummaryAdapter(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
        {
		}

		protected override IMvxListItemView CreateBindableView(object dataContext, int templateId)
		{
			var view = base.CreateBindableView(dataContext, templateId) as MvxListItemView;
			var bset = view.CreateBindingSet<MvxListItemView, Piller.Data.MedicationDosage>();

			var name = view.FindViewById<TextView>(Resource.Id.label_medication_name);

			bset.Bind(name)
				.To(x => x.Name);
			bset.Apply();
			return view;
		}
	}
}

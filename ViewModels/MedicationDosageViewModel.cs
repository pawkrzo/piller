using System;
using MvvmCross.Core.ViewModels;
namespace Piller.ViewModels
{
    public class MedicationDosageViewModel : MvxViewModel
    {
        string medicationName;

        public string MedicationName
        {
            get { return medicationName; }
            set { this.RaiseAndSetIfChanged(ref medicationName, value); }
        }

        public MedicationDosageViewModel()
        {
        }
    }
}

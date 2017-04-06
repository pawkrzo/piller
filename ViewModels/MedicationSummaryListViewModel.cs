using System;
using System.Reactive;
using MvvmCross.Core.ViewModels;
using ReactiveUI;

namespace Piller.ViewModels
{
    public class MedicationSummaryListViewModel : MvxViewModel
    {

        public ReactiveCommand<Unit, bool> AddNew { get; }

        public MedicationSummaryListViewModel()
        {
            AddNew = ReactiveCommand.Create(() => this.ShowViewModel<MedicationDosageViewModel>());
        }
    }
}

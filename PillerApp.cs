using System;
using MvvmCross.Platform.IoC;

namespace Piller
{
    public class PillerApp : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.MedicationSummaryListViewModel>();
        }
    }
}

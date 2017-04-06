using System;
using System.Reactive.Disposables;
namespace Piller.iOS.Common
{
    public static class DisposableExtensions
    {
        public static void AddTo(this IDisposable single, CompositeDisposable composite)
        {
            composite.Add(single);
        }
    }
}

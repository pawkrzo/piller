using System;
using ReactiveUI;
using System.Reactive.Disposables;
using UIKit;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;

namespace Piller.iOS.Common
{

    public abstract class Element : ReactiveObject, IMvxBindable, IDisposable
    {

        protected int Tag { get; private set; }
        private UITableViewCell lastHoldedCell;

        public UIColor BackgroundColor { get; set; } = UIColor.White;
        public UIColor CaptionColor { get; set; } = UIColor.Black;
        public UIColor ValueColor { get; set; } = UIColor.Black;
        public ReactiveCommand Clicked { get; set; }

       
        public IMvxBindingContext BindingContext { get; set; }

        public object DataContext
        {
            get { return this.BindingContext.DataContext; }
            set { this.BindingContext.DataContext = value; }
        }

        protected CompositeDisposable Subscriptions { get; } = new CompositeDisposable();


        protected UITableViewCell CurrentAttachedCell
        {
            get
            {

                if (lastHoldedCell != null && lastHoldedCell.Tag == this.Tag)
                    return lastHoldedCell;
                return null;
            }
        }

      

        public UITableViewCell GetAndPrepareCell(UITableView tv, NSIndexPath indexPath)
        {
            var cell = GetCell(tv, indexPath);
            cell.Tag = this.Tag;
            this.lastHoldedCell = cell;
            return cell;
        }

        protected abstract UITableViewCell GetCell(UITableView tv, NSIndexPath indexPath);

        public virtual void DisplayEnded(UITableViewCell cell)
        {
        }

        public virtual void UpdateDisplay(UITableView tv)
        {
            tv.ReloadData();

        }

        public virtual void Dispose()
        {
            Subscriptions.Dispose();
            this.lastHoldedCell = null;
        }

        public Element()
        {
            this.Tag = this.GetHashCode();
            this.CreateBindingContext();
        }

    }

}

using System;
using Foundation;
using UIKit;
using System.Reactive.Disposables;
using System.Linq;
using System.Reactive.Linq;

namespace Piller.iOS.Common
{
    public class ElementTableSource : UITableViewSource
    {
        UITableView tableView;
        FormDefinition root;
        CompositeDisposable subscriptions = new CompositeDisposable();



        public ElementTableSource(FormDefinition root, UITableView tableView)
        {
            this.root = root;

            //update  display if value of any element property changes
            root
                .Sections
                .SelectMany(section => section.Elements) //find out all elements in section
                .Select(element => element.Changed.Select(_ => element)) // Changed is RecativeObject observable fired when any of the property is modifed.  The inner select just return the original element instead of Changed event
                .Merge() // convert a list of observables into one observable
                .Subscribe(element => element.UpdateDisplay(tableView))
                .AddTo(subscriptions);

        }


        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            Section section = this.root.Sections[indexPath.Section];
            Element element = section.Elements[indexPath.Row];
            var cell = element.GetAndPrepareCell(tableView, indexPath);
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            return cell;
        }


 

        public override nint NumberOfSections(UITableView tableView)
        {
            return this.root.Sections.Count;
        }


        public override nint RowsInSection(UITableView tableview, nint section)
        {
            Section section2 = this.root.Sections[(int)section];
            int count = section2.Elements.Count;
            return count;
        }


        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return this.root.Sections[(int)section].Name;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            subscriptions.Dispose();
        }

    }
}

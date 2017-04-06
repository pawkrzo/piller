using System;
using CoreGraphics;
using Foundation;
using ReactiveUI;
using UIKit;


namespace Piller.iOS.Common.Dialog
{
    public class MultilineEditElement : EditElement
    {
        const string CellKey = "MultilineEdit";



        public string Title { get; set; }

        string value;
        public virtual string Value
        {
            get
            {
                return value;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this.value, value);
                this.ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }


        public int? MaximumLength { get; set; }

        public event EventHandler ValueChanged; //event required to make mvvmcross bindings work

        public MultilineEditElement() : base()
        {
            this.Editable = true;
        }


        protected override UITableViewCell GetCell(UITableView tv, NSIndexPath indexPath)
        {
            var cell = this.CurrentAttachedCell as MultilineEditCell;

            if (cell == null)
            {
                cell = new MultilineEditCell(CellKey); //we don't reuse cell here to avoid switching event handlers

                cell.Input.ShouldChangeText = null;
                cell.Input.ShouldChangeText = handleMaxLength;

                cell.Input.Events().Changed.Subscribe(x =>
                {
                    var textView = cell.Input;
                    this.Value = textView.Text;

                    var size = textView.Bounds.Size;
                    var newSize = textView.SizeThatFits(new CGSize(size.Width, nfloat.MaxValue));

                    // Resize the cell only when cell's size is changed
                    if (size.Height != newSize.Height)
                    {
                        UIView.AnimationsEnabled = false;
                        tv.BeginUpdates();
                        tv.EndUpdates();
                        UIView.AnimationsEnabled = true;

                        var thisIndexPath = tv.IndexPathForCell(cell);
                        if (thisIndexPath != null)
                        {
                            tv.ScrollToRow(thisIndexPath, UITableViewScrollPosition.Bottom, false);
                        }

                    }
                }).AddTo(Subscriptions);

            }
         
            cell.TitleLabel.Text = this.Title;
            cell.Input.Text = this.Value;
            cell.BackgroundColor = this.BackgroundColor;
            cell.TitleLabel.TextColor = this.CaptionColor;

            cell.Input.TextColor = this.ValueColor;

            cell.Input.BackgroundColor = UIColor.White;
            cell.Input.Text = this.Value;


            return cell;
        }

        bool handleMaxLength(UITextView textView, NSRange range, string text)
        {
            if (MaximumLength.HasValue)
            {
                var newLength = textView.Text.Length + text.Length - range.Length;
                return newLength <= MaximumLength.Value;
            }
            return true;
        }

        public override void UpdateDisplay(UITableView tv)
        {
            var cell = this.CurrentAttachedCell as MultilineEditCell;
            if (cell != null)
            {
                cell.BackgroundColor = this.BackgroundColor;
                cell.TitleLabel.TextColor = this.CaptionColor;
                cell.Input.TextColor = this.ValueColor;
                cell.Input.Editable = this.Editable;

                if (cell.Input.Text != this.Value)
                {
                    cell.Input.Text = this.Value;
                }
            }
        }

        public void BecomeFirstResponder()
        {
            if (CurrentAttachedCell == null) return;
            ((MultilineEditCell)this.CurrentAttachedCell).Input.BecomeFirstResponder();
        }
    }
}

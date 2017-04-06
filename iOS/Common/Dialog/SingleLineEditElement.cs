using System;
using Foundation;
using ReactiveUI;
using UIKit;

namespace Piller.iOS.Common.Dialog
{
    public class SingleLineEditElement : EditElement
    {


        const string CellKey = "SinglelineEdit";

        public string Title { get; set; }

        string edit;

        public virtual string Value
        {
            get
            {
                return edit;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref edit, value);
                this.ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }


        protected override UITableViewCell GetCell(UITableView tv, NSIndexPath indexPath)
        {
            var cell = this.CurrentAttachedCell as SingleLineEditCell;

            if (cell == null)
            {
                cell = new SingleLineEditCell(CellKey);


                cell.Input.Events().EditingChanged.Subscribe(x =>
                {
                    var textView = cell.Input;
                    this.Value = textView.Text == "" ? null : textView.Text;
                }).AddTo(Subscriptions);

            }

            cell.TitleLabel.Text = this.Title;
            cell.Input.Text = this.Value;

         
            cell.Input.Enabled = this.Editable;

            cell.Input.ShouldChangeCharacters = this.validateInput;
            cell.BackgroundColor = this.BackgroundColor;

            cell.TitleLabel.TextColor = this.CaptionColor;
            cell.Input.TextColor = this.ValueColor;


            return cell;
        }

        private bool validateInput(UITextField tf, NSRange range, string replacement)
        {
            if (this.Mode == InputMode.Any)
                return true;

            if (string.IsNullOrEmpty(replacement))
                return true;

            var oldText = tf.Text;
            var newText = oldText.Substring(0, (int)range.Location) + replacement + oldText.Substring((int)range.Location + (int)range.Length);

            if (this.Mode == InputMode.Integer)
            {
                int value;
                return Int32.TryParse(newText, out value);
            }
            if (this.Mode == InputMode.Decimal)
            {
                decimal value;
                return Decimal.TryParse(newText, out value);
            }
            return false;
        }

        public override void UpdateDisplay(UITableView tv)
        {
            var cell = this.CurrentAttachedCell as SingleLineEditCell;
            if (cell != null)
            {
                if (cell.Input.Text != this.Value)
                {
                    cell.Input.Text = this.Value;
                }
                cell.TitleLabel.TextColor = this.CaptionColor;
                cell.Input.TextColor = this.ValueColor;
                cell.BackgroundColor = this.BackgroundColor;
            }


        }

        public event EventHandler ValueChanged;

    }
}

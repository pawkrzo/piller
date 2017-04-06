using System;
using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace Piller.iOS.Common.Dialog
{
    public class MultilineEditCell : UITableViewCell
    {
        public UILabel TitleLabel { get; private set; }
        public UITextView Input { get; private set; }

        public MultilineEditCell(string cellKey) : base(UITableViewCellStyle.Default, cellKey)
        {
            this.TitleLabel = new UILabel() { TranslatesAutoresizingMaskIntoConstraints = false, Lines = 0 };
            this.Input = new UITextView() { TranslatesAutoresizingMaskIntoConstraints = false, ScrollEnabled = false };

            this.ContentView.AddSubviews(this.TitleLabel, this.Input);

            this.ContentView.AddConstraints(
                this.TitleLabel.AtTopOf(this.ContentView).Plus(10),
                this.TitleLabel.AtLeftOf(this.ContentView).Plus(15),
                this.TitleLabel.WithSameRight(this.ContentView).Minus(15),

                this.Input.Below(this.TitleLabel),
                this.Input.WithSameLeft(this.TitleLabel).Minus(5),
                this.Input.WithSameRight(this.TitleLabel),
                this.Input.AtBottomOf(this.ContentView).Minus(10),
                this.Input.Height().GreaterThanOrEqualTo(30)
            );
        }
    }
}

using System;
namespace Piller.iOS.Common
{
  public abstract class EditElement : Element
    {
        public enum InputMode
        {
            Any,
            Integer,
            Decimal
        }

        public InputMode Mode { get; set; }

        public bool Editable
        {
            get;
            set;
        }

        public EditElement() : base()
        {
            this.Editable = true;
        }
    }
}

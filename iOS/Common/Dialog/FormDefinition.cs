using System;
using System.Collections.Generic;
namespace Piller.iOS.Common
{
    public class FormDefinition
    {
        public IReadOnlyList<Section> Sections { get; }

        public FormDefinition(List<Section> sections)
        {
            this.Sections = sections;
        }
    }
}

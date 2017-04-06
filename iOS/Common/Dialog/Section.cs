using System;
using System.Collections.Generic;

namespace Piller.iOS.Common
{
    public class Section
    {
        public string Name { get; }
        public IReadOnlyList<Element> Elements { get; }

        public Section(string name, List<Element> elements)
        {
            this.Name = name;
            this.Elements = elements;
        }
    }
}

using System;
using SQLite;
namespace Piller.Data
{
    public class MedicationDosage
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }

    }
}

namespace Ibero.Services.Avaya.Core.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IBET_PERSONS")]
    public class Person
    {
        [Column("Num_Document")]
        public string Num_Document { get; set; }

        [Column("Id_Banner")]
        public string Id_Banner { get; set; }

        [Column("Nam_Person")]
        public string Nam_Person { get; set; }

        [Column("Last_NamePerson")]
        public string Last_NamePerson { get; set; }

    }
}

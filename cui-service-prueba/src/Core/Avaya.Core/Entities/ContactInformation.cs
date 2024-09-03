namespace Ibero.Services.Utilitary.Core.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IBET_CONTACT_INFORMATION")]
    public class ContactInformation
    {
        public ContactInformation()
        {
            Sta_Active = true;
        }

        [Column("Id_ContactInformation")]
        public int IdContactInformation { get; set; }

        [Column("Id_ContactType")]
        public int IdContactType { get; set; }

        [Column("Id_Person")]
        public int IdPerson { get; set; }

        [Column("Des_ContactInformation")]
        public string DesContactInformation { get; set; }

        [Column("Id_CreateBy")]
        public int IdCreateBy { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("Id_UpdatedBy")]
        public int IdUpdatedBy { get; set; }

        [Column("UpdateDate")]
        public DateTime UpdateDate { get; set; }

        [Column("Sta_Active")]
        public Boolean Sta_Active { get; set; }

    }
}

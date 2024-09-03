namespace Ibero.Services.Utilitary.Domain.ContactInformation.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ContactInformationModel
    {
        public int IdContactInformation { get; set; }
        public int IdContactType { get; set; }
        public int IdPerson { get; set; }
        public string DesContactInformation { get; set; }
    }
}

using System.Data;
using CsvHelper.Configuration.Attributes;
using IBM.Data.DB2.Core;
using System.ComponentModel.DataAnnotations;

namespace Newmar.Models
{
    public class VIN
    {
        [Name("ID")]
        public int ID { get; set; }
        [Name("VNumber")]
        [Display(Name = "VIN")]
        public string? VNumber { get; set; }

    }
}

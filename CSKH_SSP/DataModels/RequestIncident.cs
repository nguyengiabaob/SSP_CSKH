using System.ComponentModel.DataAnnotations;

namespace CSKH_SSP.DataModels
{
    public class RequestIncident
    {
        [Key]
        public long Id { get; set; }
        public string RequestId { get; set; }
        public int Impact { get; set; }
        public string PreventiveAction { get; set; }
        public string CorrectiveAction { get; set; }
    }
}




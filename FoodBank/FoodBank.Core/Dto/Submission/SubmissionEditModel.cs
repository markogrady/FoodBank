using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Dto.Submission
{
    public class SubmissionEditModel
    {
        public Guid SubmissionId { get; set; }
        public string FileName { get; set; }
        public string LocationUrl { get; set; }
        public string Reference { get; set; }
        public SubmissionStatus SubmissionStatus { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

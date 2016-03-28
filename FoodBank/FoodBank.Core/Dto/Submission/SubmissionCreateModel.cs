using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Dto.Submission
{
    public class SubmissionCreateModel
    {
        public string FileName { get; set; }
        public string Reference { get; set; }
        public string LocationUrl { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Data.Enum
{
    public enum SubmissionStatus
    {
        NotSet=0,
        Uploaded=1,
        Validated=2,
        Completed=3,
        Error = 99,
    }
}

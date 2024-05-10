using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Requests
{
    public class EditJobRequest:JobRequest
    {
        public int Id { get; set; }
    }
}

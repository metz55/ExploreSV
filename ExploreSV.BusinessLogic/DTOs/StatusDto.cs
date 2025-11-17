using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.DTOs
{
    public class CreateStatusRequest
    {
        public string StatusName { get; set; } = null!;
    }

    public class UpdateStatusRequest
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
    }

    public class StatusResponse
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightHouse.Models
{
    public class RequestMessage
    {
        public int R_id { get; set; }
        public string PatiName { get; set; }
        public string Amountofblood { get; set; }
        public int B_id { get; set; }
        public string DPhone { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<System.DateTime> ReqDate { get; set; }
        public string HospitalName { get; set; }
        public string Reason { get; set; }
        public Nullable<bool> Dactive { get; set; }

        public virtual Bloodgroup Bloodgroup { get; set; }
        public virtual District District { get; set; }
    }
}
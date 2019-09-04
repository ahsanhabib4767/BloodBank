using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LightHouse.Models
{
    public class Donate
    {
        public int D_id { get; set; }
        [Required(ErrorMessage = "please enter your name")]
        public string Dname { get; set; }
        [Required(ErrorMessage = "please enter your username")]
        public string Dusername { get; set; }
        [Required(ErrorMessage = "please enter your pass")]
        public string Dpassword { get; set; }

        [Required(ErrorMessage = "please enter your number")]
        public string DPhone { get; set; }
        public string Ddistrict { get; set; }
        [Required(ErrorMessage = "please type your address")]
        public string Daddress { get; set; }
        public string Dthana { get; set; }
        [Required(ErrorMessage = "please select your bloodgroup")]
        public string Bbloodgroup { get; set; }
        public Nullable<System.DateTime> DdonateDate { get; set; }
        public Nullable<bool> Dactive { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LapTimeTracker.Models
{

    [NotMapped]
  
        public class LapTimeViewModel
        {
            public LapTimeViewModel()
            {
                Racer = new Racer();
            }

            public Racer Racer { get; set; }

            [Required(ErrorMessage = "Molim odaberite vrijeme")]
            public int LapHours { get; set; }


            [Required(ErrorMessage = "Molim odaberite vrijeme")]
            public int LapMinutes { get; set; }


            [Required(ErrorMessage = "Molim odaberite vrijeme")]
            public int LapSeconds { get; set; }

            [Required(ErrorMessage = "Molim odaberite vrijeme")]
            public int LapMiliSeconds { get; set; }
        }
    
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LapTimeTracker.Models
{
    public class Racer
    {
        public Racer()
        {
            AppStatus = Status.Novi;
            RecordStatus = 1;
        }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int RecordStatus { get; set; }

        [Required(ErrorMessage = "Molim Vas upišite ime")]
        [DisplayName("Ime")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Molim Vas upišite prezime")]
        [DisplayName("Prezime")]
        public string LastName { get; set; }


        [DisplayName("Status Prijave")]
        public string AppStatus { get; set; }

        public long LapTimeTicks { get; set; }

        [NotMapped]
        [DisplayName("Vrijeme")]
        public string LapTime
        {
            get
            {
                if (LapTimeTicks > 0)
                {
                    return new DateTime(LapTimeTicks).ToString("HH:mm:ss.fff");
                }
                else
                    return null;
            }
        }

    }

    [NotMapped]
    public static class Status
    {
        public const string Novi = "Novi";
        public const string Odobren = "Odobren";
        public const string Odbijen = "Odbijen";
    }
}

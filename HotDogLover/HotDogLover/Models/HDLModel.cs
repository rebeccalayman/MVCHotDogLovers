using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HotDogLover.Models
{
    public class HDLModel
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Favorite Dog")]
        public string FavoriteDog { get; set; }

        [Display(Name = "Last Ate")]
        [StringLength(60, MinimumLength = 3)]
        public string LastAte { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Range(1, 10)]
        public string Rating { get; set; }

        [Display(Name = "Past Dogs")]
        public List<HDLModel> PastDogs { get; set; }
            
     }

        public class HDLModelDBContext : DbContext
        {
            public DbSet<HDLModel> Movies { get; set; }
        }
}
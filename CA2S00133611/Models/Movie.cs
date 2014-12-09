using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using WebGrease.Css.Extensions;
using Microsoft.Ajax.Utilities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations.Resources;
using System.ComponentModel;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace CA2S00133611.Models
{
   
        public class Movie
        {
            MovieDBContext db = new MovieDBContext();
          
            
            // created class for movies and actors


            //validation in here can't get it working its throwing an excepetion on my vargenryqry 


            //[Key]
            public int ID { get; set; }
            //[StringLength(60, MinimumLength = 3)]
            public string MovieTitle { get; set; }
            //[StringLength(60, MinimumLength = 3)]
            public string Actor { get; set; }
             //[StringLength(60, MinimumLength = 3)]
            public string OnScreenName { get; set; }
           
            public string Genre { get; set; }
        }

    // created a connection string and object class called MovieDbContext
        public class MovieDBContext : DbContext
        {
            public DbSet<Movie> Movies { get; set; }
        }

    



    
}
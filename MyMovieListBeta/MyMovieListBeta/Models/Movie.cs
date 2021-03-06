//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyMovieListBeta.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Movie
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ReleaseDate { get; set; }

        public byte[] Poster { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> YourSeanceDate { get; set; }

        public int Score { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<System.DateTime> LastUpdate { get; set; }

        [ScaffoldColumn(false)]
        public string UpdateType { get; set; }
    }
}

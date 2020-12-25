namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TinTucList
    {
        public List<TinTuc> TinTucs { get; set; }

        [StringLength(50)]
        public string totalCount { get; set; }
    }
}
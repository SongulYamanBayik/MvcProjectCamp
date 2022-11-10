﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  public  class Title
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }



        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }

        public ICollection<Content> Contents { get; set; }

        public virtual Writer Writer { get; set; }
        public int WriterID { get; set; }
    }
}

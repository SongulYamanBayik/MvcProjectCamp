using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Writer
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(500)]
        public string Image { get; set; }
        
        [StringLength(100)]
        public string About { get; set; }

        [StringLength(50)]
        public string WriterTitle { get; set; }

        [StringLength(200)]
        public string Mail { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        public ICollection<Title> Titles { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}

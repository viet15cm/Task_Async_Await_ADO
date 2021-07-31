using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Async_Await.Model
{
    class Teacher
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public int? Age { get; set; }
        public  bool? Chairman { get; set; }
        [NotMapped]
        public virtual ICollection<Student> Students { get; set; }
    }
}

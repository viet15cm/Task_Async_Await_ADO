using Async_Await.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Async_Await
{
    class Student
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public int? Age { get; set; }
        public bool? Gender { get; set; }

        public Guid TeacherId { get; set; }

        [NotMapped]
        public virtual Teacher Teacher { get; set; }
    }
}

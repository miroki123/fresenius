using Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Tb_CID : Entity
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(10)]
        public virtual string Codigo { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public virtual string Nome { get; set; }
    }
}

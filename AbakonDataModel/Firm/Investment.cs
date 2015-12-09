using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AbakonDataModel 
{
    [Table("Inwestycja")]
    public class Inwestment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int docId { get; set; }
        public string name { get; set; }
        public decimal initialValue { get; set; }
        public decimal finalValue { get; set; }
    }

    [Table("Inwestycja2")]
    public class Inwestment2
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int docId { get; set; }
        public string name { get; set; }
        public decimal initialValue { get; set; }
    }
}

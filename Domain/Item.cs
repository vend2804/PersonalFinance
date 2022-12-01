using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Item
    {
        [Key]
        public int Item_Id { get; set; }
        public string Item_Name { get; set; }

        public string Item_Desc { get; set; }
        public string Created_By { get; set; }

        public DateTime Entry_Date { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Category")]
        public virtual int Cat_Id { get; set; }

        [ForeignKey("Cat_Id")]
        public virtual Category Category { get; set; }
    }
}
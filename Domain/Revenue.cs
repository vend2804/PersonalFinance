using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain
{
    public class Revenue
    {
        [Key]
        public int Rev_Id { get; set; }

        [Display(Name = "Item")]
        public virtual int Item_Id { get; set; }

        public string Rev_Desc { get; set; }

        public decimal Rev_Amount { get; set; }

        public int Rev_By { get; set; }

        public DateTime Rev_Date { get; set; }

        public string Rev_Month_Year { get; set; }

        public bool Finalized { get; set; }

        [ForeignKey("Item_Id")]
        public virtual Item Item { get; set; }

    }
}
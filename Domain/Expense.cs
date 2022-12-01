using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain
{
    public class Expense
    {
        [Key]
        public int Exp_Id { get; set; }

        [Display(Name = "Item")]
        public virtual int Item_Id { get; set; }

        public string Exp_Desc { get; set; }

        public decimal Exp_Amount { get; set; }

        public int Exp_By { get; set; }

        public DateTime Exp_Date { get; set; }

        public string Exp_Month_Year { get; set; }

        public bool Finalized { get; set; }

        [ForeignKey("Item_Id")]
        public virtual Item Item { get; set; }

    }
}
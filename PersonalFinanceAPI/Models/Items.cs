using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinance.Models
{
    public class Items
    {
        [Key]
        public int Item_Id { get; set; }
        public string? Item_Name { get; set; }

        public string? Item_Desc { get; set; }
        public string? Created_By { get; set; }

        public DateTime Entry_Date { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Categories")]
        public virtual int Cat_Id { get; set; }

        [ForeignKey("Cat_Id")]
        public virtual Categories? Categories { get; set; }


    }
}

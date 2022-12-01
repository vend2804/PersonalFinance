using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Category
    {
         [Key]
        public int Cat_Id { get; set; }
        public string Cat_Name { get; set; }

        public string Cat_Description { get; set; }

        public string Created_By { get; set; }

        public DateTime Entry_Date { get; set; }

        public bool IsActive { get; set; }

    }
}
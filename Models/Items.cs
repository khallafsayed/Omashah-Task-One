using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Omashah_Task_One.Models
{
    public partial class Item
    {
        public int Id { get; set; } 
        public string Name { get; set; } = "";
        public string Link { get; set; } = "";

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Published_Date_From { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Published_Date_To { get; set; }



    }
    
}

//steps to fineshed task 
// 1- creat calss 
// 2- create function to creat list items
// 3- create views

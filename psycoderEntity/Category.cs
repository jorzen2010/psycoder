using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace psycoderEntity
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryInfo { get; set; }
        public int CategoryParentID { get; set; }
        public bool CategoryStatus { get; set; }
        public int CategorySort { get; set; }

        [NotMapped]
        public string CategoryParentName { get; set; }
        [NotMapped]
        public List<Category> ChildCategory { get; set; }
    }

    public class bvnode
    {
        public string text;
        public int pid;
        public int id;
        public List<bvnode> nodes;
    }
}

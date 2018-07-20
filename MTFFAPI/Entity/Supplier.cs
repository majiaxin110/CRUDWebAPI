using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SqlSugar;

namespace MTFFAPI.Entity
{
    //[SugarTable("DBTA.TESTER")]
    public class Supplier
    {
        public string SupplierID { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
    }

    [SugarTable("Supplier")]
    public class SupplierCreation
    {
        [Required(ErrorMessage = "ID is necessary")]
        public string SupplierID { get; set; }

        [Required(ErrorMessage = "Name is necessary")]
        public string Name { get; set; }

        [MaxLength(11, ErrorMessage = "{0}长度不可超过{1}")]
        public string Telephone { get; set; }
    }

    [SugarTable("Supplier")]
    public class SupplierModification
    {
        [Required(ErrorMessage = "ID is necessary")]
        public string SupplierID { get; set; }

        [Required(ErrorMessage = "Name is necessary")]
        public string Name { get; set; }

        [MaxLength(11, ErrorMessage = "{0}长度不可超过{1}")]
        public string Telephone { get; set; }
    }
}

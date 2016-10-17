using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeEntityModel.BdcModel1
{
    /// <summary>
    /// This class contains the properties for Entity1. The properties keep the data for Entity1.
    /// If you want to rename the class, don't forget to rename the entity in the model xml as well.
    /// </summary>
    public partial class Entity1
    {
        public Int32 BusinessEntityID { get; set; }
        public string NationalIDNumber { get; set; }
        public string LoginID { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public char MaritalStatus { get; set; }
        public char Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool SalariedFlag { get; set; }
        public Int16 VacationHours { get; set; }
        public Int16 SickLeaveHours { get; set; }
        public bool CurrentFlag { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}

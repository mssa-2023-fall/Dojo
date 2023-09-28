using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DTO
{
    public class EmployeeDTO
    {
        public int Employee_Key { get; set; }
        public int WWI_Employee_ID { get; set; }
        public string Employee { get; set; }
        public string Preferred_Name { get; set; }
        public bool Is_Salesperson { get; set; }
        public byte[] Photo { get; set; }
        public DateTime Valid_From { get; set; }
        public DateTime Valid_To { get; set; }
        public int Lineage_Key { get; set; }

        public EmployeeDTO(int Employee_Key_, int WWI_Employee_ID_, string Employee_, string Preferred_Name_, bool Is_Salesperson_, byte[] Photo_, DateTime Valid_From_, DateTime Valid_To_, int Lineage_Key_)
        {
            this.Employee_Key = Employee_Key_;
            this.WWI_Employee_ID = WWI_Employee_ID_;
            this.Employee = Employee_;
            this.Preferred_Name = Preferred_Name_;
            this.Is_Salesperson = Is_Salesperson_;
            this.Photo = Photo_;
            this.Valid_From = Valid_From_;
            this.Valid_To = Valid_To_;
            this.Lineage_Key = Lineage_Key_;
        }
    }
}

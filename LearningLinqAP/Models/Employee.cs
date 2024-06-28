using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningLinqAP.Models
{
    /// <summary>
    /// 社員
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// 社員ID
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 部門ID
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 給与
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// 入社日
        /// </summary>
        public DateTime JoinDate { get; set; }
    }
}

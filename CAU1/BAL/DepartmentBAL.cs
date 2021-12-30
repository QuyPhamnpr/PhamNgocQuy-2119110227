using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAU1.DAL;
using CAU1.Model;

namespace CAU1.BAL
{
   public class DepartmentBAL
    {
        DepartmentDAL dal = new DepartmentDAL();
        public List<Department> ReadAreaList()
        {
            List<Department> lstDepart = dal.ReadAreaList();
            return lstDepart;
        }
    }
}

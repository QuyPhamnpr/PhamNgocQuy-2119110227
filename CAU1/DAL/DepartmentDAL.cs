using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAU1.Model;

namespace CAU1.DAL
{
    public class DepartmentDAL : DBConnection
    {
        public List<Department> ReadAreaList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Department> lstDepartment = new List<Department>();
            while (reader.Read())
            {
                Department Depart = new Department();
                Depart.IdDepartment = int.Parse(reader["IdDepartment"].ToString());
                Depart.Name_Department = reader["name_department"].ToString();
                lstDepartment.Add(Depart);
            }
            conn.Close();
            return lstDepartment;
        }
        public Department ReadArea(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "select * from Department where IdDepartment=" + id.ToString(), conn);
            Department Department = new Department();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                Department.IdDepartment = int.Parse(reader["IdDepartment"].ToString());
                Department.Name_Department = reader["name_department"].ToString();
            }
            conn.Close();
            return Department;
        }
    }
}

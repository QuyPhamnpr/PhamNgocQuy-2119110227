﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAU1.BAL;
using CAU1.Model;

namespace CAU1
{
    public partial class Form1 : Form
    {
        EmployeeBAL EmployBAL = new EmployeeBAL();
        DepartmentBAL DepartmentBAL = new DepartmentBAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void dgvNhanVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvNhanVien.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbId.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                dtBirth.Text = row.Cells[2].Value.ToString();
                tbGender.Text = row.Cells[3].Value.ToString();
                tbPlaceBirth.Text = row.Cells[4].Value.ToString();
                cbDepartment.Text = row.Cells[5].Value.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Employee> lstEmploy = EmployBAL.ReadCustomer();
            foreach (Employee Emp in lstEmploy)
            {
                dgvNhanVien.Rows.Add(Emp.IdEmployee, Emp.Name, Emp.DateBirth, Emp.Gender, Emp.PlaceBirth, Emp.Depart );

            }
            List<Department> lstDepart = DepartmentBAL.ReadAreaList();
            foreach (Department depart in lstDepart)
            {
                cbDepartment.Items.Add(depart);
            }
            cbDepartment.DisplayMember = "Name_department";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                Employee emp = new Employee();
                emp.IdEmployee = tbId.Text;
                emp.Name = tbName.Text;
                emp.DateBirth = DateTime.Parse(dtBirth.Value.Date.ToString());
                emp.Gender = tbGender.Text;
                emp.PlaceBirth = tbPlaceBirth.Text;
                emp.Department = (Department)cbDepartment.SelectedItem;



                EmployBAL.NewEmployee(emp);

                dgvNhanVien.Rows.Add(emp.IdEmployee, emp.Name, emp.DateBirth, emp.Gender, emp.PlaceBirth, emp.Department.Name_Department);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                DataGridViewRow row = dgvNhanVien.CurrentRow;

                Employee empp = new Employee();
                empp.IdEmployee = tbId.Text;
                empp.Name = tbName.Text;
                empp.DateBirth = DateTime.Parse(dtBirth.Value.Date.ToString());
                empp.Gender = tbGender.Text;
                empp.PlaceBirth = tbPlaceBirth.Text;
                empp.Department = (Department)cbDepartment.SelectedItem;

                EmployBAL.EditEmployee(empp);

                row.Cells[0].Value = empp.IdEmployee;
                row.Cells[1].Value = empp.Name;
                row.Cells[2].Value = empp.DateBirth;
                row.Cells[3].Value = empp.Gender;
                row.Cells[4].Value = empp.PlaceBirth;
                row.Cells[5].Value = empp.Department;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.IdEmployee = tbId.Text;
            emp.Name = tbName.Text;
            emp.DateBirth = DateTime.Parse(dtBirth.Value.Date.ToString());
            emp.Gender = tbGender.Text;
            emp.PlaceBirth = tbPlaceBirth.Text;


            EmployBAL.DeleteEmployee(emp);
            int idx = dgvNhanVien.CurrentCell.RowIndex;
            dgvNhanVien.Rows.RemoveAt(idx);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Ban co thuc su muon thoat?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (f == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
        public bool checkData()
        {
            if (string.IsNullOrWhiteSpace(tbId.Text))
            {
                MessageBox.Show("Chưa Nhập Mã", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Chưa nhập Tên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbPlaceBirth.Text))
            {
                MessageBox.Show("Chưa nhập Nơi Sinh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(dtBirth.Text))
            {
                MessageBox.Show("Chưa nhập Ngày Sinh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbGender.Text))
            {
                MessageBox.Show("Chưa nhập Giới Tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbDepartment.Text))
            {
                MessageBox.Show("Chưa nhập Đơn Vị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
           
            return true;
        }
    }
}

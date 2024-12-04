using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTVNBuoi4
{
    public partial class Form1 : Form
    {
        public List<Employee> employees = new List<Employee>();
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo danh sách nhân viên ban đầu
            employees.Add(new Employee { Id = "NV001", Name = "Nguyễn Thị Thu Hằng", Salary = 8500000 });
            employees.Add(new Employee { Id = "NV002", Name = "Nguyễn Trần Minh Trí", Salary = 6500000 });
            RefreshGridView();
        }

        public void RefreshGridView()
        {
            dtgEmployees.DataSource = null;
            dtgEmployees.DataSource = employees;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var form2 = new Form2(this, null);
            form2.EmployeeAdded += employee =>
            {
                employees.Add(employee);
                RefreshGridView();
            };
            form2.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedEmployee = (Employee)dtgEmployees.SelectedRows[0].DataBoundItem;
            var form2 = new Form2(this, selectedEmployee);
            form2.EmployeeUpdated += employee =>
            {
                RefreshGridView(); // Cập nhật danh sách
            };
            form2.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedEmployee = (Employee)dtgEmployees.SelectedRows[0].DataBoundItem;
            employees.Remove(selectedEmployee);
            RefreshGridView();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static BTVNBuoi4.Form1;

namespace BTVNBuoi4
{
    public partial class Form2 : Form
    {
        // Sử dụng event để thông báo khi có thay đổi
        public event Action<Employee> EmployeeAdded;
        public event Action<Employee> EmployeeUpdated;

        private Employee _employee;

        public Form2(Form1 form1, Employee employee = null)
        {
            InitializeComponent();
            _employee = employee;

            if (_employee != null) // Chế độ chỉnh sửa
            {
                txtID.Text = _employee.Id;
                txtID.Enabled = false; // Không cho phép chỉnh sửa ID
                txtName.Text = _employee.Name;
                txtSalary.Text = _employee.Salary.ToString();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnDongy_Click(object sender, EventArgs e)
        {
            // Xác thực dữ liệu
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                !double.TryParse(txtSalary.Text, out double salary) || salary < 0)
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_employee == null) // Chế độ thêm mới
            {
                var newEmployee = new Employee
                {
                    Id = txtID.Text,
                    Name = txtName.Text,
                    Salary = salary
                };

                EmployeeAdded?.Invoke(newEmployee); // Gửi sự kiện thêm
            }
            else // Chế độ chỉnh sửa
            {
                _employee.Name = txtName.Text;
                _employee.Salary = salary;

                EmployeeUpdated?.Invoke(_employee); // Gửi sự kiện chỉnh sửa
            }

            this.Close();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

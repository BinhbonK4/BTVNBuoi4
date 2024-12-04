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
        private Form1 _form1; // Tham chiếu đến Form1
        private Employee _employee; // Nhân viên cần sửa (nếu có)
       
        public Form2(Form1 form1, Employee employee = null)
        {
            InitializeComponent();
            _form1 = form1;
            _employee = employee;

            if (_employee != null)
            {
                // Hiển thị thông tin nhân viên nếu đang sửa
                txtID.Text = _employee.Id;
                txtName.Text = _employee.Name;
                txtSalary.Text = _employee.Salary.ToString();
                txtID.Enabled = false; // Không cho phép sửa MSNV
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnDongy_Click(object sender, EventArgs e)
        {
            if (_employee == null) // Trường hợp thêm mới
            {
                Employee newEmployee = new Employee
                {
                    Id = txtID.Text,
                    Name = txtName.Text,
                    Salary = double.Parse(txtSalary.Text)
                };

                _form1.employees.Add(newEmployee); // Thêm vào danh sách
            }
            else // Trường hợp sửa
            {
                _employee.Name = txtName.Text;
                _employee.Salary = double.Parse(txtSalary.Text);
            }

            _form1.RefreshGridView(); // Làm mới DataGridView
            this.Close(); // Đóng Form2
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

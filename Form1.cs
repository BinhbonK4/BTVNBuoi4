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
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgEmployees.SelectedRows.Count > 0)
            {
                // Lấy nhân viên được chọn
                int index = dtgEmployees.SelectedRows[0].Index;
                Employee selectedEmployee = employees[index];

                Form2 form2 = new Form2(this, selectedEmployee);
                form2.ShowDialog(); // Hiển thị Form2 dưới dạng modal
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgEmployees.SelectedRows.Count > 0)
            {
                int index = dtgEmployees.SelectedRows[0].Index;
                employees.RemoveAt(index);
                RefreshGridView();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

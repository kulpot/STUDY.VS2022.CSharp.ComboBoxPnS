using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ComboBoxPnS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sunny\Documents\HouseRental.mdf;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand("select LLId from LandLordTbl", Con);
            //SqlCommand cmd = new SqlCommand("select CNum from CategoryTbl", Con);
            SqlCommand cmd = new SqlCommand("select TenId from TenantTbl", Con);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            /// Set Default Value
            DataRow itemrow = dt.NewRow();
            itemrow[0] = "123";
            
            dt.Rows.InsertAt(itemrow, 0);
            

            comboBox1.DataSource = dt;
            //comboBox1.ValueMember = "LLId";
            //comboBox1.DisplayMember = "Remarks";
            //comboBox1.ValueMember = "CNum";
            //comboBox1.DisplayMember = "Category";
            comboBox1.ValueMember = "TenId";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            label1.Text= comboBox1.SelectedValue.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_w6_stanley
{
    public partial class Form1 : Form
    {
        DataTable data1 = new DataTable();
        DataTable data2 = new DataTable();
        DataTable data3 = new DataTable();
        int x = 5;
        int check = 0;
        string ID;
        int checkNO = 0;
        int simpenNO = 0;
        string menyusun;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data1.Columns.Add("ID Product");
            data1.Columns.Add("Nama Product");
            data1.Columns.Add("Harga");
            data1.Columns.Add("Stock");
            data1.Columns.Add("ID Category");

            data1.Rows.Add("J001", "Jas Hitam", "100000", "10", "C1");
            data1.Rows.Add("T001", "T-Shirt Black Pink", "70000", "20", "C2");
            data1.Rows.Add("T002", "T-Shirt Obsessive", "75000", "16", "C2");
            data1.Rows.Add("R001", "Rok mini", "82000", "26", "C3");
            data1.Rows.Add("J002", "Jeans Biru", "90000", "5", "C4");
            data1.Rows.Add("C001", "Celana Pendek Coklat", "60000", "11", "C4");
            data1.Rows.Add("C002", "Cawat Blink-blink", "1000000", "1", "C5");
            data1.Rows.Add("R002", "Rocca", "50000", "8", "C2");

            data2.Columns.Add("ID Category");
            data2.Columns.Add("Nama Category");

            data2.Rows.Add("C1", "Jas");
            data2.Rows.Add("C2", "T-Shirt");
            data2.Rows.Add("C3", "Rok");
            data2.Rows.Add("C4", "Celana");
            data2.Rows.Add("C5", "Cawat");

            dataGridView1.DataSource = data1;
            dataGridView2.DataSource = data2;
            data3 = data1.Copy();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            data3.Rows.Clear(); 
            foreach(DataRow item2 in data2.Rows)
            {
                if(comboBox1.SelectedItem.ToString() == item2[1].ToString())
                {
                    foreach(DataRow item1 in data1.Rows)
                    {
                        if (item2[0] == item1[4])
                        {
                            data3.Rows.Add(item1[0], item1[1], item1[2], item1[3], item1[4]);
                        }
                    }
                }
            }
            dataGridView1.DataSource = data3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            dataGridView1.DataSource = data1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox4.Text == "")
            {
                MessageBox.Show("error");
            }
            else
            {
                foreach (DataRow item2 in data2.Rows)
                {
                    if (textBox4.Text == item2[1].ToString())
                    {
                        check = 1;
                    }
                }
                if(check == 1 )
                {
                    MessageBox.Show("broken");
                }
                else
                {
                    x++;
                    data2.Rows.Add(("C" + x), textBox4.Text);
                    comboBox1.Items.Add(textBox4.Text);
                    comboBox2.Items.Add(textBox4.Text);
                }    
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach(DataRow item2 in data2.Rows)
            {
                if((dataGridView2.SelectedCells[1].Value.ToString()) == item2[1].ToString())
                {
                    data2.Rows.Remove(item2);
                    break;
                }
            }
            for(int i = data1.Rows.Count - 1; i >= 0; i--)
            {
                if (data1.Rows[i][4].ToString()== dataGridView2.SelectedCells[0].Value.ToString())
                {
                    data1.Rows.RemoveAt(i);
                }
            }
            comboBox1.Items.Remove(dataGridView2.SelectedCells[1].Value.ToString());
            comboBox2.Items.Remove(dataGridView2.SelectedCells[1].Value.ToString());
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView2.SelectedCells[1].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("ERRORRRR");
            }
            else
            {
                foreach(DataRow combobox2 in data2.Rows)
                {
                    if(comboBox2.Text == combobox2[1].ToString())
                    {
                        ID = combobox2[0].ToString();
                    }
                }
                foreach (DataRow check in data1.Rows)
                {
                    if (textBox1.Text[0].ToString().ToUpper() == check[0].ToString()[0].ToString())
                    {
                        checkNO = Convert.ToInt32(check[0].ToString().Substring(1));
                        if (checkNO >= simpenNO)
                        {
                            simpenNO = checkNO ;
                        }
                    }
                }
                simpenNO += 1;
                menyusun = textBox1.Text[0].ToString().ToUpper();
                for (int i = simpenNO.ToString().Length; i < 3; i++)
                {
                    menyusun += "0";
                }
                menyusun += Convert.ToString(simpenNO);
                data1.Rows.Add(menyusun,textBox1.Text, textBox2.Text, textBox3.Text, ID);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "0")
            {
                data1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                data1.Rows[dataGridView1.SelectedRows[0].Index][1] = textBox1.Text;
                data1.Rows[dataGridView1.SelectedRows[0].Index][2] = textBox2.Text;
                data1.Rows[dataGridView1.SelectedRows[0].Index][3] = textBox3.Text;
                foreach (DataRow combobox2 in data2.Rows)
                {
                    if (comboBox2.Text == combobox2[1].ToString())
                    {
                        data1.Rows[dataGridView1.SelectedRows[0].Index][4] = combobox2[0].ToString();
                    }
                }
                foreach (DataRow check in data1.Rows)
                {
                    if (textBox1.Text[0].ToString().ToUpper() == check[0].ToString()[0].ToString())
                    {
                        checkNO = Convert.ToInt32(check[0].ToString().Substring(1));
                        if (checkNO >= simpenNO)
                        {
                            simpenNO = checkNO;
                        }
                    }
                }
                simpenNO += 1;
                menyusun = textBox1.Text[0].ToString().ToUpper();
                for (int i = simpenNO.ToString().Length; i < 3; i++)
                {
                    menyusun += "0";
                }
                menyusun += Convert.ToString(simpenNO);
                data1.Rows[dataGridView1.SelectedRows[0].Index][0] = menyusun;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[3].Value.ToString();
            foreach (DataRow combobox2 in data2.Rows)
            {
                if (dataGridView1.SelectedCells[4].Value.ToString() == combobox2[0].ToString())
                {
                    comboBox2.Text = combobox2[1].ToString();
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataRow item1 in data1.Rows)
            {
                if (dataGridView1.SelectedCells[1].Value.ToString() == item1[1].ToString())
                {
                    data1.Rows.Remove(item1);
                    break;
                }
            }
        }
    }
}

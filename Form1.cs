using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MassIndex_calculator
{
    public partial class Form1 : Form
    {
        private string connString;
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder commandBuilder;
        private DataTable table = new DataTable("ValoriIndecsi");
        public Form1()
        {
            InitializeComponent();
        }

        

        private void LoadData()
        {
            table.Clear();
            adapter.Fill(table);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connString = ConfigurationManager.ConnectionStrings["Indecsi"].ConnectionString;
            connection = new SqlConnection(connString);

            adapter = new SqlDataAdapter(
                "SELECT Id, Mass, Height, Date, BMI, PI FROM dbo.ValoriIndecsi",
                connection);

            commandBuilder = new SqlCommandBuilder(adapter);

            table = new DataTable();

            dataGridView1.AutoGenerateColumns = false;

            // 1. Create columns first
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", ReadOnly = true });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Mass", HeaderText = "Mass" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Height", HeaderText = "Height" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Date", HeaderText = "Date" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BMI", HeaderText = "BMI" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PI", HeaderText = "PI" });


            // 2. IMPORTANT: bind here
            dataGridView1.DataSource = table;

            // 3. Load data AFTER binding
            LoadData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float masa = float.Parse(textBox1.Text);
            float inaltime = float.Parse(textBox2.Text);
            BMICalculator BMI = new BMICalculator(inaltime, masa);
            PICalculator PI = new PICalculator(inaltime, masa);



            textBox3.Text = BMI.Calculate();
            textBox4.Text = PI.Calculate();

            textBox5.Text = BMI.WeightCategory();
            textBox6.Text = PI.WeightCategory();



            textBox7.Text = BMI.IdealWeight();
            textBox8.Text = PI.IdealWeight();

        }



        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }


        

        private void button2_Click_1(object sender, EventArgs e)
        {
         
            // Validate input
            if (!float.TryParse(textBox1.Text, out float mass) ||
                !float.TryParse(textBox2.Text, out float height))
            {
                MessageBox.Show("Please enter valid numbers for Mass and Height.");
                return;
            }

            // Parse BMI and PI from textboxes (already calculated)
            if (!double.TryParse(textBox3.Text, out double bmi) ||
                !double.TryParse(textBox4.Text, out double pi))
            {
                MessageBox.Show("BMI or PI values are invalid.");
                return;
            }

            try
            {
                // Create new row
                DataRow newRow = table.NewRow();
                newRow["Mass"] = Math.Round(mass,2);
                newRow["Height"] = Math.Round(height,2);
                newRow["Date"] = DateTime.Now;          // store current date
                newRow["BMI"] = Math.Round(bmi, 2);     // round if needed
                newRow["PI"] = Math.Round(pi, 2);

                // Optionally, store categories/ideal weights
                // newRow["BMICategory"] = textBox5.Text;
                // newRow["PICategory"] = textBox6.Text;
                // newRow["IdealBMI"] = textBox7.Text;
                // newRow["IdealPI"] = textBox8.Text;

                table.Rows.Add(newRow);

                // Update database
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(table);

                // Refresh DataGridView
                LoadData();

                MessageBox.Show("Data saved successfully!");


                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


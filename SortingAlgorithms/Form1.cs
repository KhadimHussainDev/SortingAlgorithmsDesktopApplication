using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SortingAlgorithms.BL;
using SortingAlgorithms.DL;


namespace SortingAlgorithms
{

    public partial class Form1 : Form
    {
        private void loadComboBox()
        {
            List<string> records = new List<string>();
            records.Add("100 Records");
            records.Add("1000 Records");
            records.Add("10000 Records");
            records.Add("100000 Records");
            records.Add("500000 Records");
            comboBox1.DataSource = records;
            List<string> records2 = new List<string>();
            records2.Add("1.Bubble Sort");
            records2.Add("2.Selection Sort");
            records2.Add("3.Insertion Sort");
            records2.Add("4.Merge Sort");
            records2.Add("5.Quick Sort");
            records2.Add("6.Heap Sort");
            records2.Add("7.Counting Sort");
            records2.Add("8.Radix Sort");
            records2.Add("9.Bucket Sort");
            comboBox2.DataSource = records2;
            List<string> records3 = new List<string>();
            records3.Add("1.Index");
            records3.Add("2.No Of Employees");
            comboBox3.DataSource = records3;
        }

        public Form1()
        {
            InitializeComponent();
            loadComboBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadbtn.Enabled = true;
        }

        private void loadbtn_Click(object sender, EventArgs e)
        {
            string Data_of_100_Records = "organizations-100.csv";
            string Data_of_1000_Records = "organizations-1000.csv";
            string Data_of_10000_Records = "organizations-10000.csv";
            string Data_of_100000_Records = "organizations-100000.csv";
            string Data_of_500000_Records = "organizations-500000.csv";
            if (comboBox1.SelectedIndex == 0)
            {
                CompanyDL.loadData(Data_of_100_Records);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                CompanyDL.loadData(Data_of_1000_Records);

            }
            else if (comboBox1.SelectedIndex == 2)
            {
                CompanyDL.loadData(Data_of_10000_Records);
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                CompanyDL.loadData(Data_of_100000_Records);

            }
            else if (comboBox1.SelectedIndex == 4)
            {
                CompanyDL.loadData(Data_of_500000_Records);
            }
            bindData();
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            sortbtn.Enabled = true;
        }

        private void bindData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = CompanyDL.Companies;
            dataGridView1.Refresh();
        }

        private void sortbtn_Click(object sender, EventArgs e)
        {
            int sortAlgorithm = comboBox2.SelectedIndex;
            int idx = comboBox3.SelectedIndex;
            int size = CompanyDL.Companies.Count - 1;
            if (idx == 0)
            {
                if (sortAlgorithm == 0)
                {
                    CompanyDL.Companies = CompanyDL.bubbleSortWithIndex(CompanyDL.Companies, size);
                    bindData();
                }
                else if (sortAlgorithm == 1)
                {
                    CompanyDL.Companies = CompanyDL.selectionSortWithIndex(CompanyDL.Companies, size);
                    bindData();
                }
                else if (sortAlgorithm == 2)
                {
                    CompanyDL.Companies = CompanyDL.insertionSortWithIndex(CompanyDL.Companies, size);
                    bindData();
                }
                else if (sortAlgorithm == 3)
                {
                    CompanyDL.Companies = CompanyDL.mergeSortWithIndex(CompanyDL.Companies, 0, size);
                    bindData();
                }
                else if (sortAlgorithm == 4)
                {
                    // CompanyDL.quickSortWithIndex(CompanyDL.Companies, size);
                    bindData();
                }
                else if (sortAlgorithm == 5)
                {
                    // CompanyDL.heapSortWithIndex(CompanyDL.Companies, size);
                    bindData();
                }
                else if (sortAlgorithm == 6)
                {
                    CompanyDL.Companies = CompanyDL.countingSortWithIndex(CompanyDL.Companies);
                    bindData();
                }
                else if (sortAlgorithm == 7)
                {
                    CompanyDL.Companies = CompanyDL.radixSortWithIndex(CompanyDL.Companies);
                    bindData();
                }
                else if (sortAlgorithm == 8)
                {
                    CompanyDL.Companies = CompanyDL.bucketSortWithIndex(CompanyDL.Companies, 500001);
                    bindData();
                }
            }
            else
            {
                if (sortAlgorithm == 0)
                {
                    CompanyDL.Companies = CompanyDL.bubbleSortWithEmployees(CompanyDL.Companies, size);
                    bindData();
                }
                else if (sortAlgorithm == 1)
                {
                    CompanyDL.Companies = CompanyDL.selectionSortWithEmployees(CompanyDL.Companies, size);
                    bindData();
                }
                else if (sortAlgorithm == 2)
                {
                    CompanyDL.Companies = CompanyDL.insertionSortWithEmployees(CompanyDL.Companies, size);
                    bindData();
                }
                else if (sortAlgorithm == 3)
                {
                    CompanyDL.Companies = CompanyDL.mergeSortWithEmployees(CompanyDL.Companies, 0, size);
                    bindData();
                }
                else if (sortAlgorithm == 4)
                {
                    CompanyDL.Companies = CompanyDL.quickSortWithEmployees(CompanyDL.Companies, 0, size);
                    bindData();
                }
                else if (sortAlgorithm == 5)
                {
                    CompanyDL.Companies = CompanyDL.heapSortWithEmployees(CompanyDL.Companies, size);
                    bindData();
                }
                else if (sortAlgorithm == 6)
                {
                    CompanyDL.Companies = CompanyDL.countingSortWithEmployees(CompanyDL.Companies);
                    bindData();
                }
                else if (sortAlgorithm == 7)
                {
                    CompanyDL.Companies = CompanyDL.radixSortWithEmployees(CompanyDL.Companies);
                    bindData();
                }
                else if (sortAlgorithm == 8)
                {
                    CompanyDL.Companies = CompanyDL.bucketSortWithEmployyees(CompanyDL.Companies, 10000);
                    bindData();
                }
            }
        }
    }
}

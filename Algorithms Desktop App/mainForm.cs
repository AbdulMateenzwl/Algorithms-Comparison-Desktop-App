using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Algorithms_Desktop_App.BL;
using Algorithms_Desktop_App.DL;
using ComponentFactory.Krypton.Toolkit;
namespace Algorithms_Desktop_App
{
    public partial class mainForm : KryptonForm
    {
        Data organizations = new Data();
        List<string> filenames = new List<string>() { "organizations-100.csv", "organizations-1000.csv", "organizations-10000.csv", "organizations-100000.csv", "organizations-500000.csv", "temp.csv" };
        List<string> sortType = new List<string>() { "Selection Sort ", "Bubble Sort ", "Insertion Sort ", "Merge Sort ", "Quick Sort", "Heap Sort", "Counting Sort", "Radix Sort", "Bucket Sort" };
        List<string> sortBy = new List<string>() { "by Index", "by No of Employees" };

        bool working = false;

        private void mainForm_Load(object sender, EventArgs e)
        {
            cmBoxLoadFiles.DataSource = filenames;
            cmBoxSorttype.DataSource = sortType;
            cmBoxsortBy.DataSource = sortBy;

            dataBind(organizations.get_Data());
        }
        public mainForm()
        {
            InitializeComponent();
            organizations.set_Data(OrganizationDl.load_data(filenames[0]));
            dataBind(organizations.get_Data());
        }
        public void dataBind(List<Org> list)
        {
            GridGV.DataSource = null;
            GridGV.DataSource = list.Select(c => new { c.index, c.org_id, c.name, c.website, c.country, c.no_emp }).ToList();
            //GridGV.DataSource = list;
            GridGV.Refresh();
        }

        private void showTime(long time)
        {
            MessageBox.Show("Time Taken : " + time.ToString() + " ms");
        }

        private void kryptonButton3_Click_1(object sender, EventArgs e)
        {
            OrganizationDl.storeData(organizations.get_Data());

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (!working)
            {
                ThreadStart s = new ThreadStart(sortDataThread);
                Thread thread1 = new Thread(s);
                thread1.Start();
                working = true;
            }
        }
        private void sortDataThread()
        {
            try
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                organizations.set_Data(organizations.sortData(cmBoxSorttype.SelectedIndex, cmBoxsortBy.SelectedIndex, organizations.get_Data()));
                dataBind(organizations.get_Data());
                watch.Stop();
                showTime(watch.ElapsedMilliseconds);
                working = false;
            }
            catch(IndexOutOfRangeException)
            {
                MessageBox.Show("The Data you Given for Sorting Purpose is invalid.");
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("The file you are trying to read Data from is not found.");
            }
            catch(OutOfMemoryException)
            {
                MessageBox.Show("Memory Limit reached.");
            }
            catch(TimeoutException)
            {
                MessageBox.Show("Time Limit Reached.");
            }
        }
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (!working)
            {
                ThreadStart thread = new ThreadStart(loadDataThread);
                Thread thread1 = new Thread(thread);
                thread1.Start();
                working = true;
            }
        }
        private void loadDataThread()
        {
            try
            {
                organizations.set_Data(OrganizationDl.load_data(filenames[cmBoxLoadFiles.SelectedIndex]));
                dataBind(organizations.get_Data());
                working = false;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("The Data you Given for Sorting Purpose is invalid.");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file you are trying to read Data from is not found.");
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Memory Limit reached.");
            }
            catch (TimeoutException)
            {
                MessageBox.Show("Time Limit Reached.");
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GridGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmBoxSorttype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


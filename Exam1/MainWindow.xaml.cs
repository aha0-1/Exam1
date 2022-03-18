using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exam1
{
    public class Student
    {
        public string studentID;
        public string studentName;
        public double exam1;
        public double exam2;
        public double exam3;

        public Student()
        {

        }
        public Student(string id, string n, double ex1, double ex2, double ex3)
        {
            this.studentID = id;
            this.studentName = n;
            this.exam1 = ex1;
            this.exam2 = ex2;
            this.exam3 = ex3;
        }
        public override string ToString()
        {
            string message = string.Format("ID:{0},Name{1}", this.studentID, this.studentName);
            return message;
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> studentList;
        public MainWindow()
        {
            studentList = new List<Student>();
            InitializeComponent();
            this.StudentRosterLB.ItemsSource = studentList;
        }

        private void AddBtn_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            string id = this.IDTB.Text;
            string n = this.NameTB.Text;
            double ex1 = Convert.ToDouble(this.Ex1TB.Text);
            double ex2 = Convert.ToDouble(this.Ex2Tb.Text);
            double ex3 = Convert.ToDouble(this.Ex3TB.Text);
            Student student = new Student(id, n, ex1, ex2, ex3);
            this.studentList.Add(student);
            this.StudentRosterLB.Items.Refresh();

            double averagegrade = (ex1 + ex2 + ex3)/3;
            //double averagegrade = 0;
            //for (int i =0;i<this.studentList.Count; i++)
            //{
            //    sumgrade += this.studentList.Count;
            //}
            //averagegrade = sumgrade/this.studentList.Count;
            AvgGrTB.Text=averagegrade.ToString();
        }

        private void StudentRosterLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(this.StudentRosterLB.SelectedIndex != -1)
            {
                Student selectedStudent=(Student)this.StudentRosterLB.SelectedItem;
                string message = string.Format("ID:{0}\nName:{1}\nExam1:{2}\nExam2:{3}\nExam 3:{4}", selectedStudent.studentID, selectedStudent.studentName, selectedStudent.exam1, selectedStudent.exam2, selectedStudent.exam3);
                MessageBox.Show(message);
            }
        }
    }
    
}
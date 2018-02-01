using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting_GUI
{
    public partial class Form1 : Form
    {
        const int xp = 100;
        const int NUMBER = 20;
        int[] a = new int[NUMBER];
        public Form1()
        {
            InitializeComponent();
            Random r = new Random();
            for (int i = 0; i < NUMBER; i++)
            {
                int t = r.Next(1000);
                a[i] = t;
            }
        }
        void BubbleSort1()
        {
            Graphics g = this.CreateGraphics();
            int x = xp;
            for (int i = 0; i < NUMBER; i++)
            {
                for (int j = i + 1; j < NUMBER - 1; j++)
                {
                    if (a[i] < a[j])
                    {
                        int t = a[i];
                        a[i] = a[j];
                        a[j] = t;
                        g.FillEllipse(new SolidBrush(Color.Blue), x++, 30, 10, 10);
                        Thread.Sleep(2);
                    }
                }
            }
        }
        void SelectionSort()
        {
            Graphics g = this.CreateGraphics();
            int x = xp;
            for (int i = 0; i < NUMBER - 1; i++)
            {
                int k = i;
                for (int j = i + 1; j < NUMBER; j++)
                    if (a[j] < a[k])
                    {
                        k = j;
                        g.FillEllipse(new SolidBrush(Color.Red), x++, 60, 10, 10);
                        Thread.Sleep(2);
                    }
                Swap(i, k);

            }
        }
        void InsertionSort()
        {
            Graphics g = this.CreateGraphics();
            int x = xp;
            for (int i = 1; i < NUMBER; i++)
            {
                int j = i - 1, k = a[i];
                for (; j > -1; j--)
                    if (k < a[j])
                    {
                        a[j + 1] = a[j];
                        g.FillEllipse(new SolidBrush(Color.DarkBlue), x++, 90, 10, 10);
                        Thread.Sleep(2);
                    }
                    else
                        break;
                a[j + 1] = k;
            }
        }
        void Swap(int i, int j)
        {
            int t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
        void BubbleSort2()
        {
            Graphics g = this.CreateGraphics();
            int x = xp;
            for (int i = 0; i < NUMBER; i++)
            {
                for (int j = i + 1; j < NUMBER - 1; j++)
                {
                    if (a[j] < a[j + 1])
                    {
                        int t = a[j + 1];
                        a[j + 1] = a[j];
                        a[j] = t;
                        g.FillEllipse(new SolidBrush(Color.Brown), x++, 120, 10, 10);
                        Thread.Sleep(2);
                    }
                }
            }
        }
        void DoMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[NUMBER];
            int i, left_end, num_elements, tmp_pos;
            Graphics g = this.CreateGraphics();
            int x = xp;
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);
            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
                g.FillEllipse(new SolidBrush(Color.Coral), x++, 150, 10, 10);
                Thread.Sleep(2);

            }
            while (left <= left_end)
            {
                temp[tmp_pos++] = numbers[left++];
                g.FillEllipse(new SolidBrush(Color.Coral), x++, 150, 10, 10);
                Thread.Sleep(2);
            }
            while (mid <= right)
            {
                temp[tmp_pos++] = numbers[mid++];
                g.FillEllipse(new SolidBrush(Color.Coral), x++, 150, 10, 10);
                Thread.Sleep(2);
            }
            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
        void MergeSort_Recursive(int[] numbers, int left, int right)
        {

            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort_Recursive(numbers, left, mid);
                MergeSort_Recursive(numbers, (mid + 1), right);
                //g.FillEllipse(new SolidBrush(Color.Coral), x++, 150, 10, 10);
                //Thread.Sleep(2);
                DoMerge(numbers, left, (mid + 1), right);
            }
        }
        void MergeSort()
        {
            int[] numbers = new int[NUMBER];
            Array.Copy(a, numbers, a.Length);
            int left = 0, right = numbers.Length - 1;
            MergeSort_Recursive(numbers, left, right);
        }
        void QuickSort()
        {
            int[] b = new int[NUMBER];
            Array.Copy(a, b, a.Length);
            DoQuickSort(b, 0, b.Length - 1);
        }
        void DoQuickSort(int[] a, int start, int end)
        {
            Graphics g = this.CreateGraphics();
            int x = xp;
            if (start >= end)
            {
                return;
            }

            int num = a[start];

            int i = start, j = end;

            while (i < j)
            {
                while (i < j && a[j] > num)
                {
                    j--;
                }

                a[i] = a[j];

                while (i < j && a[i] < num)
                {
                    i++;
                }
                a[j] = a[i];
                g.FillEllipse(new SolidBrush(Color.Black), x++, 180, 10, 10);
                Thread.Sleep(2);
            }

            a[i] = num;
            DoQuickSort(a, start, i - 1);
            DoQuickSort(a, i + 1, end);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(new ThreadStart(BubbleSort1));
            Thread t2 = new Thread(new ThreadStart(BubbleSort2));
            Thread t3 = new Thread(new ThreadStart(InsertionSort));
            Thread t4 = new Thread(new ThreadStart(SelectionSort));
            Thread t5 = new Thread(new ThreadStart(MergeSort));
            Thread t6 = new Thread(new ThreadStart(QuickSort));
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();
        }
    }
}
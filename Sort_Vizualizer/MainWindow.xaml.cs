using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Sort_Visualizer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
   
        int[] arr;
        int MAX_HEIGHT = 400;
        int MAX_WIDTH = 800;
        Rectangle[] rects;
        Thread sortingThread;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            sortingThread = new Thread(() =>
            {
              //  Bubble_sort();
                QuickSort();
               // MergeSort(0,arr.Length-1);
                Show_Res();
            });
            sortingThread.Start();

        }

        private void Init_Click(object sender, RoutedEventArgs e)
        {
            if(sortingThread != null)  sortingThread.Abort();
        
            string[] strs = Numbers.Text.Split(' ');
            arr = new int[strs.Length];
            
            for(int i = 0; i < strs.Length; i++)
            {
                arr[i] = int.Parse(strs[i]); 
            }
            if (arr.Min() < 0)
                MAX_HEIGHT /= 2;
            rects = new Rectangle[strs.Length];

            int dist = MAX_WIDTH / arr.Length;

            int max = Max(arr);
            int m_HEIGHT = MAX_HEIGHT / max;
         

            for(int i = 0; i < rects.Length; i++)
            {
                int width = 20;
                int height = 0;
                int top = 0;

                int left = dist * i;
                if(arr[i] < 0)
                {
                    height =  -1*arr[i] * m_HEIGHT ;
                    top = MAX_HEIGHT ;

                }
                else
                {
                    height =  m_HEIGHT * arr[i];
                    top = MAX_HEIGHT - height;
                }
               
                Rectangle rect = new Rectangle();
                rect.Fill = Brushes.Green;
                rect.Height = height;
                rect.Width = width;
                rect.Margin = new Thickness(left, top, 0, 0);
                rects[i] = rect;
                Zone.Children.Add(rect);

                
            }

        }


        private void Swap_Rect(int i, int j)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
             {
                 double first_Left = rects[i].Margin.Left;
                 double first_Top = rects[i].Margin.Top;
                 double second_Left = rects[j].Margin.Left;
                 double second_Top = rects[j].Margin.Top;
                 rects[i].Margin = new Thickness(second_Left, first_Top, 0, 0);
                 rects[j].Margin = new Thickness(first_Left, second_Top, 0, 0);

                 Rectangle temp = rects[i];
                 rects[i] = rects[j];
                 rects[j] = temp;
             });          
        }
        private void Set_Rect(int k, int j, Rectangle[] r)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                rects[k].Height = r[j].Height;
                rects[k].Margin = new Thickness(r[j].Margin.Left, r[j].Margin.Top, 0, 0);
                rects[k].Fill = Brushes.Orange;
               // rects[k] = r[j];


            });
        }

        private void Swap(int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
          
            Swap_Rect(i, j);
        }

        private void Bubble_sort()
        {
            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    Set_Orange(i, j);
                    if (arr[j] < arr[i])
                    {
                        Swap(i, j);
                    }
                    Thread.Sleep(300);
                    Set_Red(i, j);
                }
                Set_Gray(i);
            }

        }
        #region QuickSort
        private void QuickSort()
        {
            Quick(0, arr.Length-1);
        }

        private void Quick(int lo, int hi)
        {
            if (lo >= hi) return;
            int point = Partition(lo, hi);
            Quick(lo, point);
            Quick(point + 1, hi);

        }

        private int Partition(int lo, int hi)
        {
            int i = lo;
            int j = hi + 1;
            Set_Color(lo, Brushes.Purple);
            while(true)
            {
                while(arr[++i] < arr[lo])
                {
                    Set_Color(i , Brushes.Blue);
                    Thread.Sleep(400);
                    Set_Color(i , Brushes.Coral);
                    if (i == hi) break;
                }
                while(arr[lo] < arr[--j])
                {
                    Set_Color(j, Brushes.Blue);
                    Thread.Sleep(400);
                    Set_Color(j, Brushes.Coral);
                    if (j == lo) break;
                }
                Set_Orange(i, j);
                Thread.Sleep(300);
                if (i >= j) break;
                Swap(i, j);
            }
            Swap(lo, j);
            Thread.Sleep(300);
          
            return j;

        }
        #endregion

        private void MergeSort(int lo, int hi)
        {
            int[] aux = new int[arr.Length];
            Rectangle[] rectangles = new Rectangle[rects.Length];
            M_Sort(rectangles,aux, lo, hi);
        }

        private void M_Sort(Rectangle[] rectangles, int[] aux,int lo, int hi)
        {
            if (hi <= lo) return;

                 int mid = lo + (hi - lo) / 2;

 
                M_Sort(rectangles,aux,lo, mid);
                M_Sort(rectangles, aux,mid + 1, hi);
                Merge(rectangles, aux, lo, mid, hi);
            
        }

        private void Merge(Rectangle[] rectangles,int[] aux, int lo, int mid, int hi)
        {
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = arr[k];
                rectangles[k] = rects[k];
            }

            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                {                             
                    arr[k] = aux[j++];           
                }
                else if (j > hi)
                {             
                    arr[k] = aux[i++];
                }
                else if (aux[j] < aux[i])
                {  
                    arr[k] = aux[j++];   
                }
                else
                {
                    arr[k] = aux[i++]; 
                }
                Redraw();
                Thread.Sleep(450);
            }

        }


        public void Set_Orange(int i, int j)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                rects[i].Fill = Brushes.Orange;
                rects[j].Fill = Brushes.Orange;
            });
        }
        public void Set_Red(int i, int j)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                rects[i].Fill = Brushes.Red;
                rects[j].Fill = Brushes.Red;
            });
        }
        public void Set_Gray(int i)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                rects[i].Fill = Brushes.Gray;
            });
        }

        public void Set_Color(int i, SolidColorBrush color )
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                rects[i].Fill = color;
            });
        }
        public int Max(int[] num)
        {
            int max = 0;
            for(int i = 0; i < num.Length; i++)
            {
                if (num[i] < 0)
                {
                    if (num[i] * -1 > num[max]) max = i;
                }
                else if (num[i] > num[max]) max = i;

            }
            return num[max] < 0 ? - num[max]: arr[max];
        }

        private void Show_Res()
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                string str = "";
                foreach (var i in arr)
                {
                    str += i + " ";
                }
                Sorted.Text = str;
            });
        }

        private void Redraw()
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                Zone.Children.Clear();

                rects = new Rectangle[arr.Length];

                int dist = MAX_WIDTH / arr.Length;

                int max = Max(arr);
                int m_HEIGHT = MAX_HEIGHT / max;


                for (int i = 0; i < rects.Length; i++)
                {
                    int width = 20;
                    int height = 0;
                    int top = 0;

                    int left = dist * i;
                    if (arr[i] < 0)
                    {
                        height = -1 * arr[i] * m_HEIGHT;
                        top = MAX_HEIGHT;

                    }
                    else
                    {
                        height = m_HEIGHT * arr[i];
                        top = MAX_HEIGHT - height;
                    }

                    Rectangle rect = new Rectangle();
                    rect.Fill = Brushes.Green;
                    rect.Height = height;
                    rect.Width = width;
                    rect.Margin = new Thickness(left, top, 0, 0);
                    rects[i] = rect;
                    Zone.Children.Add(rect);
                }
            });
        }
        }
}

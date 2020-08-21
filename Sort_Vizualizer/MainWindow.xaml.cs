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

namespace Sort_Vizualizer
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
                Bubble_sort();
            });
            sortingThread.Start();

        }

        private void Init_Click(object sender, RoutedEventArgs e)
        {
            
            string[] strs = Numbers.Text.Split(' ');
            arr = new int[strs.Length];
            rects = new Rectangle[strs.Length];
            for(int i = 0; i < strs.Length; i++)
            {
                arr[i] = int.Parse(strs[i]); 
            }
            if (arr.Min() < 0)
                MAX_HEIGHT /= 2;

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

    }
}

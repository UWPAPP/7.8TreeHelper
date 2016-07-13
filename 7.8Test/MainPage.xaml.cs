using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _7._8Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Task a;

        public MainPage()
        {
            this.InitializeComponent();

            EnumVisual(Grid);
        }

        internal static void FindChildren<T>(List<T> results, DependencyObject startNode) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(startNode);
            for (int i = 0; i < count; i++)
            {
                DependencyObject current = VisualTreeHelper.GetChild(startNode, i);
                if ((current.GetType()).Equals(typeof(T)) || (current.GetType().GetTypeInfo().IsSubclassOf(typeof(T))))
                {
                    T asType = (T)current;
                    results.Add(asType);
                }
                FindChildren<T>(results, current);
            }
        }

        static public void EnumVisual(DependencyObject myVisual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                DependencyObject childVisual = VisualTreeHelper.GetChild(myVisual, i);
                Button btn = childVisual as Button;
                if (String.Equals(btn.Name, "xxxx")) {
                   
                }
                else {
                    EnumVisual(childVisual);
                }
            }
        }


        private async Task test() {

            await Task.Run(() =>
            {
                for (long i = 0; i < 10000000000000; i++) {
                    Debug.Write(i);
                }
            });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            a = test();
        }
    }
}

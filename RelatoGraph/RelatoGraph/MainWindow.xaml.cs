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

namespace RelatoGraph
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int counter = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            String aString = SetA.Text;
            String bString = SetB.Text;
            String rString = Relation.Text;

            CustomButton btn = new CustomButton(aString, bString, rString);
            btn.Name = "RelBtn" + counter;
            btn.Content = ("R" + counter + " = ({" + aString + "} x {" + bString + "}, " + rString + ")");
            btn.Click += RelButton_Click;
            TopStackPanel.Children.Add(btn);

            String wholeRelation = aString + "|" + bString + "|" + rString;
            Label l = new Label();
            l.Name = "L" + counter;
            l.Visibility = Visibility.Collapsed;
            l.HorizontalAlignment = HorizontalAlignment.Center;
            l.Content = wholeRelation;
            
            TopStackPanel.Children.Add(l);

            counter++;
            
            //SetA.Clear();
            //SetB.Clear();
            //Relation.Clear();
            SetA.Focus();
        }
        /*
        private void tbGotKeyboardFocus(object sender,KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Foreground == Brushes.Gray)
                {
                    ((TextBox)sender).Text = "";
                    ((TextBox)sender).Foreground = Brushes.Black;
                }
            }
        }

        private void tbLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e, String input)
        {
            if(sender is TextBox)
            {
                if (((TextBox)sender).Foreground == Brushes.Black)
                {
                    ((TextBox)sender).Text = input;
                    ((TextBox)sender).Foreground = Brushes.Gray;
                }
            }
        }
        */
        /*
        TextBox tb = new TextBox();
        tb.Foreground = Brushes.Gray;
        tb.Text = "Text";
        tb.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(tb_GotKeyboardFocus);
        tb.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(tb_LostKeyboardFocus);
        */

        private void RelButton_Click(object sender, RoutedEventArgs e)
        {
            Relation rel = new Relation();

            if (sender is CustomButton)
            {
                string name = ((CustomButton)sender).Name;
                String counter = "" + name.Trim(new char[] { 'R', 'e', 'l', 'B', 't', 'n' });
                foreach (Object obj in TopStackPanel.Children)
                {
                    if (obj is Label)
                    {
                        if (((Label)obj).Name.Equals("L" + counter))
                        {
                            if (((Label)obj).Visibility == Visibility.Collapsed)
                            {
                                ((Label)obj).Visibility = Visibility.Visible;
                            }
                            else
                            {
                                ((Label)obj).Visibility = Visibility.Collapsed;
                            }
                        }
                    }
                }
            }
        }

        private void CollapseAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (Object obj in TopStackPanel.Children)
            {
                if (obj is Label)
                {
                    ((Label)obj).Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}

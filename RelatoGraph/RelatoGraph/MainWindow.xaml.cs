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
            Relation relation = new Relation(aString, bString, rString);

            


            CustomButton btn = new CustomButton(aString, bString, rString);
            btn.Name = "RelBtn" + counter;
            btn.Content = ("R" + counter + " = ({" + aString + "} x {" + bString + "}, {" + rString + "})");
            btn.Click += RelButton_Click;
            TopStackPanel.Children.Add(btn);

            StackPanel stack = new StackPanel();
            stack.Name = "S" + counter;
            stack.Visibility = Visibility.Collapsed;
            stack.HorizontalAlignment = HorizontalAlignment.Center;

            Label l1 = new Label();
            Label l2 = new Label();
            Label l3 = new Label();
            Label l4 = new Label();
            Label l5 = new Label();
            Label l6 = new Label();
            Label l7 = new Label();
            l1.Name = "wholeRel" + counter;
            l1.Content = aString + "|" + bString + "|" + rString;
            l2.Name = "lefttotal" + counter;
            l2.Content = "Lefttotal: " + relation.isLefttotal();
            l3.Name = "righttotal";
            l3.Content = "Righttotal: " + relation.isRighttotal();
            l4.Name = "bitotal";
            l4.Content = "Bitotal: " + relation.isBitotal();
            l5.Name = "leftunique";
            l5.Content = "Leftunique: " + relation.isLeftunique();
            l6.Name = "rightunique";
            l6.Content = "Rightunique: " + relation.isRightunique();
            //What is "Eineindeutig" in englisch. Insert in l7.Name and l7.Content
            l7.Name = "oneunique";
            l7.Content = "Oneunique: " + relation.isOneunique();

            Label testLabel = new Label();
            TopStackPanel.Children.Add(testLabel);




            stack.Children.Add(l1);
            stack.Children.Add(l2);
            stack.Children.Add(l3);
            stack.Children.Add(l4);
            stack.Children.Add(l5);
            stack.Children.Add(l6);
            stack.Children.Add(l7);
            TopStackPanel.Children.Add(stack);

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
            if (sender is CustomButton)
            {
                string name = ((CustomButton)sender).Name;
                String counter = "" + name.Trim(new char[] { 'R', 'e', 'l', 'B', 't', 'n' });
                foreach (Object obj in TopStackPanel.Children)
                {
                    if (obj is StackPanel)
                    {
                        if (((StackPanel)obj).Name.Equals("S" + counter))
                        {
                            if (((StackPanel)obj).Visibility == Visibility.Collapsed)
                            {
                                ((StackPanel)obj).Visibility = Visibility.Visible;
                            }
                            else
                            {
                                ((StackPanel)obj).Visibility = Visibility.Collapsed;
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
                if (obj is StackPanel)
                {
                    ((StackPanel)obj).Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}

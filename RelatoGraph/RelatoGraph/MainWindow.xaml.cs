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
            Relation r = new Relation();

            CustomButton b = new CustomButton(aString, bString, rString);
            b.Name = "RelBtn" + counter;
            b.Content = ("R" + counter + " = ({" + aString + "} x {" + bString + "}, " + rString + ")");
            counter++;
            b.Click += RelButton_Click;
            TopStackPanel.Children.Add(b);

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
                String a = ((CustomButton)sender).SetA;
                String b = ((CustomButton)sender).SetB;
                String r = ((CustomButton)sender).Relation;

                String wholeRelation = a + "|" + b + "|" + r;
                Label l = new Label();
                l.Content = wholeRelation;
                TopStackPanel.Children.Add(l);

                //rel.drawRelation(wholeRelation);
            }
            
        }
    }
}

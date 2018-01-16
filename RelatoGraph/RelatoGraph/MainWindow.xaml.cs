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
        private String defaultTextA = "x1,x2,...";
        private String defaultTextB = "y1,y2,...";
        private String defaultTextR = "x1,y1;x2,y2;...";
        private String aString;
        private String bString;
        private String rString;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                aString = SetA.Text;
                bString = SetB.Text;
                rString = Relation.Text;

                Relation relation = new Relation(aString, bString, rString);

                CustomButton b1 = new CustomButton(aString, bString, rString);
                Label l2 = new Label();
                Label l3 = new Label();
                Label l4 = new Label();
                Label l5 = new Label();
                Label l6 = new Label();
                Label l7 = new Label();

                Label l8 = new Label();
                Label l9 = new Label();
                Label l10 = new Label();
                Label l11 = new Label();
                b1.Name = "wholeRel" + counter;
                b1.Content = "Draw this relation";
                b1.Click += DrawRelation_Click;
                b1.Height = 23;

                l2.Name = "lefttotal" + counter;
                l2.Content = "Lefttotal: " + relation.isLefttotal();
                l2.Height = 23;
                l3.Name = "righttotal";
                l3.Content = "Righttotal: " + relation.isRighttotal();
                l3.Height = 23;
                l4.Name = "bitotal";
                l4.Content = "Bitotal: " + relation.isBitotal();
                l4.Height = 23;
                l5.Name = "leftunique";
                l5.Content = "Leftunique: " + relation.isLeftunique();
                l5.Height = 23;
                l6.Name = "rightunique";
                l6.Content = "Rightunique: " + relation.isRightunique();
                l6.Height = 23;
                l7.Name = "onetoone";
                l7.Content = "One-to-one: " + relation.isOneunique();
                l7.Height = 23;

                l8.Name = "function";
                l8.Content = "Function: " + relation.isFunction();
                l8.Height = 23;
                l9.Name = "surjective";
                l9.Content = "Surjective: " + relation.isSurjective();
                l9.Height = 23;
                l10.Name = "injective";
                l10.Content = "Injective: " + relation.isInjective();
                l10.Height = 23;
                l11.Name = "bijective";
                l11.Content = "Bijective: " + relation.isBijective();
                l11.Height = 23;
                

                CustomButton btn = new CustomButton(aString, bString, rString);
                btn.Name = "RelBtn" + counter;
                btn.Content = ("R" + counter + " = ({" + aString + "} x {" + bString + "}, {" + rString + "})");
                btn.Click += RelButton_Click;
                TopStackPanel.Children.Add(btn);

                StackPanel stack = new StackPanel();
                stack.Name = "S" + counter;
                stack.Visibility = Visibility.Collapsed;
                stack.HorizontalAlignment = HorizontalAlignment.Center;


                stack.Children.Add(b1);
                stack.Children.Add(l2);
                stack.Children.Add(l3);
                stack.Children.Add(l4);
                stack.Children.Add(l5);
                stack.Children.Add(l6);
                stack.Children.Add(l7);
                stack.Children.Add(l8);
                stack.Children.Add(l9);
                stack.Children.Add(l10);
                stack.Children.Add(l11);
                TopStackPanel.Children.Add(stack);

                counter++;

                SetA.Foreground = Brushes.LightGray;
                SetA.Text = defaultTextA;

                SetB.Foreground = Brushes.LightGray;
                SetB.Text = defaultTextB;

                Relation.Foreground = Brushes.LightGray;
                Relation.Text = defaultTextR;

                SetA.Focus();
            }
            catch (InputNotIntException)
            {
                MessageBox.Show("You need to enter numbers only!");
            }
        }
        
        private void tbGotKeyboardFocus(object sender,KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Foreground == Brushes.LightGray)
                {
                    ((TextBox)sender).Text = "";
                    ((TextBox)sender).Foreground = Brushes.Black;
                }
            }
        }

        private void tbLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(sender is TextBox)
            {
                if (((TextBox)sender).Foreground == Brushes.Black)
                {
                    if (((TextBox)sender).Name.Equals(SetA.Name))
                    {
                        if (((TextBox)sender).Text.Equals(""))
                        {
                            ((TextBox)sender).Text = defaultTextA;
                            ((TextBox)sender).Foreground = Brushes.LightGray;
                        }
                    }else if (((TextBox)sender).Name.Equals(SetB.Name))
                    {
                        if (((TextBox)sender).Text.Equals(""))
                        {
                            ((TextBox)sender).Text = defaultTextB;
                            ((TextBox)sender).Foreground = Brushes.LightGray;
                        }
                    }
                    else if (((TextBox)sender).Name.Equals(Relation.Name))
                    {
                        if (((TextBox)sender).Text.Equals(""))
                        {
                            ((TextBox)sender).Text = defaultTextR;
                            ((TextBox)sender).Foreground = Brushes.LightGray;
                        }
                    }
                }
            }
        }

        private void DrawRelation_Click(object sender, RoutedEventArgs e)
        {
            MyCanvas.Children.Clear();
            aString = ((CustomButton)sender).SetA;
            bString = ((CustomButton)sender).SetB;
            rString = ((CustomButton)sender).RelationValue;
            Relation relation = new Relation(aString, bString, rString);
            int leftElementTopOffset = 1;
            int rightElementTopOffset = 1;

            int setALength = relation.splitSetA().Count;
            int setBLength = relation.splitSetB().Count;
            if (setALength < setBLength)
            {
                int firstLength = setALength;
                int secondLength = setBLength;
                int countA = 0;
                int countB = 0;
                int counter = 0;

                int i = 0;
                while (i < secondLength)
                {
                    if (counter % 2 == 0)
                    {
                        if (countA < firstLength)
                        {
                            TextBlock block = new TextBlock();
                            if (relation.splitSetA().ElementAt(countA) < 0)
                            {
                                block.Name = "blockAminus" + Math.Abs(relation.splitSetA().ElementAt(countA));
                            }
                            else
                            {
                                block.Name = "blockA" + relation.splitSetA().ElementAt(countA);
                            }
                            block.Text = "" + relation.splitSetA().ElementAt(countA);
                            block.Width = block.Text.Length * 6.8;
                            block.MaxWidth = 100;
                            block.Margin = new Thickness(20, leftElementTopOffset * 10, 0, 0);
                            leftElementTopOffset += 3;
                            MyCanvas.Children.Add(block);
                            countA++;
                            counter++;
                        }
                        else
                        {
                            counter++;
                        }
                    }
                    else
                    {
                        if (countB < secondLength)
                        {
                            TextBlock block = new TextBlock();
                            if (relation.splitSetB().ElementAt(i) < 0)
                            {
                                block.Name = "blockBminus" + Math.Abs(relation.splitSetB().ElementAt(countB));
                            }
                            else
                            {
                                block.Name = "blockB" + relation.splitSetB().ElementAt(countB);
                            }
                            block.Text = "" + relation.splitSetB().ElementAt(countB);
                            block.Width = block.Text.Length * 6.8;
                            block.MaxWidth = 100;
                            block.Margin = new Thickness(400, rightElementTopOffset * 10, 0, 0);
                            rightElementTopOffset += 3;
                            MyCanvas.Children.Add(block);
                            countB++;
                            i++;
                            counter++;
                        }
                        else
                        {
                            i++;
                            counter++;
                        }
                    }
                }
            }
            else if (setBLength < setALength)
            {
                int firstLength = setALength;
                int secondLength = setBLength;
                int countA = 0;
                int countB = 0;
                int counter = 0;

                int i = 0;
                while (i < firstLength)
                {
                    if (counter % 2 == 0)
                    {
                        if (countA < firstLength)
                        {
                            TextBlock block = new TextBlock();
                            if (relation.splitSetA().ElementAt(countA) < 0)
                            {
                                block.Name = "blockAminus" + Math.Abs(relation.splitSetA().ElementAt(countA));
                            }
                            else
                            {
                                block.Name = "blockA" + relation.splitSetA().ElementAt(countA);
                            }
                            block.Text = "" + relation.splitSetA().ElementAt(countA);
                            block.Width = block.Text.Length * 6.8;
                            block.MaxWidth = 100;
                            block.Margin = new Thickness(20, leftElementTopOffset * 10, 0, 0);
                            leftElementTopOffset += 3;
                            MyCanvas.Children.Add(block);
                            countA++;
                            counter++;
                        }
                        else
                        {
                            counter++;
                        }
                    }
                    else
                    {
                        if (countB < secondLength)
                        {
                            TextBlock block = new TextBlock();
                            if (relation.splitSetB().ElementAt(i) < 0)
                            {
                                block.Name = "blockBminus" + Math.Abs(relation.splitSetB().ElementAt(countB));
                            }
                            else
                            {
                                block.Name = "blockB" + relation.splitSetB().ElementAt(countB);
                            }
                            
                            block.Text = "" + relation.splitSetB().ElementAt(countB);
                            block.Width = block.Text.Length * 6.8;
                            block.MaxWidth = 100;
                            block.Margin = new Thickness(400, rightElementTopOffset * 10, 0, 0);
                            rightElementTopOffset += 3;
                            MyCanvas.Children.Add(block);
                            countB++;
                            i++;
                            counter++;
                        }
                        else
                        {
                            i++;
                            counter++;
                        }
                    }
                }
            }
            else if (setALength == setBLength)
            {
                int firstLength = setALength;

                for (int i = 0; i < firstLength; i++)
                {
                    TextBlock blockA = new TextBlock();
                    if (relation.splitSetA().ElementAt(i) < 0)
                    {
                        blockA.Name = "blockAminus" + Math.Abs(relation.splitSetA().ElementAt(i));
                    }
                    else
                    {
                        blockA.Name = "blockA" + relation.splitSetA().ElementAt(i);
                    }
                    blockA.Text = "" + relation.splitSetA().ElementAt(i);
                    blockA.Width = blockA.Text.Length * 6.8;
                    blockA.MaxWidth = 100;
                    blockA.Margin = new Thickness(20, leftElementTopOffset * 10, 0, 0);
                    leftElementTopOffset += 3;

                    TextBlock blockB = new TextBlock();
                    if (relation.splitSetB().ElementAt(i) < 0)
                    {
                        blockB.Name = "blockBminus" + Math.Abs(relation.splitSetB().ElementAt(i));
                    }
                    else
                    {
                        blockB.Name = "blockB" + relation.splitSetB().ElementAt(i);
                    }
                    
                    blockB.Text = "" + relation.splitSetB().ElementAt(i);
                    blockB.Width = blockA.Text.Length * 6.8;
                    blockB.MaxWidth = 100;
                    blockB.Margin = new Thickness(400, rightElementTopOffset * 10, 0, 0);
                    rightElementTopOffset += 3;

                    MyCanvas.Children.Add(blockA);
                    MyCanvas.Children.Add(blockB);
                }
            }

            double x1 = 0;
            double y1 = 0;

            double x2 = 0;
            double y2 = 0;


            List<List<int>> rList = relation.splitRelation();
            foreach (List<int> innerList in rList)
            {
                int a = innerList.ElementAt(0);
                if (a < 0)
                {
                    foreach (Object obj in MyCanvas.Children)
                    {
                        if (obj is TextBlock)
                        {
                            if (((TextBlock)obj).Name == "blockAminus" + Math.Abs(a))
                            {
                                x1 = ((TextBlock)obj).Name.Length + ((TextBlock)obj).Margin.Left;
                                y1 = ((TextBlock)obj).Margin.Top;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Object obj in MyCanvas.Children)
                    {
                        if (obj is TextBlock)
                        {
                            if (((TextBlock)obj).Name == "blockA" + a)
                            {
                                x1 = ((TextBlock)obj).Name.Length + ((TextBlock)obj).Margin.Left;
                                y1 = ((TextBlock)obj).Margin.Top;
                            }
                        }
                    }
                }
                int b = innerList.ElementAt(1);
                if (b < 0)
                {
                    foreach (Object obj in MyCanvas.Children)
                    {
                        if (obj is TextBlock)
                        {
                            if (((TextBlock)obj).Name == "blockBminus" + Math.Abs(b))
                            {
                                x2 = ((TextBlock)obj).Margin.Left;
                                y2 = ((TextBlock)obj).Margin.Top;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Object obj in MyCanvas.Children)
                    {
                        if (obj is TextBlock)
                        {
                            if (((TextBlock)obj).Name == "blockB" + b)
                            {
                                x2 = ((TextBlock)obj).Margin.Left;
                                y2 = ((TextBlock)obj).Margin.Top;
                            }
                        }
                    }
                }
                Line l = new Line();
                l.Stroke = Brushes.Black;
                l.StrokeThickness = 1;
                l.X1 = x1;
                l.Y1 = y1;
                l.X2 = x2;
                l.Y2 = y2;
                MyCanvas.Children.Add(l);
            }
        }

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

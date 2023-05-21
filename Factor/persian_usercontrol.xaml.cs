using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Factor
{

    public partial class persian_usercontrol : UserControl
    {
        int total_price_int;

        string _discont;
        string _Previous_debt;

        public persian_usercontrol()
        {
            InitializeComponent();
            Add_item();

            Discont_number_box.TextChanged += Discont_number_box_TextChanged;
            Discont_number_box.SelectionChanged += Discont_number_box_SelectionChanged;

            Previous_debt_text_box.TextChanged += Previous_debt_text_box_TextChanged;
            Previous_debt_text_box.SelectionChanged += Previous_debt_text_box_SelectionChanged;

            Total_price.TextChanged += Total_price_TextChanged;
        }

        private void Total_price_TextChanged(object sender, TextChangedEventArgs e)
        {
            amount_payable.Text = Unit_separator((Text_to_Number(Previous_debt_text_box.Text) + Text_to_Number(Discont_number_box.Text) + Text_to_Number(old_value_total_cost_textbox)).ToString());
            amount_payable.Text = Unit_separator((Text_to_Number((sender as TextBox).Text) - (Text_to_Number(Previous_debt_text_box.Text) + Text_to_Number(Discont_number_box.Text))).ToString());
            (sender as TextBox).Text = Unit_separator(Text_to_Number((sender as TextBox).Text).ToString());
            (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
        }

        private void Previous_debt_text_box_SelectionChanged(object sender, RoutedEventArgs e)
        {
            old_value_Previous_debt = Unit_separator((sender as TextBox).Text);
        }

        private void Previous_debt_text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            amount_payable.Text = Unit_separator((Text_to_Number(Total_price.Text) + Text_to_Number(Discont_number_box.Text) + Text_to_Number(old_value_Previous_debt)).ToString());
            amount_payable.Text = Unit_separator((Text_to_Number(Total_price.Text) - (Text_to_Number((sender as TextBox).Text) + Text_to_Number(Discont_number_box.Text))).ToString());
            (sender as TextBox).Text = Unit_separator(Text_to_Number((sender as TextBox).Text).ToString());
            (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;

        }

        private void Discont_number_box_SelectionChanged(object sender, RoutedEventArgs e)
        {
            amount_payable.Text = Unit_separator((Text_to_Number(Total_price.Text) + Text_to_Number(old_value_discont) + Text_to_Number(Previous_debt_text_box.Text)).ToString());
            amount_payable.Text = Unit_separator((Text_to_Number(Total_price.Text) - (Text_to_Number((sender as TextBox).Text) + Text_to_Number(Previous_debt_text_box.Text))).ToString());
        }

        private void Discont_number_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            old_value_discont = Unit_separator((sender as TextBox).Text);
            (sender as TextBox).Text = Unit_separator(Text_to_Number((sender as TextBox).Text).ToString());
            (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
        }

        List<TextBox> textBoxes_list = new List<TextBox>();
        string old_value_total_cost_textbox = "";
        string old_value_number_textbox = "";
        string old_value_unit_cost_textbox = "";

        string old_value_discont = "0";
        string old_value_Previous_debt = "0";

        int total_cost_textbox_int = 0;

        public void Add_item()
        {
            if (factor_stackpanel.Children.Count > 19)
                return;

            if (factor_stackpanel.Children.Count != 0)
            {
                Line line = new Line() { Stretch = Stretch.Fill, Width = 400, Stroke = Brushes.DeepSkyBlue, X2 = 1 };
                factor_stackpanel.Children.Add(line);
            }

            DockPanel main_dockPanel = new DockPanel();
            StackPanel main_stackPanel = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Left };

            DockPanel cost_total_dockPanel = new DockPanel() { Width = 100 };
            TextBox textbox_total_cost = new TextBox()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Text = "0",
                FontWeight = FontWeights.Bold,
                Background = Brushes.Transparent,
                BorderBrush = Brushes.Transparent,
                BorderThickness = new Thickness(0, 0, 0, 1),
                FontSize = 15,
            };
            textbox_total_cost.TextChanged += Textbox_total_cost_TextChanged;
            textbox_total_cost.SelectionChanged += Textbox_total_cost_SelectionChanged;


            cost_total_dockPanel.Children.Add(textbox_total_cost);
            main_stackPanel.Children.Add(cost_total_dockPanel);

            DockPanel cost_unit_dockPanel = new DockPanel() { Width = 100 };
            TextBox textbox_unit_cost = new TextBox()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Text = "0",
                FontWeight = FontWeights.Bold,
                Background = Brushes.Transparent,
                BorderBrush = Brushes.Transparent,
                BorderThickness = new Thickness(0, 0, 0, 1),
                FontSize = 15,
            };
            textbox_unit_cost.TextChanged += Textbox_unit_cost_TextChanged;
            textbox_unit_cost.SelectionChanged += Textbox_unit_cost_SelectionChanged;

            cost_unit_dockPanel.Children.Add(textbox_unit_cost);
            main_stackPanel.Children.Add(cost_unit_dockPanel);

            DockPanel number_dockPanel = new DockPanel() { Width = 50 };
            TextBox textbox_number = new TextBox()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Text = "0",
                FontWeight = FontWeights.Bold,
                Background = Brushes.Transparent,
                BorderBrush = Brushes.Transparent,
                BorderThickness = new Thickness(0, 0, 0, 1),
                FontSize = 15,
            };
            textbox_number.TextChanged += Textbox_number_TextChanged;
            textbox_number.SelectionChanged += Textbox_number_SelectionChanged;

            number_dockPanel.Children.Add(textbox_number);
            main_stackPanel.Children.Add(number_dockPanel);


            StackPanel stackpanel_richtextbox = new StackPanel() { Width = 150 };
            RichTextBox richTextBox = new RichTextBox()
            {
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(5, 5, 5, 5),
                Background = Brushes.Transparent,
                BorderBrush = Brushes.Transparent,
                BorderThickness = new Thickness(0, 0, 0, 1),

            };
            FlowDocument flowDocument = new FlowDocument();
            Paragraph paragraph_1 = new Paragraph(new Run("طراحی سایت"))
            {

                TextAlignment = TextAlignment.Right,
                LineHeight = 2,
                FontSize = 17,
                FontWeight = FontWeights.Bold,
            };
            Paragraph paragraph_2 = new Paragraph(new Run("لورم ایپسوم متن ساختگی با تولید"))
            {
                TextAlignment = TextAlignment.Right,
                LineHeight = 2,
                FontSize = 10,
                FontWeight = FontWeights.Normal,
                Foreground = Brushes.Gray,
                FontStyle = FontStyles.Normal,
            };
            flowDocument.Blocks.Add(paragraph_1);
            flowDocument.Blocks.Add(paragraph_2);
            richTextBox.Document = flowDocument;
            stackpanel_richtextbox.Children.Add(richTextBox);
            main_stackPanel.Children.Add(stackpanel_richtextbox);

            main_dockPanel.Children.Add(main_stackPanel);
            factor_stackpanel.Children.Add(main_dockPanel);

            Add_to_list(textbox_total_cost);
        }

        private void Textbox_number_SelectionChanged(object sender, RoutedEventArgs e)
        {
            old_value_unit_cost_textbox = Unit_separator((((((sender as TextBox).Parent as DockPanel).Parent as StackPanel).Children[1] as DockPanel).Children[0] as TextBox).Text);
            old_value_number_textbox = Unit_separator((sender as TextBox).Text);
            old_value_total_cost_textbox = Unit_separator((((((sender as TextBox).Parent as DockPanel).Parent as StackPanel).Children[0] as DockPanel).Children[0] as TextBox).Text);

        }

        private void Textbox_number_TextChanged(object sender, TextChangedEventArgs e)
        {
            (((((sender as TextBox).Parent as DockPanel).Parent as StackPanel).Children[0] as DockPanel).Children[0] as TextBox).Text = Unit_separator((Text_to_Number((sender as TextBox).Text) * Text_to_Number(old_value_unit_cost_textbox)).ToString());
            (sender as TextBox).Text = Unit_separator(Text_to_Number((sender as TextBox).Text).ToString());
            (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
        }

        private void Textbox_unit_cost_SelectionChanged(object sender, RoutedEventArgs e)
        {
            old_value_number_textbox = Unit_separator((((((sender as TextBox).Parent as DockPanel).Parent as StackPanel).Children[2] as DockPanel).Children[0] as TextBox).Text);
            old_value_unit_cost_textbox = Unit_separator((sender as TextBox).Text);
            old_value_total_cost_textbox = Unit_separator((((((sender as TextBox).Parent as DockPanel).Parent as StackPanel).Children[0] as DockPanel).Children[0] as TextBox).Text);

        }

        private void Textbox_unit_cost_TextChanged(object sender, TextChangedEventArgs e)
        {
            (((((sender as TextBox).Parent as DockPanel).Parent as StackPanel).Children[0] as DockPanel).Children[0] as TextBox).Text = Unit_separator((Text_to_Number((sender as TextBox).Text) * Text_to_Number(old_value_number_textbox)).ToString());
            (sender as TextBox).Text = Unit_separator(Text_to_Number((sender as TextBox).Text).ToString());
            (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
        }

        private void Textbox_total_cost_SelectionChanged(object sender, RoutedEventArgs e)
        {
            old_value_total_cost_textbox = Unit_separator((sender as TextBox).Text);
        }

        private void Textbox_total_cost_TextChanged(object sender, TextChangedEventArgs e)
        {
            (sender as TextBox).Text = Unit_separator(Text_to_Number((sender as TextBox).Text).ToString());
            (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
            Sum(Unit_separator((sender as TextBox).Text));

        }


        public void Remove_item()
        {
            if (factor_stackpanel.Children.Count == 0)
                return;
            factor_stackpanel.Children.RemoveAt(factor_stackpanel.Children.Count - 1);

            reduce();

            if (factor_stackpanel.Children.Count == 0)
                return;
            factor_stackpanel.Children.RemoveAt(factor_stackpanel.Children.Count - 1);

        }


        public void Discont_box(bool value)
        {
            if (value)
            {
                Discont_text_box.Visibility = Visibility.Visible;
                Discont_number_box.Visibility = Visibility.Visible;
                Discont_number_box.Text = "0";
            }
            else
            {
                Discont_text_box.Visibility = Visibility.Collapsed;
                Discont_number_box.Visibility = Visibility.Collapsed;
                Discont_number_box.Text = "0";
            }
        }

        public void Previous_debt_box(bool value)
        {
            if (value)
            {
                Previous_debt_label_box.Visibility = Visibility.Visible;
                Previous_debt_text_box.Visibility = Visibility.Visible;
                Previous_debt_text_box.Text = "0";
            }
            else
            {
                Previous_debt_label_box.Visibility = Visibility.Collapsed;
                Previous_debt_text_box.Visibility = Visibility.Collapsed;
                Previous_debt_text_box.Text = "0";

            }
        }



        public void Add_to_list(TextBox textBox)
        {
            textBoxes_list.Add(textBox);
        }


        public void reduce()
        {
            try
            {
                total_price_int = Text_to_Number(Total_price.Text);
                total_price_int -= Text_to_Number(textBoxes_list[textBoxes_list.Count - 1].Text);
                Total_price.Text = total_price_int.ToString();
                textBoxes_list.RemoveAt(textBoxes_list.Count - 1);
            }
            catch (Exception)
            {

            }
        }
        public void Sum(string text)
        {
            total_price_int = Text_to_Number(Total_price.Text);
            total_price_int -= Text_to_Number(old_value_total_cost_textbox);
            total_price_int += Text_to_Number(text);
            Total_price.Text = Unit_separator(total_price_int.ToString());

        }

        public static int Text_to_Number(string text)
        {
            try
            {

                int j = 0;

                int tmp_number = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] >= (char)48 && text[i] <= (char)57)
                        tmp_number++;
                }

                char[] temp = new char[tmp_number];

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] < (char)48 || text[i] > (char)57)
                        continue;
                    temp[j] = text[i];
                    j++;
                }

                return int.Parse(new string(temp));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        char[] value;
        public string Unit_separator(string number)
        {
            int separator = 0;

            for (int i = number.Length; i > 3; i -= 3)
                separator++;

            if (separator < 1)
                return number;

            value = new char[number.Length + separator];
            int index = value.Length - 1;

            int tmp = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (tmp == 3)
                {
                    value[index] = ',';
                    index--;
                    tmp = 0;
                }
                value[index] = number[i];
                index--;
                tmp++;
            }


            return new string(value);
        }

        //amount_payable.Text = (Text_to_Number(Total_price.Text) + Text_to_Number(old_value_discont)).ToString();
        //amount_payable.Text = (Text_to_Number(Total_price.Text) - Text_to_Number((sender as TextBox).Text)).ToString();

        //old_value_discont = (sender as TextBox).Text;
        //           

        // 
        // 


        // old_value_discont = (sender as TextBox).Text;
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Source
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();

        }

        public double New { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (richTextBox1.Selection.Text.Length > 0)
            {
                FontDialog fd = new FontDialog();
                var result = fd.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Debug.WriteLine(fd.Font);

                    richTextBox1.Selection.ApplyPropertyValue(FontFamilyProperty, new System.Windows.Media.FontFamily(fd.Font.Name));
                    richTextBox1.Selection.ApplyPropertyValue(FontSizeProperty, fd.Font.Size * 96.0 / 72.0);
                    richTextBox1.Selection.ApplyPropertyValue(FontWeightProperty, fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular);
                    richTextBox1.Selection.ApplyPropertyValue(FontStyleProperty, fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal);

                    TextDecorationCollection tdc = new TextDecorationCollection();
                    if (fd.Font.Underline) tdc.Add(TextDecorations.Underline);
                    if (fd.Font.Strikeout) tdc.Add(TextDecorations.Strikethrough);
                }
            }
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (richTextBox1.Selection.Text.Length > 0)
            {

                if (richTextBox1.FontStyle == FontStyles.Italic)
                    richTextBox1.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Normal);
                else richTextBox1.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (richTextBox1.Selection.Text.Length > 0)
            {

                if (richTextBox1.FontWeight == FontWeights.Bold)
                    richTextBox1.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Normal);
                else richTextBox1.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (richTextBox1.Selection.Text.Length > 0)
            {
                richTextBox1.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (richTextBox1.Selection.Text.Length > 0)
            {

                ColorDialog cd = new ColorDialog();
                var result = cd.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    richTextBox1.Selection.ApplyPropertyValue(ForegroundProperty, new SolidColorBrush(System.Windows.Media.Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B)));
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            var result = cd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(cd.Color.R, cd.Color.G, cd.Color.B));
            }

        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            
            if (sender is System.Windows.Controls.Button b)
            {
                switch (b.Name)
                {
                    case "Left":
                        richTextBox1.Document.TextAlignment = TextAlignment.Left;

                        break;
                    case "Center":
                        richTextBox1.Document.TextAlignment = TextAlignment.Center;
                        break;

                    case "Right":
                        richTextBox1.Document.TextAlignment = TextAlignment.Right;

                        break;
                    default:
                        break;
                }
            }
        }

        private void Inc_Click(object sender, RoutedEventArgs e)
        {
            
            if (sender is RepeatButton b)
            {
                switch (b.Name)
                {
                    case "Inc":
                        richTextBox1.FontSize++;
                        break;
                    case "Dec":
                        richTextBox1.FontSize--;
                        break;
                    default:
                        break;
                }
            }
            
            
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            richTextBox1.Document.Blocks.Clear();
            richTextBox1.Document.Blocks.Add(new Paragraph(new Run(DateTime.Now.ToString())));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            richTextBox1.Document.Blocks.Clear();
            Home.Focus();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                StreamReader sr = new(openFileDialog1.FileName);
                richTextBox1.Document.Blocks.Clear();
                richTextBox1.Document.Blocks.Add(new Paragraph(new Run(sr.ReadToEnd())));
            }
            Home.Focus();
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "Text Files|*.txt";
            saveFileDialog1.FilterIndex = 1;

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using StreamWriter sw = new(saveFileDialog1.FileName);

                TextRange range;

                range = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
                sw.Write(range.Text);
            }
            Home.Focus();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog printDialog1 = new System.Windows.Controls.PrintDialog();
            printDialog1.ShowDialog();
            Home.Focus();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if(sender is ToggleButton toggleButton)
            {
                if (toggleButton.IsChecked == true)
                {
                    toggleButton.Content = "On";
                    richTextBox1.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                }
                else
                {
                    toggleButton.Content = "Off";

                    richTextBox1.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                    richTextBox1.Document.PageWidth = 1000;


                }
            }
            Home.Focus();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            if (richTextBox1.CanUndo)
                richTextBox1.Undo();
            Home.Focus();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            if (richTextBox1.CanRedo)
                richTextBox1.Redo();
            Home.Focus();
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            if (richTextBox1.Selection.Text.Length > 0)
            {
                richTextBox1.Copy();
            }
            Home.Focus();
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            if (richTextBox1.Selection.Text != "")
            {
                richTextBox1.Cut();
            }

            Home.Focus();
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            if (System.Windows.Clipboard.GetDataObject().GetDataPresent(System.Windows.DataFormats.Text) == true)
            {
                richTextBox1.Paste();
            }
            Home.Focus();
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            richTextBox1.Selection.Text = "";
            Home.Focus();
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            richTextBox1.Document.Blocks.Clear();
            Home.Focus();
        }


        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            richTextBox1.SelectAll();
            Home.Focus();
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            Home.Focus();
            System.Windows.Forms.MessageBox.Show("Welcome to the Wordpad Killer written by Leyla Shafiyeva","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}


using System;
using System.Windows;

namespace AreaCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FigureType_Checked(object sender, RoutedEventArgs e)
        {

            ErrorMessage.Text = "";
            ResultLabel.Text = "Площадь = ";


            if (RectangleRadioButton.IsChecked == true)
            {
                Side1.Visibility = Visibility.Visible;
                Side2.Visibility = Visibility.Visible;
                Side3.Visibility = Visibility.Collapsed;
                Radius.Visibility = Visibility.Collapsed;

                Side1Label.Visibility = Visibility.Visible;
                Side2Label.Visibility = Visibility.Visible;
                Side3Label.Visibility = Visibility.Collapsed;
                RadiusLabel.Visibility = Visibility.Collapsed;
            }
            else if (CircleRadioButton.IsChecked == true)
            {
                Side1.Visibility = Visibility.Collapsed;
                Side2.Visibility = Visibility.Collapsed;
                Side3.Visibility = Visibility.Collapsed;
                Radius.Visibility = Visibility.Visible;

                Side1Label.Visibility = Visibility.Collapsed;
                Side2Label.Visibility = Visibility.Collapsed;
                Side3Label.Visibility = Visibility.Collapsed;
                RadiusLabel.Visibility = Visibility.Visible;
            }
            else if (TriangleRadioButton.IsChecked == true)
            {
                Side1.Visibility = Visibility.Visible;
                Side2.Visibility = Visibility.Visible;
                Side3.Visibility = Visibility.Visible;
                Radius.Visibility = Visibility.Collapsed;

                Side1Label.Visibility = Visibility.Visible;
                Side2Label.Visibility = Visibility.Visible;
                Side3Label.Visibility = Visibility.Visible;
                RadiusLabel.Visibility = Visibility.Collapsed;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Text = "";
            ResultLabel.Text = "Площадь = ";

            if ((RectangleRadioButton.IsChecked == true && (string.IsNullOrWhiteSpace(Side1.Text) || string.IsNullOrWhiteSpace(Side2.Text))) ||
                (CircleRadioButton.IsChecked == true && string.IsNullOrWhiteSpace(Radius.Text)) ||
                (TriangleRadioButton.IsChecked == true && (string.IsNullOrWhiteSpace(Side1.Text) || string.IsNullOrWhiteSpace(Side2.Text) || string.IsNullOrWhiteSpace(Side3.Text))))
            {
                ErrorMessage.Text = "Заполните все поля!";
                return;
            }

            if (!RectangleRadioButton.IsChecked.GetValueOrDefault() &&
                !CircleRadioButton.IsChecked.GetValueOrDefault() &&
                !TriangleRadioButton.IsChecked.GetValueOrDefault())
            {
                ErrorMessage.Text = "Выберите фигуру!";
                return;
            }
            if (RectangleRadioButton.IsChecked == true)
            {
                if (!double.TryParse(Side1.Text, out double side1) || !double.TryParse(Side2.Text, out double side2))
                {
                    ErrorMessage.Text = "Введите числовые значения для сторон!";
                    return;
                }

                double area = side1 * side2;
                ResultLabel.Text = $"Площадь прямоугольника = {area}";
            }
            else if (CircleRadioButton.IsChecked == true)
            {
                if (!double.TryParse(Radius.Text, out double radius))
                {
                    ErrorMessage.Text = "Введите числовое значение для радиуса!";
                    return;
                }

                double area = Math.PI * Math.Pow(radius, 2);
                ResultLabel.Text = $"Площадь круга = {area}";
            }
            else if (TriangleRadioButton.IsChecked == true)
            {
                if (!double.TryParse(Side1.Text, out double side1) ||
                    !double.TryParse(Side2.Text, out double side2) ||
                    !double.TryParse(Side3.Text, out double side3))
                {
                    ErrorMessage.Text = "Введите числовые значения для сторон!";
                    return;
                }
                double s = (side1 + side2 + side3) / 2;
                double area = Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
                ResultLabel.Text = $"Площадь треугольника = {area}";
            }
        }
    }
}

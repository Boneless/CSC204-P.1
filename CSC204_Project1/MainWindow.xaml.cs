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
//P1 Joe's Automotive, CSC 204, Jonathan Campbell #1145, Daniel Everett #1302
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSC204_Project1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiesLaborBox.Text = Convert.ToString(OilLubeCharges() + FlushCharges() + MiscCharges() + Convert.ToDouble(LaborInBox.Text));
            }
            catch(System.FormatException){
                ServiesLaborBox.Text = Convert.ToString(OilLubeCharges() + FlushCharges() + MiscCharges());
            }
            try{
                PartsOutBox.Text = Convert.ToString(Convert.ToDouble(PartsInBox.Text));
                
            }
            catch(System.FormatException){
                PartsOutBox.Text = "0.00";
            }
            try
            {
                TaxBox.Text = Convert.ToString(TaxCharges());
            }
            catch (System.FormatException)
            {
                TaxBox.Text = "0.00";
            }
            try
            {
                TotalFeesBox.Text = TotalCharges();
            }
            catch (System.FormatException)
            {
                double total = 0;
                try
                {
                    total += Convert.ToDouble(ServiesLaborBox.Text);
                }
                catch (System.FormatException)
                {
                    total += 0;
                }
                try
                {
                    total += Convert.ToDouble(TaxBox.Text);
                }
                catch (System.FormatException)
                {
                    total += 0;
                }

                try
                {
                    total += Convert.ToDouble(PartsInBox.Text);
                }
                catch (System.FormatException)
                {
                    total += 0;
                }
                TotalFeesBox.Text = Convert.ToString(total);
            }
            ServiesLaborBox.Text = String.Format("{0:C}", Convert.ToDouble(ServiesLaborBox.Text));
            PartsOutBox.Text = String.Format("{0:C}", Convert.ToDouble(PartsOutBox.Text));
            TaxBox.Text = String.Format("{0:C}", Convert.ToDouble(TaxBox.Text));
            TotalFeesBox.Text = String.Format("{0:C}", Convert.ToDouble(TotalFeesBox.Text));
        }

        public double OilLubeCharges()
        {
            double total = 0;
            if (OilChangeBox.IsChecked == true)
            {
                total += 26;
            }
            if (LubeJobBox.IsChecked == true)
            {
                total += 18;
            }
            return total;
        }

        public double FlushCharges()
        {
            double total = 0;
            if (RadFlushBox.IsChecked == true)
            {
                total += 30;
            }
            if (TransFlushBox.IsChecked == true)
            {
                total += 80;
            }
            return total;
        }

        public double MiscCharges()
        {
            double total = 0;
            if (InspectionBox.IsChecked == true)
            {
                total += 15;
            }
            if (MufflerBox.IsChecked == true)
            {
                total += 100;
            }
            if (TireRotationBox.IsChecked == true)
            {
                total += 20;
            }
            return total;
        }

        public double TaxCharges()
        {
            return Convert.ToDouble(PartsInBox.Text) * .06;
        }




        public string TotalCharges()
        {
            
            return  Convert.ToString( Convert.ToDouble(ServiesLaborBox.Text) + Convert.ToDouble(PartsInBox.Text) + Convert.ToDouble(TaxBox.Text) );
        }

        //Clear button and functions
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearOilLube();
            ClearFlushes();
            ClearMisc();
            ClearOther();
            ClearFees();
            PartsInBox.Focus();
        }

        public void ClearOilLube()
        {
            OilChangeBox.IsChecked = false;
            LubeJobBox.IsChecked = false;            
        }

        public void ClearFlushes()
        {
            RadFlushBox.IsChecked = false;
            TransFlushBox.IsChecked = false;            
        }

        public void ClearMisc()
        {
            InspectionBox.IsChecked = false;
            MufflerBox.IsChecked = false;
            TireRotationBox.IsChecked = false;
        }

        public void ClearOther()
        {
            PartsInBox.Text = "";
            LaborInBox.Text = "";
        }

        public void ClearFees()
        {
            ServiesLaborBox.Text = "";
            PartsOutBox.Text = "";
            TaxBox.Text = "";
            TotalFeesBox.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}


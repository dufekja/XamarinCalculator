using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public string Eval(string expression)
        {
            try
            {
                DataTable dt = new DataTable();
                var result = dt.Compute(expression, "");
                return result.ToString();
            } catch
            {
                return "ERROR";
            }
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;
            if (buttonText == "=")
            {
                LabelEval.Text = Eval(LabelEval.Text);
            } else
            {
                if (LabelEval.Text == "ERROR")
                {
                    LabelEval.Text = buttonText;
                } else
                {
                    LabelEval.Text += buttonText;
                }
                
            }
           
        }

    }
}

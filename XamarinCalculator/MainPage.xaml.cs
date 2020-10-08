using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DynamicExpresso;

namespace XamarinCalculator
{
    public partial class MainPage : ContentPage
    {
        public interface IStatusBarPlatformSpecific {
            void SetStatusBarColor(Color Color);
        }

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Jednoduchá funkce Eval, která vypočítá zadaný příklad
        /// </summary>
        /// <param name="expression">String s vloženým příkladem</param>
        /// <returns>Vrací string již vypočítaného příkladu</returns>
        public string Eval(string expression) {
            string outcome = "";
            try {
                var interpreter = new Interpreter();
                var result = interpreter.Eval(expression);
                outcome = result.ToString();

            } catch {
                outcome = "ERROR";
            }
            return outcome;
        }
        
        /// <summary>
        /// Při kliknutí na jekékoliv tlačítko provede akci ke konkrétnímu tlačítku
        /// </summary>
        /// <param name="sender">Objekt, který spustil onClick event</param>
        /// <param name="args">Další argumenty okna</param>
        void OnButtonClicked(object sender, EventArgs args) {

            // získá text vybraného tlačítka
            Button button = (Button)sender;
            string buttonText = button.Text;

            // provede se akce pro typ tlačítka
            switch (buttonText) {
                case "=":
                    LabelEval.Text = Eval(LabelEval.Text);
                    break;

                case "DEL":
                    string text = LabelEval.Text;
                    if (text == "ERROR") {
                        LabelEval.Text = "";
                    } else {
                        LabelEval.Text = text.Substring(0, text.Length - 1);
                    }
                    break;

                case "AC":
                    LabelEval.Text = "";
                    break;

                default:
                    if (LabelEval.Text == "ERROR") {
                        LabelEval.Text = buttonText;
                    } else {
                        LabelEval.Text += buttonText;
                    }
                    break;
            }    
        }
    }
}

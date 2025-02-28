using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Calculator__1_
{
    public partial class frmCalculator : Form
    {

        enum enOpType { eAdd = 1, eSubtract = 2, eMultiplication = 3, eDivdie = 4 };
        struct stCalculator
        {
            public double Number1;
            public double Number2;
            public double PrevResult;
            public double FinalResult;
        }

        stCalculator Calculator = new stCalculator();

        //----------------------------------------//

        public frmCalculator()
        {
            InitializeComponent();
        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {
            Calculator.Number1 = 0;
            Calculator.Number2 = 0;
            Calculator.PrevResult = 0;
            Calculator.FinalResult = 0;
        }

        //----------------------------------------//

        // Is Int.
        private bool IsInt(Control control)
        {
            int Number = 0;

            return int.TryParse(control.Text, out Number);
        }

        private void ErrorProvider(object sender, CancelEventArgs e, Control control)
        {

            if (string.IsNullOrEmpty(control.Text))
            {
                e.Cancel = true;
                control.Focus();

                errorProvider1.SetError(control, "Must have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(control, "");

                if (!IsInt(control))
                {
                    e.Cancel = true;
                    control.Focus();

                    errorProvider1.SetError(control, "Accept Only Numbers!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(control, "");
                }
            }

        }

        //----------------------------------------//

        enOpType GetOpTypeSymbol(string OpTypeSymbol)
        {
            switch(OpTypeSymbol)
            {
                case "+":
                    return enOpType.eAdd;
                case "-":
                    return enOpType.eSubtract;
                case "*":
                    return enOpType.eMultiplication;
                case "/":
                    return enOpType.eDivdie;
                default:
                    return enOpType.eAdd;
            }
        }

        //----------------------------------------//

        private void ShowResult()
        {
            lblFinalResult.Text = Calculator.FinalResult.ToString();
            lblPrevResult.Text = Calculator.PrevResult.ToString();
        }

        //----------------------------------------//

        private void CalculateResult(string OpTypeSymbol)
        {
            Calculator.PrevResult = Calculator.FinalResult;

            switch (GetOpTypeSymbol(OpTypeSymbol))
            {
                case enOpType.eAdd:
                    Calculator.FinalResult = Calculator.Number1 + Calculator.Number2;
                    break;

                case enOpType.eSubtract:
                    Calculator.FinalResult = Calculator.Number1 - Calculator.Number2;
                    break;

                case enOpType.eMultiplication:
                    Calculator.FinalResult = Calculator.Number1 * Calculator.Number2;
                    break;

                case enOpType.eDivdie:
                    Calculator.FinalResult = Calculator.Number1 / Calculator.Number2;
                    break;
            }
            ShowResult();
        }

        //----------------------------------------//

        private void txtNumber1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumber1.Text))
            {
                return;
            }
            Calculator.Number1 = Convert.ToDouble(txtNumber1.Text);
        }

        private void txtNumber1_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider(sender, e, txtNumber1);
        }

        //----------------------------------------//

        private void txtNumber2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumber2.Text))
            {
                return;
            }
            Calculator.Number2 = Convert.ToDouble(txtNumber2.Text);
        }

        private void txtNumber2_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider(sender, e, txtNumber2);
        }

        //----------------------------------------//

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CalculateResult(btnAdd.Tag.ToString());
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            CalculateResult(btnSubtract.Tag.ToString());
        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            CalculateResult(btnMultiplication.Tag.ToString());
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            CalculateResult(btnDivide.Tag.ToString());
        }

        //----------------------------------------//

        private void btnClear_Click(object sender, EventArgs e)
        {
            Calculator.Number1 = 0;
            Calculator.Number2 = 0;
            Calculator.PrevResult = 0;
            Calculator.FinalResult = 0;

            txtNumber1.Text = "";
            txtNumber2.Text = "";

            lblPrevResult.Text = "0";
            lblFinalResult.Text = "0";
        }

        //----------------------------------------//

    }
}
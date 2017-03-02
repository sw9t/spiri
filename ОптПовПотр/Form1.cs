using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using ОптПовПотр.Properties;

namespace ОптПовПотр
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        #region предпросмотр и печать
        string stringToPrint, documentString;
        Brush this_color;
        void InitPrint()
        {
            stringToPrint = ansRTB.Text;
            documentString = stringToPrint;
            this_color = new SolidBrush(ansRTB.ForeColor);
            printDocument1.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
        }

        private void OnPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;
            e.Graphics.MeasureString(stringToPrint, ansRTB.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);
            e.Graphics.DrawString(stringToPrint, ansRTB.Font, this_color,
                e.MarginBounds, StringFormat.GenericTypographic);
            stringToPrint = stringToPrint.Substring(charactersOnPage);
            e.HasMorePages = (stringToPrint.Length > 0);
            if (!e.HasMorePages)
                stringToPrint = documentString;
        }
        #endregion
        public double umax(double x1, double x2, double x3, double a, double b, double c)
        {
            return (a * x1 * x2 + b * x1 * x3 + c * x2 * x3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ansRTB.Clear();
            #region Вычисления
            double n12, n21, n13, n31, n23, n32, dudx1, dudx2, dudx3, umaxx, alpha, betta, gamma, n, p1, p2, p3, m, x1, x2, x3, lambda;
            double znam, dx1dm, dx2dm, dx3dm, dx1dp1, dx2dp1, dx3dp1, dx1dp2, dx2dp2, dx3dp2, dx1dp3, dx2dp3, dx3dp3;
            double e1m, e11p, e12p, e13p, e2m, e21p, e22p, e23p, e3m, e31p, e32p, e33p;
            int kolznak;
            try
            {
                p1 = double.Parse(textBox1.Text) + double.Parse(textBox7.Text);
                p2 = double.Parse(textBox2.Text) + double.Parse(textBox7.Text);
                p3 = double.Parse(textBox3.Text) + double.Parse(textBox7.Text);
                alpha = double.Parse(textBox4.Text); 
                betta = double.Parse(textBox5.Text);
                gamma = double.Parse(textBox6.Text);
                n = double.Parse(textBox7.Text);
                m = double.Parse(textBox8.Text);
                kolznak = (int)roundNUD.Value;
            }
            catch(FormatException)
            {
                MessageBox.Show("Ошибка при заполнении исходных данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            U_label.Text = String.Format("U = {0}*x1*x2 + {1}*x1*x3 + {2}*x2*x3\r\np1 = {3}, p2 = {4}, p3 = {5}", alpha, betta, gamma, p1, p2, p3);
            //оптимильный набор благ (аналитически- это функция спроса потребителя)
            x1 = -(m * alpha * gamma * p3 - m * gamma * gamma * p1 + m * betta * gamma * p2) / (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 - 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1);
            x2 = -(m * alpha * betta * p3 - m * betta * betta * p2 + m * betta * gamma * p1) / (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 - 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1);
            x3 = -(m * alpha * betta * p2 - m * alpha * alpha * p3 + m * alpha * gamma * p1) / (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 - 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1);
            umaxx = umax(x1, x2, x3, alpha, betta, gamma);
            lambda = -(2 * m * alpha * betta * gamma) / (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 - 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1);

            //предельные полезности благ
            dudx1 = -(2 * m * alpha * betta * gamma * p1) / (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 - 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1);
            dudx2 = -(2 * m * alpha * betta * gamma * p2) / (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 - 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1);
            dudx3 = -(2 * m * alpha * betta * gamma * p3) / (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 - 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1);
            //нормы замены благ
            n12 = -p2 / p1;
            n21 = -p1 / p2;
            n13 = -p3 / p1;
            n31 = -p1 / p3;
            n23 = -p3 / p2;
            n32 = -p2 / p3;
            //реакция потребителей при изменении дохода
            znam = (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 - 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1);
            dx1dm = -gamma * (alpha * p3 + betta * p2 - gamma * p1) / znam;
            dx2dm = -betta * (alpha * p3 - betta * p2 + gamma * p1) / znam;
            dx3dm = -alpha * (betta * p2 - alpha * p3 + gamma * p1) / znam;
            //реакция потребителей при изменении цены на 1-е благо
            dx1dp1 = -(m * gamma * gamma * (alpha * alpha * p3 * p3 + 6 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 - 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1)) / (znam * znam);
            dx2dp1 = (m * betta * gamma * (2 * alpha * betta * p2 * p3 - 3 * alpha * alpha * p3 * p3 + 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 - 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1)) / (znam * znam);
            dx3dp1 = (m * alpha * gamma * (alpha * alpha * p3 * p3 + 2 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 - 3 * betta * betta * p2 * p2 + 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1)) / (znam * znam);
            //реакция потребителей при изменении цены на 2-е благо
            dx1dp2 = (m * betta * gamma * (2 * alpha * betta * p2 * p3 - 3 * alpha * alpha * p3 * p3 + 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 - 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1)) / (znam * znam);
            dx2dp2 = -(m * betta * betta * (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 + 6 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 - 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1)) / (znam * znam);
            dx3dp2 = (m * alpha * betta * (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 + 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 + 2 * betta * gamma * p1 * p2 - 3 * gamma * gamma * p1 * p1)) / (znam * znam);
            //реакция потребителей при изменении цены на 3-е благо
            dx1dp3 = (m * alpha * gamma * (alpha * alpha * p3 * p3 + 2 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 - 3 * betta * betta * p2 * p2 + 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1)) / (znam * znam);
            dx2dp3 = (m * alpha * betta * (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 + 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 + 2 * betta * gamma * p1 * p2 - 3 * gamma * gamma * p1 * p1)) / (znam * znam);
            dx3dp3 = -(m * alpha * alpha * (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 + 6 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1)) / (znam * znam);
            //коэффициенты эластичности для блага 1
            e1m = dx1dm * m / x1;
            e11p = dx1dp1 * p1 / x1;
            e12p = dx2dp1 * p2 / x1;
            e13p = dx3dp1 * p3 / x1;

            e2m = dx2dm * m / x2;
            e21p = dx1dp2 * p1 / x2;
            e22p = dx2dp2 * p2 / x2;
            e23p = dx3dp2 * p3 / x2;

            e3m = dx3dm * m / x3;
            e31p = dx1dp3 * p1 / x3;
            e32p = dx2dp3 * p2 / x3;
            e33p = dx3dp3 * p3 / x3;
            #endregion
            #region Мат модель задачи
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("Условие задачи:\r\n");
            ansRTB.AppendText("Дана функция полезности U(x1, x2, x3). Требуется:\r\n" + 
                "1. Решить задачу оптимального поведения при заданных ценах p1, p2, p3 и доходе M.\r\n" + 
                "2. Вычислить реакции потребителя при изменении дохода и цен в точке оптимума.\r\n" + 
                "3. Вычислить предельные полезности товаров в точке оптимума.\r\n" + 
                "4. Вычислить норму замещения для 2-го и 3-го товаров в точке оптимума.\r\n" +
                "5. Вычислить коэффициенты эластичности по доходу и ценам для заданных цен и дохода.\r\n\r\n");
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("Математическая модель задачи имеет вид:\r\n");
            ansRTB.AppendText("    xj >= 0, j=[1,3]\r\n" +
                              "    x1p1 + x2p2 + x3p3 = M\r\n  U = αx1x2 + βx1x3 + γx2x3 --> max\r\n");

            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("Функция Лагранжа:\r\n");
            ansRTB.AppendText("    L(x1, x2, x3, λ) = U(x1, x2, x3) + λ(M - x1p1 - x2p2 - x3p3)\r\n");
            ansRTB.SelectedText =  String.Format("    L(x1, x2, x3, λ) = {0}x1x2 + {1}x1x3 + {2}x2x3 + λ(M - x1p1 - x2p2 - x3p3)\r\n\r\n",
               Math.Round(alpha, kolznak), Math.Round(betta, kolznak),Math.Round(gamma,kolznak));
            #endregion

            #region Значения благ
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("При заданных ценах и доходе необходимо приобрести:\r\n");
            ansRTB.AppendText(String.Format("    1-го блага - {0} единиц,\r\n" +
                                            "    2-го блага - {1} единиц,\r\n" +
                                            "    3-го блага - {2} единиц.\r\n",
                Math.Round(x1, kolznak), Math.Round(x2, kolznak), Math.Round(x3, kolznak)));
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("Максимальная полезность ");
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Regular);
            ansRTB.AppendText(String.Format("этого набора составит Umax = {0}\r\n" +
                "Каждый дополнительно использованный доллар вносит вклад в полезность равный λ = {1}\r\n\r\n",
                 Math.Round(umaxx, kolznak), Math.Round(lambda, kolznak)));
            #endregion
            #region Реакции на M

            string tmp;
            double mmax = 0;
            int mimax = 0;

            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("Реакции потребителя при изменении дохода M:\r\n");
            ansRTB.AppendText(String.Format("    dx1/dM = {0}", Math.Round(dx1dm, kolznak)));
            tmp = "Поскольку спрос на 1-е благо возрастает, то это благо ";
            if (dx1dm > 0)
            {
                ansRTB.AppendText("(>0)\r\n" + tmp);
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("ценное.\r\n");
                if (dx1dm > mmax) { mmax = dx1dm; mimax = 1; }
            }
            if (dx1dm < 0)
            {
                ansRTB.AppendText("(<0)\r\n" + tmp);
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("неценное.\r\n");
            }
            //====================================================
            ansRTB.AppendText(String.Format("    dx2/dM = {0}", Math.Round(dx2dm, kolznak)));
            tmp = "Поскольку спрос на 2-е благо возрастает, то это благо ";
            if (dx2dm > 0)
            {
                ansRTB.AppendText("(>0)\r\n" + tmp);
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("ценное.\r\n");
                if (dx2dm > mmax) { mmax = dx2dm; mimax = 2; }
            }
            if (dx2dm < 0)
            {
                ansRTB.AppendText("(<0)\r\n" + tmp);
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("неценное.\r\n");
            }
            //====================================================
            ansRTB.AppendText(String.Format("    dx3/dM = {0}", Math.Round(dx3dm, kolznak)));
            tmp = "Поскольку спрос на 3-е благо возрастает, то это благо ";
            if (dx3dm > 0)
            {
                ansRTB.AppendText("(>0)\r\n" + tmp);
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("ценное.\r\n");
                if (dx3dm > mmax) { mmax = dx3dm; mimax = 3; }
            }
            if (dx3dm < 0)
            {
                ansRTB.AppendText("(<0)\r\n" + tmp);
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("неценное.\r\n");
            }

            if (mimax != 0)
            {
                ansRTB.SelectedText =  String.Format("Наиболее ценным является {0}-е благо\r\n", mimax);
            }
            #endregion
            #region Реакции при изменении цены на 1е благо
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("\r\nОпределим реакции потребителя при изменении цены на 1-е благо:\r\n");
            tmp = "С увеличением цены на 1-е благо спрос на него {0}, значит, это благо ";
            ansRTB.AppendText(String.Format("    dx1/dp1 = {0}", Math.Round(dx1dp1, kolznak)));
            if (dx1dp1 < 0)
            {
                ansRTB.AppendText(String.Format("(<0)\r\n" + tmp, "уменьшается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("нормальное.\r\n");
            }
            if (dx1dp1 > 0)
            {
                ansRTB.AppendText(String.Format("(>0)\r\n" + tmp, "увеличивается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("ненормальное.\r\n");
            }
            if (dx1dp1 == 0)
            {
                ansRTB.AppendText(String.Format("(=0)\r\n" + tmp, "не изменяется"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("независимое.\r\n");
            }
            //=================================================

            ansRTB.AppendText(String.Format("    dx2/dp1 = {0}", Math.Round(dx2dp1, kolznak)));
            tmp = "С увеличением цены на 1-е благо спрос на 2-е благо {0}, эти блага ";
            if (dx2dp1 < 0)
            {
                ansRTB.AppendText(String.Format("(<0)\r\n" + tmp, "уменьшается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("взаимодополняемые.\r\n");
            }
            if (dx2dp1 > 0)
            {
                ansRTB.AppendText(String.Format("(>0)\r\n" + tmp, "увеличивается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("взаимозаменяемые.\r\n");
            }
            if (dx2dp1 == 0)
            {
                ansRTB.AppendText(String.Format("(=0)\r\n" + tmp, "не изменяется"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("независимые.\r\n");
            }
            //=================================================
            ansRTB.AppendText(String.Format("    dx3/dp1 = {0}", Math.Round(dx3dp1, kolznak)));
            tmp = "С увеличением цены на 1-е благо спрос на 3-е благо {0}, эти блага ";
            if (dx3dp1 < 0)
            {
                ansRTB.AppendText(String.Format("(<0)\r\n" + tmp, "уменьшается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("взаимодополняемые.\r\n");
            }
            if (dx3dp1 > 0)
            {
                ansRTB.AppendText(String.Format("(>0)\r\n" + tmp, "увеличивается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("взаимозаменяемые.\r\n");
            }
            if (dx3dp1 == 0)
            {
                ansRTB.AppendText(String.Format("(=0)\r\n" + tmp, "не изменяется"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("независимые.\r\n");
            }
            #endregion
            #region Реакции при изменении цены на 2е благо
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.SelectedText =  "\r\nОпределим реакции потребителя при изменении цены на 2-е благо:\r\n";
            ansRTB.AppendText(String.Format("    dx1/dp2 = {0}", Math.Round(dx1dp2, kolznak)));
            tmp = "С увеличением цены на 2-е благо спрос на 1-е благо {0}, эти блага ";
            if (dx1dp2 < 0)
            {
                ansRTB.AppendText(String.Format("(<0)\r\n" + tmp, "уменьшается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("взаимодополняемые.\r\n");
            }
            if (dx1dp2 > 0)
            {
                ansRTB.AppendText(String.Format("(>0)\r\n" + tmp, "увеличивается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("взаимозаменяемые.\r\n");
            }
            if (dx1dp2 == 0)
            {
                ansRTB.AppendText(String.Format("(=0)\r\n" + tmp, "не изменяется"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("независимые.\r\n");
            }
            //=================================================
            ansRTB.AppendText(String.Format("    dx2/dp2 = {0}", Math.Round(dx2dp2, kolznak)));
            tmp = "С увеличением цены на 2-е благо спрос на него {0}, это благо ";
            if (dx2dp2 < 0)
            {
                ansRTB.AppendText(String.Format("(<0)\r\n" + tmp, "уменьшается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("нормальное.\r\n");
            }
            if (dx2dp2 > 0)
            {
                ansRTB.AppendText(String.Format("(>0)\r\n" + tmp, "увеличивается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("ненормальное.\r\n");
            }
            if (dx2dp2 == 0)
            {
                ansRTB.AppendText(String.Format("(=0)\r\n" + tmp, "не изменяется"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("независимое.\r\n");
            }
            //=================================================
            ansRTB.AppendText(String.Format("    dx3/dp2 = {0}", Math.Round(dx3dp2, kolznak)));
            tmp = "С увеличением цены на 2-е благо спрос на 3-е благо {0}, эти блага ";
            if (dx3dp2 < 0)
            {
                ansRTB.AppendText(String.Format("(<0)\r\n" + tmp, "уменьшается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("взаимодополняемые.\r\n");
            }
            if (dx3dp2 > 0)
            {
                ansRTB.AppendText(String.Format("(>0)\r\n" + tmp, "увеличивается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("взаимозаменяемые.\r\n");
            }
            if (dx3dp2 == 0)
            {
                ansRTB.AppendText(String.Format("(=0)\r\n" + tmp, "не изменяется"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("независимые.\r\n");
            }
            #endregion
            #region Реакции при изменении цены на 3е благо
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.SelectedText =  "\r\nОпределим реакции потребителя при изменении цены на 3-е благо:\r\n";
            ansRTB.AppendText(String.Format("    dx1/dp3 = {0}", Math.Round(dx1dp3, kolznak)));
            tmp = "С увеличением цены на 3-е благо спрос на 1-е благо {0}, эти блага ";
            if (dx1dp3 < 0)
            {
                ansRTB.AppendText(String.Format("(<0)\r\n" + tmp, "уменьшается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("взаимодополняемые.\r\n");
            }
            if (dx1dp3 > 0)
            {
                ansRTB.AppendText(String.Format("(>0)\r\n" + tmp, "увеличивается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("взаимозаменяемые.\r\n");
            }
            if (dx1dp3 == 0)
            {
                ansRTB.AppendText(String.Format("(=0)\r\n" + tmp, "не изменяется"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("независимые.\r\n");
            }
            //=================================================
            ansRTB.AppendText(String.Format("    dx2/dp3 = {0}", Math.Round(dx2dp3, kolznak)));
            tmp = "С увеличением цены на 3-е благо спрос на 2-е благо {0}, эти блага ";
            if (dx2dp3 < 0)
            {
                ansRTB.AppendText(String.Format("(<0)\r\n" + tmp, "уменьшается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("взаимодополняемые.\r\n");
            }
            if (dx2dp3 > 0)
            {
                ansRTB.AppendText(String.Format("(>0)\r\n" + tmp, "увеличивается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("взаимозаменяемые.\r\n");
            }
            if (dx2dp3 == 0)
            {
                ansRTB.AppendText(String.Format("(=0)\r\n" + tmp, "не изменяется"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("независимые.\r\n");
            }
            //=================================================
            ansRTB.AppendText(String.Format("    dx3/dp3 = {0}", Math.Round(dx3dp3, kolznak)));
            tmp = "С увеличением цены на 3-е благо спрос на него {0}, это благо ";
            if (dx3dp3 < 0)
            {
                ansRTB.AppendText(String.Format("(<0)\r\n" + tmp, "уменьшается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("нормальное.\r\n");
            }
            if (dx3dp3 > 0)
            {
                ansRTB.AppendText(String.Format("(>0)\r\n" + tmp, "увеличивается"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("ненормальное.\r\n");
            }
            if (dx3dp3 == 0)
            {
                ansRTB.AppendText(String.Format("(=0)\r\n" + tmp, "не изменяется"));
                ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
                ansRTB.AppendText("независимое.\r\n");
            }
            #endregion
            #region Вычисление предельной полезности
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.SelectedText =  "\r\nВычислим предельные полезности благ в точке экстремума:\r\n";
            ansRTB.SelectedText =  String.Format("    X* = ({0}; {1}; {2})\r\n" +
            "    dU/dx1 = {3}\r\n" +
            "    dU/dx2 = {4}\r\n" +
            "    dU/dx3 = {5}\r\n" +
            "На 1 дополнительную единицу 1-го блага приходится {3} единиц дополнительной полезности.\r\n" +
            "На 1 дополнительную единицу 2-го блага приходится {4} единиц дополнительной полезности.\r\n" +
            "На 1 дополнительную единицу 3-го блага приходится {5} единиц дополнительной полезности.\r\n\r\n",
               Math.Round(x1,kolznak) , Math.Round(x2,kolznak), Math.Round(x3,kolznak), Math.Round(dudx1,kolznak),Math.Round(dudx2,kolznak) ,Math.Round(dudx3,kolznak) );
            #endregion
            #region Нормы замещения
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("Вычислим нормы замещения благ в точке оптимума X*:\r\n");
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("Нормы замены 1-го блага 2-м:\r\n");
            tmp =
                "Для замещения одной единицы {1}-го блага необходимо дополнительно приобрести {2} единиц {3}-го блага, " +
                "чтобы удовлетворенность осталась на прежнем уровне.\r\n";
            ansRTB.AppendText(String.Format("    n2,1 = {0}.\r\n" + tmp,
                Math.Round(n21, kolznak), 1, Math.Round(Math.Abs(n21), kolznak), 2));

            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("Нормы замены 1-го блага 3-м:\r\n");
            ansRTB.AppendText(String.Format("    n3,1 = {0}.\r\n" + tmp,
                Math.Round(n31, kolznak), 1, Math.Round(Math.Abs(n31), kolznak), 3));

            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("Нормы замены 2-го блага 1-м:\r\n");
            ansRTB.AppendText(String.Format("    n1,2 = {0}.\r\n" + tmp,
                Math.Round(n12, kolznak), 2, Math.Round(Math.Abs(n12), kolznak), 1));
            
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("Нормы замены 2-го блага 3-м:\r\n");
            ansRTB.AppendText(String.Format("    n3,2 = {0}.\r\n" + tmp,
                Math.Round(n32, kolznak), 2, Math.Round(Math.Abs(n32), kolznak), 3));
            
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("Нормы замены 3-го блага 1-м:\r\n");
            ansRTB.AppendText(String.Format("    n1,3 = {0}.\r\n" + tmp,
                Math.Round(n13, kolznak), 3, Math.Round(Math.Abs(n13), kolznak), 1));

            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("Нормы замены 3-го блага 2-м:\r\n");
            ansRTB.AppendText(String.Format("    n2,3 = {0}.\r\n" + tmp,
                Math.Round(n23, kolznak), 3, Math.Round(Math.Abs(n23), kolznak), 2));
            #endregion
            #region Коэффициенты эластичности
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("\r\nВычислим коэффициенты эластичности по доходу и ценам при заданных ценах и доходе:\r\n");
            ansRTB.AppendText(String.Format("    p1 = {0};    p2 = {1};     p3 = {2};     M = {3}\r\n",
                Math.Round(p1, kolznak), Math.Round(p2, kolznak), Math.Round(p3, kolznak), Math.Round(m, kolznak)));
            #region 1-е благо
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("\r\nДля блага 1:\r\n");
            if (e1m > 0)
            {
                ansRTB.AppendText(String.Format("    E1M = {0}\r\n" +
                                                "При увеличении дохода на 1% спрос на 1-е благо возрастет на {1}%.\r\n",
                    Math.Round(e1m, kolznak), Math.Round(Math.Abs(e1m), kolznak)));
            }

            if (e1m < 0)
            {
                ansRTB.AppendText(String.Format("    E1M = {0}\r\n" +
                                                "При увеличении дохода на 1% спрос на 1-е благо уменьшится на {1}%.\r\n",
                    Math.Round(e1m, kolznak), Math.Round(Math.Abs(e1m), kolznak)));
            }
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Italic);
            ansRTB.AppendText("Коэффициенты эластичности по ценам:\r\n");
            tmp = "При росте цены на {1}-е благо на 1% спрос на {2} на {3}%.\r\n";
            if (e11p > 0)
            {
                ansRTB.AppendText(String.Format("    E11p = {0}\r\n" + tmp,
                    Math.Round(e11p, kolznak), 1, "него увеличивается", Math.Round(Math.Abs(e11p), kolznak)));
            }

            if (e11p < 0)
            {
                ansRTB.AppendText(String.Format("    E11p = {0}\r\n" + tmp,
                    Math.Round(e11p, kolznak), 1, "него уменьшается", Math.Round(Math.Abs(e11p), kolznak)));
            }
            //============
            if (e12p > 0)
            {
                ansRTB.AppendText(String.Format("    E12p = {0}\r\n" + tmp,
                    Math.Round(e12p, kolznak), 2, "1-е благо увеличивается", Math.Round(Math.Abs(e12p), kolznak)));
            }

            if (e12p < 0)
            {
                ansRTB.AppendText(String.Format("    E12p = {0}\r\n" + tmp,
                    Math.Round(e12p, kolznak), 2, "1-е благо уменьшается", Math.Round(Math.Abs(e12p), kolznak)));
            }
            //===========
            if (e13p > 0)
            {
                ansRTB.AppendText(String.Format("    E13p = {0}\r\n" + tmp,
                    Math.Round(e13p, kolznak), 3, "1-е благо увеличивается", Math.Round(Math.Abs(e13p), kolznak)));
            }

            if (e13p < 0)
            {
                ansRTB.AppendText(String.Format("    E13p = {0}\r\n" + tmp,
                    Math.Round(e13p, kolznak), 3, "1-е благо уменьшается", Math.Round(Math.Abs(e13p), kolznak)));
            }
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Italic);
            ansRTB.AppendText("Проверка:\r\n");
            ansRTB.AppendText(String.Format("    E1M + E11p + E12p + E13p = 0\r\n    {0} + {1} + {2} + {3} = {4}\r\n",
                Math.Round(e1m, kolznak), Math.Round(e11p, kolznak), Math.Round(e12p, kolznak),
                Math.Round(e13p, kolznak), Math.Round(e1m + e11p + e12p + e13p, kolznak)));
            #endregion
            #region 2-е благо
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("\r\nДля блага 2:\r\n");
            if (e2m > 0)
            {
                ansRTB.AppendText(String.Format("    E2M = {0}\r\n" +
                                                "При увеличении дохода на 1% спрос на 2-е благо возрастет на {1}%.\r\n",
                    Math.Round(e2m, kolznak), Math.Round(Math.Abs(e2m), kolznak)));
            }

            if (e2m < 0)
            {
                ansRTB.AppendText(String.Format("    E2M = {0}\r\n" +
                                                "При увеличении дохода на 1% спрос на 2-е благо уменьшится на {1}%.\r\n",
                    Math.Round(e2m, kolznak), Math.Round(Math.Abs(e2m), kolznak)));
            }
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Italic);
            ansRTB.AppendText("Коэффициенты эластичности по ценам:\r\n");
            if (e21p > 0)
            {
                ansRTB.AppendText(String.Format("    E21p = {0}\r\n" + tmp,
                    Math.Round(e21p, kolznak), 1, "2-е благо увеличивается", Math.Round(Math.Abs(e21p), kolznak)));
            }

            if (e21p < 0)
            {
                ansRTB.AppendText(String.Format("    E21p = {0}\r\n" + tmp,
                    Math.Round(e21p, kolznak), 1, "2-е благо уменьшается", Math.Round(Math.Abs(e21p), kolznak)));
            }
            //============
            if (e22p > 0)
            {
                ansRTB.AppendText(String.Format("    E22p = {0}\r\n" + tmp,
                    Math.Round(e22p, kolznak), 2, "него увеличивается", Math.Round(Math.Abs(e22p), kolznak)));
            }

            if (e22p < 0)
            {
                ansRTB.AppendText(String.Format("    E22p = {0}\r\n" + tmp,
                    Math.Round(e22p, kolznak), 2, "него уменьшается", Math.Round(Math.Abs(e22p), kolznak)));
            }
            //===========
            if (e23p > 0)
            {
                ansRTB.AppendText(String.Format("    E23p = {0}\r\n" + tmp,
                    Math.Round(e23p, kolznak), 3, "2-е благо увеличивается", Math.Round(Math.Abs(e23p), kolznak)));
            }

            if (e23p < 0)
            {
                ansRTB.AppendText(String.Format("    E23p = {0}\r\n" + tmp,
                    Math.Round(e23p, kolznak), 3, "2-е благо уменьшается", Math.Round(Math.Abs(e23p), kolznak)));
            }
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Italic);
            ansRTB.AppendText("Проверка:\r\n");
            ansRTB.AppendText(String.Format("    E2M + E21p + E22p + E23p = 0\r\n    {0} + {1} + {2} + {3} = {4}\r\n",
                Math.Round(e2m, kolznak), Math.Round(e21p, kolznak), Math.Round(e22p, kolznak),
                Math.Round(e23p, kolznak), Math.Round(e2m + e21p + e22p + e23p, kolznak)));
            #endregion
            #region 3-е благо
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("\r\nДля блага 3:\r\n");
            if (e3m > 0)
            {
                ansRTB.AppendText(String.Format("    E3M = {0}\r\n" +
                                                "При увеличении дохода на 1% спрос на 3-е благо возрастет на {1}%.\r\n",
                    Math.Round(e3m, kolznak), Math.Round(Math.Abs(e3m), kolznak)));
            }

            if (e3m < 0)
            {
                ansRTB.AppendText(String.Format("    E3M = {0}\r\n" +
                                                "При увеличении дохода на 1% спрос на 3-е благо уменьшится на {1}%.\r\n",
                    Math.Round(e3m, kolznak), Math.Round(Math.Abs(e3m), kolznak)));
            }
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Italic);
            ansRTB.AppendText("Коэффициенты эластичности по ценам:\r\n");
            if (e31p > 0)
            {
                ansRTB.AppendText(String.Format("    E31p = {0}\r\n" + tmp,
                    Math.Round(e31p, kolznak), 1, "3-е благо увеличивается", Math.Round(Math.Abs(e31p), kolznak)));
            }

            if (e31p < 0)
            {
                ansRTB.AppendText(String.Format("    E31p = {0}\r\n" + tmp,
                    Math.Round(e31p, kolznak), 1, "3-е благо уменьшается", Math.Round(Math.Abs(e31p), kolznak)));
            }
            //============
            if (e32p > 0)
            {
                ansRTB.AppendText(String.Format("    E32p = {0}\r\n" + tmp,
                    Math.Round(e32p, kolznak), 2, "3-е благо увеличивается", Math.Round(Math.Abs(e32p), kolznak)));
            }

            if (e32p < 0)
            {
                ansRTB.AppendText(String.Format("    E32p = {0}\r\n" + tmp,
                    Math.Round(e32p, kolznak), 2, "3-е благо уменьшается на", Math.Round(Math.Abs(e32p), kolznak)));
            }
            //===========
            if (e33p > 0)
            {
                ansRTB.AppendText(String.Format("    E33p = {0}\r\n" + tmp,
                    Math.Round(e33p, kolznak), 3, "него увеличивается", Math.Round(Math.Abs(e33p), kolznak)));
            }

            if (e33p < 0)
            {
                ansRTB.AppendText(String.Format("    E33p = {0}\r\n" + tmp,
                    Math.Round(e33p, kolznak), 3, "него уменьшается", Math.Round(Math.Abs(e33p), kolznak)));
            }
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Italic);
            ansRTB.AppendText("Проверка:\r\n");
            ansRTB.AppendText(String.Format("    E3M + E31p + E32p + E33p = 0\r\n    {0} + {1} + {2} + {3} = {4}\r\n",
                Math.Round(e3m, kolznak), Math.Round(e31p, kolznak), Math.Round(e32p, kolznak),
                Math.Round(e33p, kolznak), Math.Round(e3m + e31p + e32p + e33p, kolznak)));

            #endregion
            #endregion
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.developers, 
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void вызовСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тут скоро будет справка");
        }
        private void сохранитьРешениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
                File.WriteAllText(sfd.FileName, ansRTB.Text);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text =
                textBox6.Text = textBox8.Text = ansRTB.Text = "";
        }
        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InitPrint();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                InitPrint();
                printDocument1.Print();
               
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

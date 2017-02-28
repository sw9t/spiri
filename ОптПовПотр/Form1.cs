using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ОптПовПотр
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
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
            try
            {
                p1 = int.Parse(textBox1.Text) + int.Parse(textBox7.Text);
                p2 = int.Parse(textBox2.Text) + int.Parse(textBox7.Text);
                p3 = int.Parse(textBox3.Text) + int.Parse(textBox7.Text);
                alpha = int.Parse(textBox4.Text);
                betta = int.Parse(textBox5.Text);
                gamma = int.Parse(textBox6.Text);
                n = int.Parse(textBox7.Text);
                m = int.Parse(textBox8.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("Ошибка при заполнении исходных данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            U_label.Text = String.Format("U = {0}*x1*x2 + {1}*x1*x3 + {2}*x2*x3\np1 = {3}, p2 = {4}, p3 = {5}", alpha, betta, gamma, p1, p2, p3);
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
            ansRTB.Text += "Математическая модель задачи имеет вид:\n  xj >= 0, j=[1,3]\n"+
                "  x1p1 + x2p2 + x3p3 = M\n  U = αx1x2 + βx1x3 + γx2x3 --> max\n"+
                "Функция Лагранжа:\n  L(x1, x2, x3, λ) = U(x1, x2, x3) + λ(M - x1p1 - x2p2 - x3p3)\n";
            ansRTB.Text += String.Format("  L(x1, x2, x3, λ) = {0}x1x2 + {1}x1x3 + {2}x2x3 + λ(M - x1p1 - x2p2 - x3p3)\n\n",
                alpha, betta, gamma);
            #endregion

            #region Значения благ
            ansRTB.Text += String.Format("При заданных ценах и доходе необходимо приобрести:\n" +
                "  1-го блага - {0} единиц,\n" +
                "  2-го блага - {1} единиц,\n" +
                "  3-го блага - {2} единиц.\n" +
                "Максимальная полезность этого набора составит Umax = {3}\n" +
                "Каждый дополнительно использованный доллар вносит вклад в полезность равный λ = {4}\n\n",
                x1, x2, x3, umaxx, lambda);
            #endregion
            #region Реакции на M

            double mmax = 0;
            int mimax = 0;
            ansRTB.Text += "Реакции потребителя при изменении дохода M:\n";
            if (dx1dm > 0)
            {
                ansRTB.Text += String.Format("dx1/dM = {0} (>0)\n" +
                "Поскольку спрос на 1-е благо возрастает, то это благо ценное.\n",
                dx1dm);
                if (dx1dm > mmax) { mmax = dx1dm; mimax = 1; }
            }
            if (dx1dm < 0)
            {
                ansRTB.Text += String.Format("dx1/dM = {0} (<0)\n" +
                "Поскольку спрос на 1-е благо возрастает, то это благо неценное.\n",
                dx1dm);
            }
            if (dx1dm == 0)
            {
                ansRTB.Text += String.Format("dx1/dM = {0} (=0)\n",
                    //"Поскольку спрос на 1-е благо возрастает, то это благо независимое.\n",
                dx1dm);
            }
            //====================================================
            if (dx2dm > 0)
            {
                ansRTB.Text += String.Format("dx2/dM = {0} (>0)\n" +
                "Поскольку спрос на 2-е благо возрастает, то это благо ценное.\n",
                dx2dm);
                if (dx2dm > mmax) { mmax = dx2dm; mimax = 2; }
            }
            if (dx2dm < 0)
            {
                ansRTB.Text += String.Format("dx2/dM = {0} (<0)\n" +
                "Поскольку спрос на 2-е благо возрастает, то это благо неценное.\n",
                dx2dm);
            }
            if (dx2dm == 0)
            {
                ansRTB.Text += String.Format("dx2/dM = {0} (=0)\n",
                    //"Поскольку спрос на 2-е благо возрастает, то это благо независимое.\n",
                dx2dm);
            }
            //====================================================
            if (dx3dm > 0)
            {
                ansRTB.Text += String.Format("dx3/dM = {0} (>0)\n" +
                "Поскольку спрос на 3-е благо возрастает, то это благо ценное.\n",
                dx3dm);
                if (dx3dm > mmax) { mmax = dx3dm; mimax = 3; }
            }
            if (dx3dm < 0)
            {
                ansRTB.Text += String.Format("dx3/dM = {0} (<0)\n" +
                "Поскольку спрос на 3-е благо возрастает, то это благо неценное.\n",
                dx3dm);
            }
            if (dx3dm == 0)
            {
                ansRTB.Text += String.Format("dx3/dM = {0} (=0)\n",
                    //"Поскольку спрос на 3-е благо возрастает, то это благо независимое.\n",
                dx3dm);
            }
            if (mimax != 0)
            {
                ansRTB.Text += String.Format("Наиболее ценным является {0}-е благо\n\n", mimax);
            }
            #endregion
            #region Реакции при изменении цены на 1е благо
            ansRTB.Text += "\nОпределим реакции потребителя при изменении цены на 1-е благо:\n";
            if (dx1dp1 < 0)
            {
                ansRTB.Text += String.Format("dx1/dp1 = {0}(<0)\n" +
                "С увеличением цены на 1-е благо спрос на него уменьшается, значит, 1-е благо нормальное.\n",
                    dx1dp1);
            }
            if (dx1dp1 > 0)
            {
                ansRTB.Text += String.Format("dx1/dp1 = {0}(>0)\n" +
                "С увеличением цены на 1-е благо спрос на него увеличивается, значит, 1-е благо ненормальное.\n",
                    dx1dp1);
            }
            if (dx1dp1 == 0)
            {
                ansRTB.Text += String.Format("dx1/dp1 = {0}(=0)\n" +
                "С увеличением цены на 1-е благо спрос на него не изменяется, значит, 1-е благо независимое.\n",
                    dx1dp1);
            }
            //=================================================
            if (dx2dp1 < 0)
            {
                ansRTB.Text += String.Format("dx2/dp1 = {0}(<0)\n" +
                "С увеличением цены на 1-е благо спрос на 2-е благо уменьшается, эти блага взаимодополняемые.\n",
                    dx2dp1);
            }
            if (dx2dp1 > 0)
            {
                ansRTB.Text += String.Format("dx2/dp1 = {0}(>0)\n" +
                "С увеличением цены на 1-е благо спрос на 2-е благо увеличивается, эти блага взаимозаменяемые.\n",
                    dx2dp1);
            }
            if (dx2dp1 == 0)
            {
                ansRTB.Text += String.Format("dx2/dp1 = {0}(=0)\n" +
                "С увеличением цены на 1-е благо спрос на 2-е благо не изменяется, эти блага независимые.\n",
                    dx2dp1);
            }
            //=================================================
            if (dx3dp1 < 0)
            {
                ansRTB.Text += String.Format("dx3/dp1 = {0}(<0)\n" +
                "С увеличением цены на 1-е благо спрос на 3-е благо уменьшается, эти блага взаимодополняемые.\n",
                    dx3dp1);
            }
            if (dx3dp1 > 0)
            {
                ansRTB.Text += String.Format("dx3/dp1 = {0}(>0)\n" +
                "С увеличением цены на 1-е благо спрос на 3-е благо увеличивается, эти блага взаимозаменяемые.\n",
                    dx3dp1);
            }
            if (dx3dp1 == 0)
            {
                ansRTB.Text += String.Format("dx3/dp1 = {0}(=0)\n" +
                "С увеличением цены на 1-е благо спрос на 3-е благо не изменяется, эти блага независимые.\n",
                    dx3dp1);
            }
            #endregion
            #region Реакции при изменении цены на 2е благо
            ansRTB.Text += "\nОпределим реакции потребителя при изменении цены на 2-е благо:\n";
            if (dx1dp2 < 0)
            {
                ansRTB.Text += String.Format("dx1/dp2 = {0}(<0)\n" +
                "С увеличением цены на 2-е благо спрос на 1-е благо уменьшается, эти блага взаимодополняемые.\n",
                    dx1dp2);
            }
            if (dx1dp2 > 0)
            {
                ansRTB.Text += String.Format("dx1/dp2 = {0}(>0)\n" +
                "С увеличением цены на 2-е благо спрос на 1-е благо увеличивается, эти блага взаимозаменяемые.\n",
                    dx1dp2);
            }
            if (dx1dp2 == 0)
            {
                ansRTB.Text += String.Format("dx1/dp2 = {0}(=0)\n" +
                "С увеличением цены на 2-е благо спрос на 1-е благо не изменяется, эти блага независимые.\n",
                    dx1dp2);
            }
            //=================================================
            if (dx2dp2 < 0)
            {
                ansRTB.Text += String.Format("dx2/dp2 = {0}(<0)\n" +
                "С увеличением цены на 2-е благо спрос на него уменьшается, это благо нормальное.\n",
                    dx2dp2);
            }
            if (dx2dp2 > 0)
            {
                ansRTB.Text += String.Format("dx2/dp2 = {0}(>0)\n" +
                "С увеличением цены на 2-е благо спрос на него увеличивается, это благо ненормальное.\n",
                    dx2dp2);
            }
            if (dx2dp2 == 0)
            {
                ansRTB.Text += String.Format("dx2/dp2 = {0}(=0)\n" +
                "С увеличением цены на 2-е благо спрос на него не изменяется, это благо независимое.\n",
                    dx2dp2);
            }
            //=================================================
            if (dx3dp2 < 0)
            {
                ansRTB.Text += String.Format("dx3/dp2 = {0}(<0)\n" +
                "С увеличением цены на 2-е благо спрос на 3-е благо уменьшается, эти блага взаимодополняемые.\n",
                    dx3dp2);
            }
            if (dx3dp2 > 0)
            {
                ansRTB.Text += String.Format("dx3/dp2 = {0}(>0)\n" +
                "С увеличением цены на 2-е благо спрос на 3-е благо увеличивается, эти блага взаимозаменяемые.\n",
                    dx3dp2);
            }
            if (dx3dp2 == 0)
            {
                ansRTB.Text += String.Format("dx3/dp2 = {0}(=0)\n" +
                "С увеличением цены на 2-е благо спрос на 3-е благо не изменяется, эти блага независимые.\n",
                    dx3dp2);
            }
            #endregion
            #region Реакции при изменении цены на 3е благо
            ansRTB.Text += "\nОпределим реакции потребителя при изменении цены на 3-е благо:\n";
            if (dx1dp3 < 0)
            {
                ansRTB.Text += String.Format("dx1/dp3 = {0}(<0)\n" +
                "С увеличением цены на 1-е благо спрос на 1-е благо уменьшается, эти блага взаимодополняемые.\n",
                    dx1dp3);
            }
            if (dx1dp3 > 0)
            {
                ansRTB.Text += String.Format("dx1/dp3 = {0}(>0)\n" +
                "С увеличением цены на 3-е благо спрос на 1-е благо увеличивается, эти блага взаимозаменяемые.\n",
                    dx1dp3);
            }
            if (dx1dp3 == 0)
            {
                ansRTB.Text += String.Format("dx1/dp3 = {0}(=0)\n" +
                "С увеличением цены на 3-е благо спрос на 1-е благо не изменяется, эти блага независимые.\n",
                    dx1dp3);
            }
            //=================================================
            if (dx2dp3 < 0)
            {
                ansRTB.Text += String.Format("dx2/dp3 = {0}(<0)\n" +
                "С увеличением цены на 3-е благо спрос на 2-е благо уменьшается, эти блага взаимодополняемые.\n",
                    dx2dp3);
            }
            if (dx2dp3 > 0)
            {
                ansRTB.Text += String.Format("dx2/dp3 = {0}(>0)\n" +
                "С увеличением цены на 3-е благо спрос на 2-е благо увеличивается, эти блага взаимозаменяемые.\n",
                    dx2dp3);
            }
            if (dx2dp3 == 0)
            {
                ansRTB.Text += String.Format("dx2/dp3 = {0}(=0)\n" +
                "С увеличением цены на 3-е благо спрос на 2-е благо не изменяется, эти блага независимые.\n",
                    dx2dp3);
            }
            //=================================================
            if (dx3dp3 < 0)
            {
                ansRTB.Text += String.Format("dx3/dp3 = {0}(<0)\n" +
                "С увеличением цены на 3-е благо спрос на него уменьшается, это благо нормальное.\n",
                    dx3dp3);
            }
            if (dx3dp3 > 0)
            {
                ansRTB.Text += String.Format("dx3/dp3 = {0}(>0)\n" +
                "С увеличением цены на 3-е благо спрос на него увеличивается, это благо ненормальное.\n",
                    dx3dp3);
            }
            if (dx3dp3 == 0)
            {
                ansRTB.Text += String.Format("dx3/dp3 = {0}(=0)\n" +
                "С увеличением цены на 3-е благо спрос на него не изменяется, это благо независимое.\n",
                    dx3dp3);
            }
            #endregion
            #region Вычисление предельной полезности
            ansRTB.Text += "\nВычислим предельные полезности благ в точке экстремума.\n";
            ansRTB.Text += String.Format("X* = ({0}; {1}; {2})\n" +
            "dU/dx1 = {3}\n" +
            "dU/dx2 = {4}\n" +
            "dU/dx3 = {5}\n" +
            "На 1 дополнительную единицу 1-го блага приходится {3} единиц дополнительной полезности.\n" +
            "На 1 дополнительную единицу 2-го блага приходится {4} единиц дополнительной полезности.\n" +
            "На 1 дополнительную единицу 3-го блага приходится {5} единиц дополнительной полезности.\n\n",
                x1, x2, x3, dudx1, dudx2, dudx3);
            #endregion
            #region Нормы замещения
            ansRTB.Text += "Вычислим нормы замещения благ в точке оптимума X*.\n";
            ansRTB.Text += String.Format("Нормы замены 1-го блага 2-м:\n" +
                "n2,1 = {0}.\n" +
                "Для замещения одной единицы 1-го блага необходимо дополнительно приобрести {1} единиц 2-го блага, чтобы удовлетворенность осталась на прежнем уровне.\n" +
                "Нормы замены 1-го блага 3-м:\n" +
                "n3,1 = {2}.\n" +
                "Для замещения одной единицы 1-го блага необходимо дополнительно приобрести {3} единиц 3-го блага, чтобы удовлетворенность осталась на прежнем уровне.\n" +

                "Нормы замены 2-го блага 1-м:\n" +
                "n1,2 = {4}.\n" +
                "Для замещения одной единицы 2-го блага необходимо дополнительно приобрести {5} единиц 1-го блага, чтобы удовлетворенность осталась на прежнем уровне.\n" +
                "Нормы замены 2-го блага 3-м:\n" +
                "n3,2 = {6}.\n" +
                "Для замещения одной единицы 2-го блага необходимо дополнительно приобрести {7} единиц 3-го блага, чтобы удовлетворенность осталась на прежнем уровне.\n" +

                "Нормы замены 3-го блага 1-м:\n" +
                "n1,3 = {8}.\n" +
                "Для замещения одной единицы 3-го блага необходимо дополнительно приобрести {9} единиц 1-го блага, чтобы удовлетворенность осталась на прежнем уровне.\n" +
                "Нормы замены 3-го блага 2-м:\n" +
                "n2,3 = {10}.\n" +
                "Для замещения одной единицы 3-го блага необходимо дополнительно приобрести {11} единиц 2-го блага, чтобы удовлетворенность осталась на прежнем уровне.\n\n",
                n21, Math.Abs(n21), n31, Math.Abs(n31), n12, Math.Abs(n12), n32, Math.Abs(n32),
                n13, Math.Abs(n13), n23, Math.Abs(n23));
            #endregion
            #region Коэффициенты эластичности
            ansRTB.Text += String.Format("Вычислим коэффициенты эластичности по доходу и ценам при заданных ценах и доходе:\n" +
                "p1 = {0}; p2 = {1}; p3 = {2}; M = {3}\n",
                p1, p2, p3, m);
            #region 1-е благо
            ansRTB.Text += "\nДля блага 1:\n";
            if (e1m > 0)
            {
                ansRTB.Text += String.Format("E1M = {0}\n" +
                "При увеличении дохода на 1% спрос на 1-е благо возрастет на {1}%.\n",
                e1m, Math.Abs(e1m));
            }

            if (e1m < 0)
            {
                ansRTB.Text += String.Format("E1M = {0}\n" +
                "При увеличении дохода на 1% спрос на 1-е благо уменьшится на {1}%.\n",
                e1m, Math.Abs(e1m));
            }

            ansRTB.Text += "Коэффициенты эластичности по ценам:\n";
            if (e11p > 0)
            {
                ansRTB.Text += String.Format("E11p = {0}\n" +
                "При росте цены на 1-е благо на 1% спрос на него увеличивается на {1}%.\n",
                e11p, Math.Abs(e11p));
            }

            if (e11p < 0)
            {
                ansRTB.Text += String.Format("E11p = {0}\n" +
                "При росте цены на 1-е благо на 1% спрос на него уменьшается на {1}%.\n",
                e11p, Math.Abs(e11p));
            }
            //============
            if (e12p > 0)
            {
                ansRTB.Text += String.Format("E12p = {0}\n" +
                "При росте цены на 2-е благо на 1% спрос на 1-е благо увеличивается на {1}%.\n",
                e12p, Math.Abs(e12p));
            }

            if (e12p < 0)
            {
                ansRTB.Text += String.Format("E12p = {0}\n" +
                "При росте цены на 2-е благо на 1% спрос на 1-е благо уменьшается на {1}%.\n",
                e12p, Math.Abs(e12p));
            }
            //===========
            if (e13p > 0)
            {
                ansRTB.Text += String.Format("E13p = {0}\n" +
                "При росте цены на 3-е благо на 1% спрос на 1-е благо увеличивается на {1}%.\n",
                e13p, Math.Abs(e13p));
            }

            if (e13p < 0)
            {
                ansRTB.Text += String.Format("E13p = {0}\n" +
                "При росте цены на 3-е благо на 1% спрос на 1-е благо уменьшается на {1}%.\n",
                e13p, Math.Abs(e13p));
            }
            ansRTB.Text += String.Format("\nПроверка:\n" +
                "E1M + E11p + E12p + E13p = 0\n" +
                "{0} + {1} + {2} + {3} = {4}\n",
                e1m, e11p, e12p, e13p, Math.Round(e1m + e11p + e12p + e13p, 5));
            #endregion
            #region 2-е благо
            ansRTB.Text += "\nДля блага 2:\n";
            if (e2m > 0)
            {
                ansRTB.Text += String.Format("E2M = {0}\n" +
                "При увеличении дохода на 1% спрос на 2-е благо возрастет на {1}%.\n",
                e2m, Math.Abs(e2m));
            }

            if (e2m < 0)
            {
                ansRTB.Text += String.Format("E2M = {0}\n" +
                "При увеличении дохода на 1% спрос на 2-е благо уменьшится на {1}%.\n",
                e2m, Math.Abs(e2m));
            }

            ansRTB.Text += "Коэффициенты эластичности по ценам:\n";
            if (e21p > 0)
            {
                ansRTB.Text += String.Format("E21p = {0}\n" +
                "При росте цены на 1-е благо на 1% спрос на 2-е благо увеличивается на {1}%.\n",
                e21p, Math.Abs(e21p));
            }

            if (e21p < 0)
            {
                ansRTB.Text += String.Format("E21p = {0}\n" +
                "При росте цены на 1-е благо на 1% спрос на 2-е благо уменьшается на {1}%.\n",
                e21p, Math.Abs(e21p));
            }
            //============
            if (e22p > 0)
            {
                ansRTB.Text += String.Format("E22p = {0}\n" +
                "При росте цены на 2-е благо на 1% спрос на него увеличивается на {1}%.\n",
                e22p, Math.Abs(e22p));
            }

            if (e22p < 0)
            {
                ansRTB.Text += String.Format("E22p = {0}\n" +
                "При росте цены на 2-е благо на 1% спрос на него уменьшается на {1}%.\n",
                e22p, Math.Abs(e22p));
            }
            //===========
            if (e23p > 0)
            {
                ansRTB.Text += String.Format("E23p = {0}\n" +
                "При росте цены на 3-е благо на 1% спрос на 2-е благо увеличивается на {1}%.\n",
                e23p, Math.Abs(e23p));
            }

            if (e23p < 0)
            {
                ansRTB.Text += String.Format("E23p = {0}\n" +
                "При росте цены на 3-е благо на 1% спрос на 2-е благо уменьшается на {1}%.\n",
                e23p, Math.Abs(e23p));
            }
            ansRTB.Text += String.Format("\nПроверка:\n" +
                "E2M + E21p + E22p + E23p = 0\n" +
                "{0} + {1} + {2} + {3} = {4}\n",
                e2m, e21p, e22p, e23p, Math.Round(e2m + e21p + e22p + e23p, 5));
            #endregion

            #region 3-е благо
            ansRTB.Text += "\nДля блага 3:\n";
            if (e3m > 0)
            {
                ansRTB.Text += String.Format("E3M = {0}\n" +
                "При увеличении дохода на 1% спрос на 3-е благо возрастет на {1}%.\n",
                e3m, Math.Abs(e3m));
            }

            if (e3m < 0)
            {
                ansRTB.Text += String.Format("E3M = {0}\n" +
                "При увеличении дохода на 1% спрос на 3-е благо уменьшится на {1}%.\n",
                e3m, Math.Abs(e3m));
            }

            ansRTB.Text += "Коэффициенты эластичности по ценам:\n";
            if (e31p > 0)
            {
                ansRTB.Text += String.Format("E31p = {0}\n" +
                "При росте цены на 1-е благо на 1% спрос на 3-е благо увеличивается на {1}%.\n",
                e31p, Math.Abs(e31p));
            }

            if (e31p < 0)
            {
                ansRTB.Text += String.Format("E31p = {0}\n" +
                "При росте цены на 1-е благо на 1% спрос на 3-е благо уменьшается на {1}%.\n",
                e31p, Math.Abs(e31p));
            }
            //============
            if (e32p > 0)
            {
                ansRTB.Text += String.Format("E32p = {0}\n" +
                "При росте цены на 2-е благо на 1% спрос на 3-е благо увеличивается на {1}%.\n",
                e32p, Math.Abs(e32p));
            }

            if (e32p < 0)
            {
                ansRTB.Text += String.Format("E32p = {0}\n" +
                "При росте цены на 2-е благо на 1% спрос на 3-е благо уменьшается на {1}%.\n",
                e32p, Math.Abs(e32p));
            }
            //===========
            if (e33p > 0)
            {
                ansRTB.Text += String.Format("E33p = {0}\n" +
                "При росте цены на 3-е благо на 1% спрос на него увеличивается на {1}%.\n",
                e33p, Math.Abs(e33p));
            }

            if (e33p < 0)
            {
                ansRTB.Text += String.Format("E33p = {0}\n" +
                "При росте цены на 3-е благо на 1% спрос на него уменьшается на {1}%.\n",
                e33p, Math.Abs(e33p));
            }
            ansRTB.Text += String.Format("\nПроверка:\n" +
                "E3M + E31p + E32p + E33p = 0\n" +
                "{0} + {1} + {2} + {3} = {4}\n",
                e3m, e31p, e32p, e33p, Math.Round(e3m + e31p + e32p + e33p, 5));
            #endregion
            #endregion

            #region
            #endregion
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа разработана для решения задач оптимального поведения потребителя\n"+
            "специально для кафедры прикладной математики и информатики.\n"+
            "Разработана студентами группы ФМ13ДР62ПФ (403):\n"+
            "• Гощина Н.Н.\n"+
            "• Диденко А.И.\n"+
            "• Лысенко А.А.\n"+
            "• Штырба С.Г.\n"+
            "© 2017, физико-математический факультет ПГУ им. Т.Г. Шевченко\n", 
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
    }
}

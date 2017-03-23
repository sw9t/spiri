using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Кобба_Дуглас
{
    public partial class App2 : Form
    {
        public App2()
        {
            InitializeComponent();
        }

        void Solve()
        {
            #region Вычисления
            double A, x2, p, q1, q2, E1, E2, k;
            double dydx1x0, dydx2x0, n21, n12, x1_ch, x2_ch, x1_ov, x2_ov, yp, yfp;
            double dx1dp, dx2dp, dydp, dydq1, dydq2, dx1dq1, dx1dq2, dx2dq1, dx2dq2, e1p, e1q1, e1q2, e2p, e2q1, e2q2, eyp, eyq1, eyq2;
            int R = (int)roundNUD.Value;
            var alpha = Double.Parse(alphaTb.Text);
            var beta = Double.Parse(betaTb.Text);
            A = Double.Parse(A_Tb.Text);
            var x1 = Double.Parse(x1Tb.Text);
            x2 = Double.Parse(x2Tb.Text);
            p = Double.Parse(pTb.Text);
            q1 = Double.Parse(q1Tb.Text);
            q2 = Double.Parse(q2Tb.Text);
            var znam1 = Math.Pow(alpha, alpha * (1 / (alpha + beta))) *
                           Math.Pow(beta, beta * (1 / (alpha + beta))) *
                           Math.Pow(A, 1 / (alpha + beta));
            dydx1x0 = A * alpha * Math.Pow(x1, alpha - 1) * Math.Pow(x2, beta);
            dydx2x0 = A * beta * Math.Pow(x1, alpha) * Math.Pow(x2, beta - 1);
            n21 = -A * alpha * x2 / (A * beta * x1);
            n12 = A * beta * x1 / (-A * alpha * x2);
            x1_ch = Math.Pow(A, 1 / (-alpha - beta + 1)) * Math.Pow(beta, (1 / (-alpha - beta + 1) * beta)) *
                    Math.Pow(alpha, (1 / (-alpha - beta + 1) * (-beta + 1)));
            x2_ch = x1_ch * beta / alpha;
            x1_ov = (x1_ch * Math.Pow(p, 1 / (-alpha - beta + 1))) /
                    (Math.Pow(q1, (1 / (-alpha - beta + 1) * (-beta + 1))) *
                     Math.Pow(q2, 1 / (-alpha - beta + 1) * beta));
            x2_ov = (x2_ch * Math.Pow(p, 1 / (-alpha - beta + 1))) /
                    (Math.Pow(q1, (1 / (-alpha - beta + 1) * (-beta + 1)) - 1) *
                     Math.Pow(q2, (1 / (-alpha - beta + 1) * beta) + 1));
            yp = A * Math.Pow(x1_ov, alpha) * Math.Pow(x2_ov, beta);
            var pesozvezchkoy = p * yp - q1 * x1_ov - q2 * x2_ov;
            yfp = A * Math.Pow(x1_ch, alpha) * Math.Pow(x2_ch, beta);
            dx1dp = x1_ch * (1 / (-alpha - beta + 1)) * Math.Pow(p, (1 / (-alpha - beta + 1)) - 1) /
                    (Math.Pow(q1, 1 / (-alpha - beta + 1) * (-beta + 1)) *
                     Math.Pow(q2, 1 / (-alpha - beta + 1) * beta));
            dx2dp = x2_ch * (1 / (-alpha - beta + 1)) * Math.Pow(p, (1 / (-alpha - beta + 1)) - 1) /
                    (Math.Pow(q1, 1 / (-alpha - beta + 1) * (-beta + 1) - 1) *
                     Math.Pow(q2, 1 / (-alpha - beta + 1) * beta + 1));
            dydp = yfp * 1 / (-alpha - beta + 1) * (alpha + beta) *
                   Math.Pow(p, (1 / (-alpha - beta + 1) * (alpha + beta)) - 1) /
                   (Math.Pow(q1, (1 / (-alpha - beta + 1) * (-beta + 1) * alpha +
                                  (1 / (-alpha - beta + 1) * (-beta + 1) - 1) * beta)) *
                    Math.Pow(q2,
                        1 / (-alpha - beta + 1) * beta * alpha + (1 / (-alpha - beta + 1) * beta + 1) * beta));
            dydq1 = -(1 / (-alpha - beta + 1) * (-beta + 1) * alpha +
                      (1 / (-alpha - beta + 1) * (-beta + 1) - 1) * beta) *
                    yfp * Math.Pow(p, 1 / (-alpha - beta + 1) * (alpha + beta)) /
                    (Math.Pow(q1, 1 / (-alpha - beta + 1) * (-beta + 1) * alpha +
                                  (1 / (-alpha - beta + 1) * (-beta + 1) - 1) * beta + 1) *
                     Math.Pow(q2, 1 / (-alpha - beta + 1) * beta * alpha +
                                  (1 / (-alpha - beta + 1) * beta + 1) * beta));
            dydq2 = -(1 / (-alpha - beta + 1) * beta * alpha +
                      (1 / (-alpha - beta + 1) * beta + 1) * beta) *
                    (yfp * Math.Pow(p, 1 / (-alpha - beta + 1) * (alpha + beta)) /
                     (Math.Pow(q1, 1 / (-alpha - beta + 1) * (-beta + 1) * alpha +
                                    (1 / (-alpha - beta + 1) * (-beta + 1) - 1) * beta) *
                      Math.Pow(q2, 1 / (-alpha - beta + 1) * beta * alpha +
                                    (1 / (-alpha - beta + 1) * beta + 1) * beta + 1)));
            dx1dq1 = -(1 / (-alpha - beta + 1) * (-beta + 1)) * x1_ch * Math.Pow(p, 1 / (-alpha - beta + 1)) /
                     (Math.Pow(q1, 1 / (-alpha - beta + 1) * (-beta + 1)+1) *
                      Math.Pow(q2, 1 / (-alpha - beta + 1) * beta));
            dx2dq2 = -(1 / (-alpha - beta + 1) * beta + 1) * x2_ch * Math.Pow(p, 1 / (-alpha - beta + 1)) /
                     (Math.Pow(q1, 1 / (-alpha - beta + 1) * (-beta + 1) - 1) *
                      Math.Pow(q2, 1 / (-alpha - beta + 1) * beta + 2));
            dx1dq2 = -(1 / (-alpha - beta + 1) * beta) * x1_ch * Math.Pow(p, 1 / (-alpha - beta + 1)) /
                     (Math.Pow(q1, 1 / (-alpha - beta + 1) * (-beta + 1)) *
                      Math.Pow(q2, 1 / (-alpha - beta + 1) * beta + 1));
            dx2dq1 = -(1 / (-alpha - beta + 1) * (-beta + 1) - 1)* (x2_ch * Math.Pow(p, 1 / (-alpha - beta + 1))) /
                    (Math.Pow(q1, 1 / (-alpha - beta + 1) * (-beta + 1)) *
                     Math.Pow(q2, 1 / (-alpha - beta + 1) * beta + 1));

            e1p = dx1dp * p / x1_ov;
            e1q1 = dx1dq1 * q1 / x1_ov;
            e1q2 = dx1dq2 * q2 / x1_ov;
            e2p = dx2dp * p / x2_ov;
            e2q1 = dx2dq1 * q1 / x2_ov;
            e2q2 = dx2dq2 * q2 / x2_ov;
            eyp = dydp * p / yp;
            eyq1 = dydq1 * q1 / yp;
            eyq2 = dydq2 * q2 / yp;
            

            #endregion
            ansRTB.Clear();
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            #region Пункт 1
            ansRTB.AppendText("1. Определим степень эластичности функции.\r\n");
            ansRTB.AppendText("Сумма коэффициентов эластичности однородной функции равна показателю однородности, в нашем случае\r\n");
            ansRTB.AppendText("    E1 + E2 = k\r\n");
            ansRTB.AppendText("Найдем коэффициенты эластичности заданной производственной функции\r\n");
            ansRTB.AppendText(String.Format("    y = {0}x1^{1} * x2^{2}\r\n", A, alpha, beta));
            E1 = alpha * x1 * Math.Pow(x1, alpha - 1) / Math.Pow(x1, alpha);
            E2 = beta * x2 * Math.Pow(x2, beta - 1) / Math.Pow(x2, beta);
            ansRTB.AppendText(String.Format("    E1 = dy/dx1 * x1/y = {0}\r\n", E1));
            ansRTB.AppendText(String.Format("    E2 = dy/dx2 * x2/y = {0}\r\n", E2));
            k = E1 + E2;
            ansRTB.AppendText(String.Format("    k = {0} + {1} = {2}\r\n", E1, E2, k));
            ansRTB.AppendText(String.Format("Степень однородности данной производственной функции k = {0}\r\n", k));
            #endregion
            #region Пункт 2
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("\r\n2. Найдем функцию издержек C(y).\r\n");
            ansRTB.AppendText("Это функция C(y) = min(z), где z = q1*x1 + q2*x2, т.е. решим задачу:\r\n");
            ansRTB.AppendText(String.Format("    z = q1*x2 + q2*x2 --> min\r\n    y0 = {0}*x1^{1} * x2^{2},\r\n" +
                                            "    x1 >= 0, x2 >= 0\r\n", A, alpha, beta));
            ansRTB.AppendText("Условный экстремум найдем методом множителей Лагранжа.\r\nСоставим функцию Лагранжа:\r\n");
            ansRTB.AppendText(String.Format("    L(x1, x2, λ) = q1*x1 + q2*x2*y0 + λ(y0 - {0}*x1^{1}*x2^{2}\r\n",
                A, alpha, beta));
            ansRTB.AppendText("Необходимым условием экстремума функции нескольких переменных является равенство нулю всех её частных производных\r\n");
            ansRTB.AppendText("    dL/dx1 = 0\r\n    dL/dx2 = 0\r\n    dL/dλ = 0\r\nили\r\n");
            ansRTB.AppendText(String.Format("    dL/dx1 = q1 - {0}*{1}*x1^{2}*x2^{3}*λ = 0\r\n"+
                "    dL/dx2 = q2 - {0}*{3}*x1^{1}*x2^{4}*λ = 0\r\n    dL/dλ = y0 - {0}*x1^{1}*x2^{3}*λ = 0\r\n",
                A, alpha, alpha - 1, beta, beta - 1));
            ansRTB.AppendText("Преобразуем полученную систему уравнений с неизвестными x1, x2, λ\r\n");
            ansRTB.AppendText(String.Format("    q1 = {0}*{1}*x1^{2}*x2^{3}*λ = ({0}*{1}*x1^{1}*x2^{3}*λ)/x1 = " +
                                            "(λ*{1}*y0)/x1\r\n    q2 = {0}*{3}*x1^{1}*x2^{4}*λ = "+
                                            "({0}*{3}*x1^{1}*x2^{3}*λ)/x2 = " +
                                            "(λ*{3}*y0)/x2\r\n    y0 = {0}*x1^{1}*x2^{3}\r\n",
                A, alpha, alpha - 1, beta, beta - 1));
            ansRTB.AppendText("Подставим выражение для x1 и x2 в третье уравнение системы:\r\n");
            ansRTB.AppendText(String.Format("    x1 = λ*({0}*y0)/q1, \r\n    x2 = λ*({1}*y0)/q2, \r\n"+
                "    y0 = {2}*(λ*({0}*y0)/q1)^{0} * (λ*({1}*y0)/q2)^{1}\r\n",
                alpha, beta, A));
            ansRTB.AppendText("Упростив последнее неравенство, получим\r\n");
            ansRTB.AppendText(String.Format("    y0 = {0}*λ^{1}*(y0^{1}*{2}^{2}*{3}^{3})/(q1^{2}*q2^{3})\r\n",
                A, alpha + beta, alpha, beta));
            ansRTB.AppendText("Из данного уравнения найдем λ:\r\n");
            ansRTB.AppendText(String.Format("    λ = (q1^{0}*q2^{1}*y0^{2})/{3}\r\nПодставляем λ в выражения для x1 и x2:\r\n" +
            "    x1 = λ*({4}*y0)/q1 = (q1^{0}*q2^{1}*y0^{2})/{3} * ({4}*y0)/q1\r\n" +
            "    x2 = λ*({5}*y0)/q2 = (q1^{0}*q2^{1}*y0^{2})/{3} * ({5}*y0)/q2\r\n",
                Math.Round(alpha * (1 / (alpha + beta)), R),
                Math.Round(beta * (1 / (alpha + beta)), R),
                Math.Round((1 / (alpha + beta)) - 1, R),
                Math.Round(znam1, R),
                alpha, beta));
            ansRTB.AppendText("Итак, оптимальный набор ресурсов по критерию минимизации издержек, обеспечивающий заданный выпуск продукции y0:\r\n");
            ansRTB.AppendText(String.Format("    x1* = {0}*y0^{1}*q2^{2}/q1^{2}\r\n    x2* = {3}*y0^{1}*q1^{4}/q2^{4}\r\n" +
            "Тогда минимальные затраты:\r\n    z_min = q1 * x1* + q2 * x2* = \r\n" +
            "= q1*{0}*y0^{1}*q2^{2}/q1^{2} + q2*{3}*y0^{1}*q1^{4}/q2^{4} =\r\n= {5}*y0^{1}*q1^{4}*q2^{2}\r\n" +
            "Таким образом, функция издержек производства имеет вид:\r\n" +
            "    C(y) = {5}*y0^{1}*q1^{4}*q2^{2}\r\n",
                Math.Round(alpha / znam1, R),
                Math.Round((1 / (alpha + beta)), R),
                Math.Round(beta * (1 / (alpha + beta)), R),
                Math.Round(beta / znam1, R),
                Math.Round(alpha * (1 / (alpha + beta)), R),
                Math.Round((alpha + beta) / znam1, R)
                ));
            #endregion
            #region Пункт 3. Много тектса, мало формул
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText(String.Format("\r\n3. Найдем предельные производительности ресурсов для заданных значений " +
                                            "x1_0 и x2_0, т.е. в точке X0 = ({0};{1})\r\n", x1, x2));
            ansRTB.AppendText("Предельные производительности 1-го ресурса:\r\n");
            ansRTB.AppendText(String.Format("    dy/dx1 = {0}*{1}*x1^{2}*x2^{3} = {4}*x1^{2}*x2^{3}\r\n",
                A, alpha, alpha - 1, beta, A * alpha));
            ansRTB.AppendText(String.Format("    dy/dx1|X0 = {0}*{1}^{2}*{3}^{4} = {5}\r\n",
                A * alpha, x1, alpha - 1, x2, beta, Math.Round(dydx1x0, R)));
            ansRTB.AppendText(
                String.Format(
                    "На 1 единицу дополнительно использованного ресурса 1-го вида приходится {0} единиц дополнительно выпущенной продукции\r\n",
                    Math.Round(dydx1x0, R)));

            ansRTB.AppendText("Предельные производительности 2-го ресурса:\r\n");
            ansRTB.AppendText(String.Format("    dy/dx2 = {0}*{1}*x1^{2}*x2^{3} = {4}*x1^{2}*x2^{3}\r\n",
                A, beta, alpha, beta - 1, A * beta));
            ansRTB.AppendText(String.Format("    dy/dx2|X0 = {0}*{1}^{2}*{3}^{4} = {5}\r\n",
                A * beta, x1, alpha, x2, beta - 1, Math.Round(dydx2x0, R)));
            ansRTB.AppendText(
                String.Format(
                    "На 1 единицу дополнительно использованного ресурса 2-го вида приходится {0} единиц дополнительно выпущенной продукции\r\n",
                    Math.Round(dydx2x0, R)));
            #endregion
            #region Пункт 4. Копираста пункта 1
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("4. Найдем коэффициенты эластичности выпуска по ресурсам и эластичности от расширения масштабов производства.\r\n");
            ansRTB.AppendText("Коэффициенты эластичности выпуска продукции по 1-му ресурсу:\r\n");
            ansRTB.AppendText(String.Format("    E1 = dy/dx1 * x1/y = {0}\r\n" +
            "При увеличении объема использование ресурса 1-го вида на 1% выпуска продукции увеличивается на {0}%\r\n", E1));
            ansRTB.AppendText("Коэффициенты эластичности выпуска продукции по 2-му ресурсу:\r\n");
            ansRTB.AppendText(String.Format("    E2 = dy/dx2 * x2/y = {0}\r\n" +
            "При увеличении объема использование ресурса 2-го вида на 1% выпуска продукции увеличивается на {0}%\r\n", E2));
            ansRTB.AppendText("Общая эластичность от расширения масштабов производства:\r\n");
            ansRTB.AppendText(String.Format("    E = E1 + E2 = {0} + {1} = {2}", E1, E2, E1 + E2));
            string s =
                "{0}1\r\nТак как E{0}1, то имеет место случай {1} эффективности от расширения масштабов производства. В результате увеличения использования ресурсов каждого вида на 1% в целом выпуск продукции {2} на {3}%\r\n";
            if (E1 + E2 < 1)
            {
                ansRTB.AppendText(String.Format(s, "<", "убывающей", "возрастет", E1 + E2));
            }
            if (E1 + E2 > 1)
            {
                ansRTB.AppendText(String.Format(s, ">", "возрастающей", "уменьшится", E1 + E2));
            }
            if (E1 + E2 == 1)
            {
                //ansRTB.AppendText("=1\r\n Так как E=1, то имеет место случай убывающей эффективности от расширения масштабов производства. В результате увеличения использования ресурсов каждого вида на 1% в целом выпуск продукции возрастает на " + E1 + E2 + "%\r\n");
            }
            #endregion
            #region Пункт 5
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText(String.Format("\r\n5. Найдем предельные нормы замещения ресурсов для заданных значений x1_0 = {0} и x2_0 = {1}\r\n", x1, x2));
            ansRTB.AppendText("Норма замены 1-го ресурса 2-ым:\r\n");
            ansRTB.AppendText(
                String.Format("    n2,1 = -(dy/dx1)/(dy/dx2) = -({0}*{1}*x1^{2}*x2^{3})/({0}*{3}*x1^{1}*x2^{4}) =\r\n" +
                              "= -{5}/{6}*x2/x1 = -{5}/{6}*{7}/{8} = {9}\r\n",
                    A, alpha, alpha - 1, beta, beta - 1, A * alpha, A * beta, x2, x1,
                    Math.Round(n21, R)));
            ansRTB.AppendText(
                String.Format(
                    "Для замены 1 единицы ресурса 1-го вида требуется {0} единиц ресурса 2-го вида, чтобы выпуск продукции остался на прежнем уровне\r\n",
                    Math.Abs(Math.Round(n21, R))));
            ansRTB.AppendText("Норма замены 2-го ресурса 1-ым:\r\n");
            ansRTB.AppendText(
                String.Format("    n1,2 = -(dy/dx2)/(dy/dx1) = -({0}*{1}*x1^{2}*x2^{3})/({0}*{2}*x1^{4}*x2^{1}) =\r\n" +
                              "= -{5}/{6}*x1/x2 = -{5}/{6}*{8}/{7} = {9}\r\n",
                    A, beta, alpha, beta - 1, alpha - 1, A * beta, A * alpha, x2, x1,
                    Math.Round(n12, R)));
            ansRTB.AppendText(
                String.Format(
                    "Чтобы освободить единицу ресурса 2-го вида, при  условии, что выпуск продукции не изменился," +
                    "необходимо дополнительно использовать {0} единиц ресурса 1-го вида", n12));
            #endregion
            #region Пункт 6. Здравствуй, жопа, Новый год
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("6. Найдем оптимальный выбор производителя по критерию максимальной прибыли в условиях " +
                              "совершенной конкуренции при заданных ценах на продукцию и ресурсы:\r\n");
            ansRTB.AppendText(String.Format("    p = {0}, q1 = {1}, q2 = {2}\r\n", p, q1, q2));
            ansRTB.AppendText("Модель оптимального выбора производителя в условиях совершенной конкуренции имеет вид:\r\n");
            ansRTB.AppendText("    П = p * y - sum(q_i, q_j), j=[1,n],\r\n");
            ansRTB.AppendText("где y = f(x1, x2, ..., xn)\tq_j > 0,\tx_j >= 0, j = [1,n]\r\n");
            ansRTB.AppendText("В нашем случае:\r\n    П = p * y - (q1*x1 + q2*x2) --> max, где\r\n");
            ansRTB.AppendText(String.Format("    y = {0}*x1^{1}*x2^{2}, \r\n    q1 > 0, q2 > 0, x1 >= 0, x2 >= 0.\r\n",
                A, alpha, beta));
            ansRTB.AppendText(
                String.Format(
                    "или П = p*{0}*x1^{1}*x2^{2} - q1*x1-q2*x2 --> max, где q1 > 0, q2 > 0, x1 >= 0, x2 >= 0.\r\n", A,
                    alpha, beta));
            ansRTB.AppendText("Необходимым условием экстремума функции нескольких переменных является равенство нулю всех ее частных производных.\r\n");
            ansRTB.AppendText(
                String.Format(
                    "    dП/dx1 = p*{0}*{1}*x1^{2}*x2^{3}-q1 = 0\r\n    dП/dx2 = p*{0}*{3}*x1^{1}*x2^{4}-q2 = 0\r\n" +
                    "Преобразуем полученную систему уравнений с неизвестными x1 и x2.\r\n" +
                    "    q1 = p*{0}*{1}*x1^{2}*x2^{3},\r\n    q2 = p*{0}*{3}*x1^{1}*x2^{4}\r\n" +
                    "Разделим первое уравнение на второе:\r\n" +
                    "    q1/q2 = (p*{0}*{1}*x1^{2}*x2^{3})/(p*{0}*{3}*x1^{1}*x2^{4})\r\n" +
                    "    q1 = p*{0}*{1}*x1^{2}*x2^{3}\r\nравносильно\r\n    x2 = ({3}*x1*q1)/({1}*q2)\r\n" +
                    "    q1 = p*{0}*{1}*x1^{2}*x2^{3}\r\n",
                    A, alpha, alpha - 1, beta, beta - 1));
            ansRTB.AppendText("Подставим x2 во второе уравнение системы:\r\n");
            ansRTB.AppendText(String.Format("    q1 = p*{0}*{1}*x1^{2}*(({3}*x1*q1)/({1}*q2))^{3} =\r\n" +
                                            "= p*{0}*{1}*x1^{2}*({3}^{3}*x1^{3}*q1^{3})/({1}^{3}*q2^{3}) =\r\n" +
                                            "= p*{0}*{1}*x1^{4}*{3}^{3}*{1}^{5}*q1^{3}*q2^{5} =\r\n" +
                                            "= p*{0}*{3}^{3}*{1}^{6}*q1^{3}*q2^{5}*x1^{4}\r\n",
                A, alpha, alpha - 1, beta, alpha - 1 + beta, -beta, -beta + 1));
            ansRTB.AppendText(String.Format("Откуда\r\n    x1^{0} = p*{1}*{2}^{2}*{3}^{4}*q1^{5}*q2^{6}\r\n" +
                                            "    x1 = ((p*{1}*{2}^{2}*{3}^{4})/(q1^{4}*q2^{2}))^(1/{0}) =\r\n",
                -alpha - beta + 1, A, beta, alpha, -beta + 1, beta - 1, -beta));
            ansRTB.AppendText(
                String.Format("= (p^{0}*{1}^{0}*{2}^{3}*{4}^{5})/(q1^{5}*q2^{3}) =\r\n" +
                              "= {6}*p^{0}/(q1^{5}*q2^{3})\r\n" +
                              "Итак, x1* = {6}*p^{0}/(q1^{5}*q2^{3})\r\n",
                    Math.Round(1 / (-alpha - beta + 1), R), A, beta,
                    Math.Round(1 / (-alpha - beta + 1) * beta, R), alpha,
                    Math.Round((1 / (-alpha - beta + 1) * (-beta + 1)), R),
                    Math.Round(x1_ch, R)));
            ansRTB.AppendText(
                String.Format(
                    "Тогда,\r\n    x2* = ({0} * x1* * q1)/({1}*q2) = (({0}*q1)/({1}*q2))*(({2}*p^{3})/(q1^{4}*q2^{5}))" +
                    "= \r\n= ({6}*p^{3})/(q1^{7}*q2^{8})\r\n" +
                    "Функции спроса на ресурсы имеют вид:\r\n" +
                    "    x1* = {2}*p^{3}/(q1^{4}*q2^{5})\r\n    x2* = ({6}*p^{3})/(q1^{7}*q2^{8})\r\n",
                    beta, alpha,
                    Math.Round(x1_ch, R),
                    Math.Round(1 / (-alpha - beta + 1), R),
                    Math.Round((1 / (-alpha - beta + 1) * (-beta + 1)), R),
                    Math.Round(1 / (-alpha - beta + 1) * beta, R),
                    Math.Round(x2_ch, R),
                    Math.Round((1 / (-alpha - beta + 1) * (-beta + 1)) - 1, R),
                    Math.Round(1 / (-alpha - beta + 1) * beta + 1, R)
                ));
            ansRTB.AppendText(
                String.Format("Подставив в эти функции значения q1 = {0}, q2 = {1}, p = {2}, найдем оптимальный " +
                              "выбор производителя по критерию максимизации прибыли в условия совершенной конкуренции:\r\n" +
                              "    x1* = {9}*{2}^{3}/({0}^{4}*{1}^{5}) = {10}\r\n" +
                              "    x2* = ({6}*{2}^{3})/({0}^{7}*{1}^{8}) = {11}\r\n",
                    q1, q2, p, Math.Round(1 / (-alpha - beta + 1), R),
                    Math.Round((1 / (-alpha - beta + 1) * (-beta + 1)), R),
                    Math.Round(1 / (-alpha - beta + 1) * beta, R),
                    Math.Round(x2_ch, R),
                    Math.Round((1 / (-alpha - beta + 1) * (-beta + 1)) - 1, R),
                    Math.Round(1 / (-alpha - beta + 1) * beta + 1, R),
                    Math.Round(x1_ch, R),
                    Math.Round(x1_ov, R),
                    Math.Round(x2_ov, R)));
            ansRTB.AppendText("При этом будет выпущено продукции:\r\n");
            ansRTB.AppendText(String.Format("y* = {0}*(x1*)^{1}*(x2*)^{2} = {0}*{3}^{1}*{4}^{2} = {5}\r\n",
                A, alpha, beta, Math.Round(x1_ov, R),
                Math.Round(x2_ov, R), Math.Round(yp, R)));
            ansRTB.AppendText("и максимальная прибыль составит\r\n");
            ansRTB.AppendText(String.Format("П* = p * y* - q1 * x1* - q2 * x2* = {0}*{1} - {2}*{3} - {4}*{5} = {6}\r\n",
                p, yp, q1, Math.Round(x1_ov, R), q2, Math.Round(x2_ov, R), Math.Round(pesozvezchkoy, R)));
            #endregion
            #region Пункт 7
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("\r\n7. Функции спроса на ресурсы имеют вид:\r\n");
            ansRTB.AppendText(
                String.Format(
                    "x1* = ({2}*p^{3})/(q1^{4}*q2^{5})\r\n" +
                    "x2* = ({6}*p^{3})/(q1^{7}*q2^{8})\r\n",
                    beta, alpha,
                    Math.Round(x1_ch, R),
                    Math.Round(1 / (-alpha - beta + 1), R),
                    Math.Round((1 / (-alpha - beta + 1) * (-beta + 1)), R),
                    Math.Round(1 / (-alpha - beta + 1) * beta, R),
                    Math.Round(x2_ch, R),
                    Math.Round((1 / (-alpha - beta + 1) * (-beta + 1)) - 1, R),
                    Math.Round(1 / (-alpha - beta + 1) * beta + 1, R)
                ));
            ansRTB.AppendText("Функция предложения продукции:\r\n");
            ansRTB.AppendText(
                String.Format(
                    "y = {0}*x1^{1}*x2^{2} = {0}*({3}*p^{4}/(q1^{5}*q2^{6}))^{1}*(({7}*p^{4})/(q1^{8}*q2^{9}))^{2} = \r\n" +
                    "= {10}*p^{11}/q1^{12}*q2^{13}\r\n",
                    A, alpha, beta,
                    Math.Round(x1_ch, R),
                    Math.Round(1 / (-alpha - beta + 1), R),
                    Math.Round((1 / (-alpha - beta + 1) * (-beta + 1)), R),
                    Math.Round(1 / (-alpha - beta + 1) * beta, R),
                    Math.Round(x2_ch, R),
                    Math.Round((1 / (-alpha - beta + 1) * (-beta + 1)) - 1, R),
                    Math.Round(1 / (-alpha - beta + 1) * beta + 1, R),
                    Math.Round(yfp, R),
                    Math.Round(1 / (-alpha - beta + 1) * (alpha + beta), R),
                    Math.Round(
                    ((1 / (-alpha - beta + 1) * (-beta + 1)) * alpha +
                     ((1 / (-alpha - beta + 1) * (-beta + 1)) - 1) * beta), R),
                    Math.Round(
                        (1 / (-alpha - beta + 1) * beta) * alpha + ((1 / (-alpha - beta + 1) * beta + 1) * beta), R)
                ));
            #endregion
            #region Пункт 8. Здравствуй, жопа, мэрцишор
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            #region Реакции на продукцию
            ansRTB.AppendText("\r\n8. Найдем реакцию производителя при изменении цен на продукты и на ресурсы и коэффициенты эластичности при ценах:\r\n");
            ansRTB.AppendText(String.Format("p = {0}, q1 = {1}, q2 = {2}\r\n", p, q1, q2));
            ansRTB.AppendText("Реакция производителя при изменении цен на продукцию.\r\n");
            ansRTB.AppendText(String.Format("dx1* /dp = {0}*{1}*p^({1}-1)/(q1^{2}*q2^{3}) = {4}",
                Math.Round(x1_ch, R),
                Math.Round(1 / (-alpha - beta + 1), R),
                Math.Round((1 / (-alpha - beta + 1) * (-beta + 1)), R),
                Math.Round(1 / (-alpha - beta + 1) * beta, R),
                Math.Round(dx1dp, R)));
            s = "({0}0)\r\nТак как dx1* /dp {0} 0, то при росте цены продукции, спрос на 1-ый фактор производства {1}, то есть этот ресурс (фактор) является {2}.\r\n";
            if (dx1dp > 0)
            {
                ansRTB.AppendText(String.Format(s, ">", "возрастает", "ценным"));
            }
            if (dx1dp < 0)
            {
                ansRTB.AppendText(String.Format(s, "<", "убывает", "неценным"));
            }
            if (dx1dp == 0)
            {
                ansRTB.AppendText(String.Format(s, "=", "не изменяется", "независимым"));
            }
            ansRTB.AppendText(String.Format("dx2* /dp = {0}*{1}*p^({1}-1)/(q1^{2}*q2^{3}) = {4}",
                Math.Round(x2_ch, R),
                Math.Round(1 / (-alpha - beta + 1), R),
                Math.Round((1 / (-alpha - beta + 1) * (-beta + 1)) - 1, R),
                Math.Round(1 / (-alpha - beta + 1) * beta + 1, R),
                Math.Round(dx2dp, R)));
            s = "({0}0)\r\nТак как dx2* /dp {0} 0, то при росте цены продукции, спрос на 2-й фактор производства {1}, то есть этот ресурс (фактор) является {2}.\r\n";
            if (dx2dp > 0)
            {
                ansRTB.AppendText(String.Format(s, ">", "возрастает", "ценным"));
            }
            if (dx2dp < 0)
            {
                ansRTB.AppendText(String.Format(s, "<", "убывает", "неценным"));
            }
            if (dx2dp == 0)
            {
                ansRTB.AppendText(String.Format(s, "=", "не изменяется", "независимым"));
            }
            ansRTB.AppendText(String.Format("dy* /dp = {0}*{1}*p^({1}-1)/q1^{2}*q2^{3} = {4}", Math.Round(yfp, R),
                Math.Round(1 / (-alpha - beta + 1) * (alpha + beta), R),
                Math.Round(
                (1 / (-alpha - beta + 1) * (-beta + 1) * alpha +
                 (1 / (-alpha - beta + 1) * (-beta + 1) - 1) * beta), R),
                Math.Round(
                    (1 / (-alpha - beta + 1) * beta) * alpha + ((1 / (-alpha - beta + 1) * beta + 1) * beta), R),
                Math.Round(dydp, R)));
            s = "({0}0)\r\nПри росте цены продукции объем ее выпуска {1}\r\n";
            if (dydp > 0)
            {
                ansRTB.AppendText(String.Format(s, ">", "увеличивается"));
            }
            if (dydp < 0)
            {
                ansRTB.AppendText(String.Format(s, "<", "уменьшается"));
            }
            if (dydp == 0)
            {
                ansRTB.AppendText(String.Format(s, "=", "не изменяется"));
            }
            #endregion
            #region Реакции на факторы
            ansRTB.AppendText("Реакции производителя при изменении цен на факторы производства.\r\n");
            ansRTB.AppendText(String.Format("dy* /dq1 = ({0}*p^{1}/q1^({2}+1)*q2^{3}) * (-{2}) = {4}", Math.Round(yfp, R),
                Math.Round(1 / (-alpha - beta + 1) * (alpha + beta), R),
                Math.Round(
                (1 / (-alpha - beta + 1) * (-beta + 1) * alpha +
                 (1 / (-alpha - beta + 1) * (-beta + 1) - 1) * beta), R),
                Math.Round((1 / (-alpha - beta + 1) * beta) * alpha + 
                ((1 / (-alpha - beta + 1) * beta + 1) * beta), R),
                Math.Round(dydq1, R)));
            if (dydq1 > 0)
            {
                ansRTB.AppendText("(>0)\r\n");
            }
            if (dydq1 < 0)
            {
                ansRTB.AppendText("(<0)\r\n");
            }
            if (dydq1 == 0)
            {
                ansRTB.AppendText("(=0)\r\n");
            }

            ansRTB.AppendText(String.Format("dy* /dq2 = ({0}*p^{1}/q1^{2}*q2^({3}+1)) * (-{3}) = {4}", Math.Round(yfp, R),
                Math.Round(1 / (-alpha - beta + 1) * (alpha + beta), R),
                Math.Round(
                (1 / (-alpha - beta + 1) * (-beta + 1) * alpha +
                 (1 / (-alpha - beta + 1) * (-beta + 1) - 1) * beta), R),
                Math.Round((1 / (-alpha - beta + 1) * beta) * alpha +
                           ((1 / (-alpha - beta + 1) * beta + 1) * beta), R),
                Math.Round(dydq2, R)));
            if (dydq2 > 0)
            {
                ansRTB.AppendText("(>0)\r\n");
            }
            if (dydq2 < 0)
            {
                ansRTB.AppendText("(<0)\r\n");
            }
            if (dydq2 == 0)
            {
                ansRTB.AppendText("(=0)\r\n");
            }

            ansRTB.AppendText(String.Format("dx1* /dq1 = ({0}*p^{1})/(q1^({2}+1)*q2^{3}) * (-{2}) = {4}\r\n",
                Math.Round(x1_ch, R),
                Math.Round(1 / (-alpha - beta + 1), R),
                Math.Round((1 / (-alpha - beta + 1) * (-beta + 1)), R),
                Math.Round(1 / (-alpha - beta + 1) * beta, R),
                Math.Round(dx1dq1, R)));
            ansRTB.AppendText(String.Format("dx2* / dq2 = ({0}*p^{1})/(q1^{2}*q2^({3}+1)) * (-{3}) = {4}\r\n",
                Math.Round(x2_ch, R),
                Math.Round(1 / (-alpha - beta + 1), R),
                Math.Round(1 / (-alpha - beta + 1) * (-beta + 1) - 1, R),
                Math.Round(1 / (-alpha - beta + 1) * beta + 1, R),
                Math.Round(dx2dq2, R)));
            ansRTB.AppendText(String.Format("dx1* /dq2 = ({0}*p^{1})/(q1^{2}*q2^({3}+1)) * (-{3}) = {4}\r\n",
                Math.Round(x1_ch, R),
                Math.Round(1 / (-alpha - beta + 1), R),
                Math.Round((1 / (-alpha - beta + 1) * (-beta + 1)), R),
                Math.Round(1 / (-alpha - beta + 1) * beta, R),
                Math.Round(dx1dq2, R)));
            ansRTB.AppendText(String.Format("dx2* /dq1 = ({0}*p^{1})/(q1^({2}+1)*q2^{3}) * (-{2}) = {4}\r\n",
                Math.Round(x2_ch, R),
                Math.Round(1 / (-alpha - beta + 1), R),
                Math.Round(1 / (-alpha - beta + 1) * (-beta + 1) - 1, R),
                Math.Round(1 / (-alpha - beta + 1) * beta + 1, R),
                Math.Round(dx2dq1, R)));
            //TODO : Наклепать смысловые строчки

            

            #endregion
            ansRTB.AppendText("Определим коэффициенты эластичности по ценам на продукцию и на ресурсы\r\n");
            #region 1-ый фактор
            ansRTB.AppendText("Для функции спроса на 1-ый фактор производства: \r\n");
            ansRTB.AppendText(String.Format("E1p = (dx1* /dp) / (x1* / p) = (dx1* /dp)*(p / x1*) = {0}*{1}/{2} = {3}\r\n",
                Math.Round(dx1dp, R), p, Math.Round(x1_ov, R), Math.Round(e1p, R)));
            s = "При увеличении цены продукции на 1% спрос на 1-ый фактор производства {0} на {1}%\r\n";
            if (e1p > 0)
            {
                ansRTB.AppendText(String.Format(s, "возрастает", Math.Round(Math.Abs(e1p), R)));
            }
            if (e1p < 0)
            {
                ansRTB.AppendText(String.Format(s, "убывает", Math.Round(Math.Abs(e1p), R)));
            }

            ansRTB.AppendText(
                String.Format("E1q1 = (dx1* /dq1) / (x1* / q1) = (dx1* /dq1)*(q1 / x1*) = {0}*{1}/{2} = {3}\r\n",
                    Math.Round(dx1dq1, R), q1, Math.Round(x1_ov, R), Math.Round(e1q1, R)));
            s = "При увеличении цены 1-го фактора производства на 1% спрос на него {0} на {1}%\r\n";
            if (e1q1 > 0)
            {
                ansRTB.AppendText(String.Format(s, "увеличивается", Math.Round(Math.Abs(e1q1), R)));
            }
            if (e1q1 < 0)
            {
                ansRTB.AppendText(String.Format(s, "уменьшается", Math.Round(Math.Abs(e1q1), R)));
            }

            ansRTB.AppendText(
                String.Format("E1q2 = (dx1* /dq2) / (x1* / q2) = (dx1* /dq2)*(q2 / x1*) = {0}*{1}/{2} = {3}\r\n",
                    Math.Round(dx1dq2, R), q2, Math.Round(x1_ov, R), Math.Round(e1q2, R)));
            s = "При увеличении цены 2-го фактора производства на 1% спрос на 1-ый фактор {0} на {1}%\r\n";
            if (e1q2 > 0)
            {
                ansRTB.AppendText(String.Format(s, "увеличивается", Math.Round(Math.Abs(e1q2), R)));
            }
            if (e1q2 < 0)
            {
                ansRTB.AppendText(String.Format(s, "уменьшается", Math.Round(Math.Abs(e1q2), R)));
            }

            ansRTB.AppendText("Проверим основное свойство коэффициентов эластичности функции спроса на 1-ый " +
                "фактор производства. Эта функция однородная нулеовй степени. Поэтому сумма всех ее коэффициентов " +
                "эластичности равна нулю. Действительно,\r\n");
            ansRTB.AppendText(String.Format("E1p + E1q1 + E1q2 = {0} + {1} + {2} = {3}\r\n",
                Math.Round(e1p, R), Math.Round(e1q1, R), Math.Round(e1q2, R),
                Math.Round(e1p + e1q1 + e1q2, R)));
            #endregion
            #region 2-ый фактор
            ansRTB.AppendText("Для функции спроса на 2-й фактор производства: \r\n");
            ansRTB.AppendText(String.Format("E2p = (dx2* /dp) / (x2* / p) = (dx2* /dp)*(p / x2*) = {0}*{1}/{2} = {3}\r\n",
                Math.Round(dx2dp, R), p, Math.Round(x2_ov, R), Math.Round(e2p, R)));
            s = "При увеличении цены продукции на 1% спрос на 2-й фактор производства {0} на {1}%\r\n";
            if (e2p > 0)
            {
                ansRTB.AppendText(String.Format(s, "возрастает", Math.Round(Math.Abs(e2p), R)));
            }
            if (e2p < 0)
            {
                ansRTB.AppendText(String.Format(s, "убывает", Math.Round(Math.Abs(e2p), R)));
            }

            ansRTB.AppendText(
                String.Format("E2q1 = (dx2* /dq1) / (x2* / q1) = (dx2* /dq1)*(q1 / x2*) = {0}*{1}/{2} = {3}\r\n",
                    Math.Round(dx2dq1, R), q1, Math.Round(x2_ov, R), Math.Round(e2q1, R)));
            s = "При увеличении цены 1-го фактора производства на 1% спрос на 2-й фактор {0} на {1}%\r\n";
            if (e2q1 > 0)
            {
                ansRTB.AppendText(String.Format(s, "увеличивается", Math.Round(Math.Abs(e2q1), R)));
            }
            if (e2q1 < 0)
            {
                ansRTB.AppendText(String.Format(s, "уменьшается", Math.Round(Math.Abs(e2q1), R)));
            }

            ansRTB.AppendText(
                String.Format("E2q2 = (dx2* /dq2) / (x2* / q2) = (dx2* /dq2)*(q2 / x2*) = {0}*{1}/{2} = {3}\r\n",
                    Math.Round(dx2dq2, R), q2, Math.Round(x2_ov, R), Math.Round(e2q2, R)));
            s = "При увеличении цены 2-го фактора производства на 1% спрос на него {0} на {1}%\r\n";
            if (e2q2 > 0)
            {
                ansRTB.AppendText(String.Format(s, "увеличивается", Math.Round(Math.Abs(e2q2), R)));
            }
            if (e2q2 < 0)
            {
                ansRTB.AppendText(String.Format(s, "уменьшается", Math.Round(Math.Abs(e2q2), R)));
            }

            ansRTB.AppendText("Проверим основное свойство коэффициентов эластичности функции спроса на 2-й фактор производства:\r\n");
            ansRTB.AppendText(String.Format("E2p + E2q1 + E2q2 = {0} + {1} + {2} = {3}\r\n",
                Math.Round(e2p, R), Math.Round(e2q1, R), Math.Round(e2q2, R),
                Math.Round(e2p + e2q1 + e2q2, R)));
            #endregion
            #region Предложение продукции
            ansRTB.AppendText("Для функции предложения продукции: \r\n");
            ansRTB.AppendText(String.Format("Eyp = (dy* /dp) / (y* / p) = (dy* /dp)*(p / y*) = {0}*{1}/{2} = {3}\r\n",
                Math.Round(dydp, R), p, Math.Round(yp, R), Math.Round(eyp, R)));
            s = "При увеличении цены продукции на 1% спрос на неё {0} на {1}%\r\n";
            if (eyp > 0)
            {
                ansRTB.AppendText(String.Format(s, "возрастает", Math.Round(Math.Abs(eyp), R)));
            }
            if (eyp < 0)
            {
                ansRTB.AppendText(String.Format(s, "убывает", Math.Round(Math.Abs(eyp), R)));
            }

            ansRTB.AppendText(
                String.Format("Eyq1 = (dy* /dq1) / (y* / q1) = (dy* /dq1)*(q1 / y*) = {0}*{1}/{2} = {3}\r\n",
                    Math.Round(dydq1, R), q1, Math.Round(yp, R), Math.Round(eyq1, R)));
            s = "При увеличении цены 1-го фактора производства на 1% спрос на продукцию {0} на {1}%\r\n";
            if (eyq1 > 0)
            {
                ansRTB.AppendText(String.Format(s, "увеличивается", Math.Round(Math.Abs(eyq1), R)));
            }
            if (eyq1 < 0)
            {
                ansRTB.AppendText(String.Format(s, "уменьшается", Math.Round(Math.Abs(eyq1), R)));
            }

            ansRTB.AppendText(
                String.Format("Eyq2 = (dy* /dq2) / (y* / q2) = (dy* /dq2)*(q2 / y*) = {0}*{1}/{2} = {3}\r\n",
                    Math.Round(dydq2, R), q2, Math.Round(yp, R), Math.Round(eyq2, R)));
            s = "При увеличении цены 2-го фактора производства на 1% спрос на продукцию {0} на {1}%\r\n";
            if (eyq2 > 0)
            {
                ansRTB.AppendText(String.Format(s, "увеличивается", Math.Round(Math.Abs(eyq2), R)));
            }
            if (eyq2 < 0)
            {
                ansRTB.AppendText(String.Format(s, "уменьшается", Math.Round(Math.Abs(eyq2), R)));
            }

            ansRTB.AppendText("Проверим основное свойство коэффициентов эластичности функции предложения продукции:\r\n");
            ansRTB.AppendText(String.Format("Eyp + Eyq1 + Eyq2 = {0} + {1} + {2} = {3}\r\n",
                Math.Round(eyp, R), Math.Round(eyq1, R), Math.Round(eyq2, R),
                Math.Round(eyp + eyq1 + eyq2, R)));
            #endregion
            #endregion
        }
        #region MyRegion



        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Resources.developers,
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void вызовСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тут скоро будет справка");
        }
        private void сохранитьРешениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsChanged = true;
            SaveFileDialog saveFileAs = new SaveFileDialog
            {
                Filter = "RTF файлы (*.rtf)|*.rtf|Текстовые файлы (*.txt)|*.txt",
                //CheckFileExists = false,
                CheckPathExists = true,
                AddExtension = true,
                AutoUpgradeEnabled = true,
                FileName = "Results",
                Title = "Сохранить вычисления в файл (рекомендуется RTF)",
            };
            do
            {
                if (saveFileAs.ShowDialog() == DialogResult.Cancel) break;
                if (saveFileAs.FilterIndex == 1)
                {
                    ansRTB.SaveFile(saveFileAs.FileName, RichTextBoxStreamType.RichText);
                    IsChanged = false;
                }
                else
                {
                    var SaveAsConfirm = MessageBox.Show(
                        "При сохранении форматированного текста в файл TXT форматирование будет утрачено\n" +
                        "Вы действительно хотите сохранить его в текстовый файл?",
                        "Внимание! Обнаружено форматирование текста",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (SaveAsConfirm == DialogResult.No) continue;
                    ansRTB.SaveFile(saveFileAs.FileName, RichTextBoxStreamType.PlainText);
                    IsChanged = false;
                }
                MessageBox.Show("Результат сохранен в файл " + saveFileAs.FileName,
                    "Вычисления сохранены", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            while (IsChanged);
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox8.Text = ansRTB.Text = "";
        }
        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //InitPrint();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                //InitPrint();
                printDocument1.Print();

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void solveBtn_Click(object sender, EventArgs e)
        {
            Solve();
        }
        #endregion
    }
}

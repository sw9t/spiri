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
            double alpha, beta, A, x1, x2, p, q1, q2, E1, E2, k;
            double znam1, dydx1x0, dydx2x0, n21, n12, x1_ch, x2_ch, x1_ov, x2_ov, yp, yfp, pesozvezchkoy;
            int R = (int)roundNUD.Value;
            alpha = Double.Parse(alphaTb.Text);
            beta = Double.Parse(betaTb.Text);
            A = Double.Parse(A_Tb.Text);
            x1 = Double.Parse(x1Tb.Text);
            x2 = Double.Parse(x2Tb.Text);
            p = Double.Parse(pTb.Text);
            q1 = Double.Parse(q1Tb.Text);
            q2 = Double.Parse(q2Tb.Text);
            znam1 = Math.Pow(alpha, alpha * (1 / (alpha + beta))) *
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
            pesozvezchkoy = p * yp - q1 * x1_ov - q2 * x2_ov;
            yfp = A * Math.Pow(x1_ch, alpha) * Math.Pow(x2_ch, beta);


            ansRTB.Clear();
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            #region Пункт 1
            ansRTB.AppendText("1. Определим степень эластичности функции.\r\n");
            ansRTB.AppendText("Сумма коэффициентов эластичности однородной функции равна показателю однородности, в нашем случае\r\n");
            ansRTB.AppendText("E1 + E2 = k\r\n");
            ansRTB.AppendText("Найдем коэффициенты эластичности заданной производственной функции\r\n");
            ansRTB.AppendText(String.Format("y = {0}x1^{1} * x2^{2}\r\n", A, alpha, beta));
            E1 = alpha * x1 * Math.Pow(x1, alpha - 1) / Math.Pow(x1, alpha);
            E2 = beta * x2 * Math.Pow(x2, beta - 1) / Math.Pow(x2, beta);
            ansRTB.AppendText(String.Format("E1 = dy/dx1 * x1/y = {0}\r\n", E1));
            ansRTB.AppendText(String.Format("E2 = dy/dx2 * x2/y = {0}\r\n", E2));
            k = E1 + E2;
            ansRTB.AppendText(String.Format("k = {0} + {1} = {2}\r\n", E1, E2, k));
            ansRTB.AppendText(String.Format("Степень однородности данной производственной функции k = {0}\r\n", k));
            #endregion
            #region Пункт 2
            ansRTB.SelectionFont = new Font(ansRTB.Font, FontStyle.Bold);
            ansRTB.AppendText("\r\n2. Найдем функцию издержек C(y).\r\n");
            ansRTB.AppendText("Это функция C(y) = min(z), где z = q1*x1 + q2*x2, т.е. решим задачу:\r\n");
            ansRTB.AppendText(String.Format("z = q1*x2 + q2*x2 --> min\r\ny0 = {0}*x1^{1} * x2^{2},\r\nx1 >= 0, x2 >= 0\r\n",
                A, alpha, beta));
            ansRTB.AppendText("Условный экстремум найдем методом множителей Лагранжа.\r\nСоставим функцию Лагранжа:\r\n");
            ansRTB.AppendText(String.Format("L(x1, x2, λ) = q1*x1 + q2*x2*y0 + λ(y0 - {0}*x1^{1}*x2^{2}\r\n",
                A, alpha, beta));
            ansRTB.AppendText("Необходимым условием экстремума функции нескольких переменных является равенство нулю всех её частных производных\r\n");
            ansRTB.AppendText("dL/dx1 = 0\r\ndL/dx2 = 0\r\ndL/dλ = 0\r\nили\r\n");
            ansRTB.AppendText(String.Format("dL/dx1 = q1 - {0}*{1}*x1^{2}*x2^{3}*λ = 0\r\ndL/dx2 = q2 - {0}*{3}*x1^{1}*x2^{4}*λ = 0\r\ndL/dλ = y0 - {0}*x1^{1}*x2^{3}*λ = 0\r\n",
                A, alpha, alpha - 1, beta, beta - 1));
            ansRTB.AppendText("Преобразуем полученную систему уравнений с неизвестными x1, x2, λ\r\n");
            ansRTB.AppendText(String.Format("q1 = {0}*{1}*x1^{2}*x2^{3}*λ = ({0}*{1}*x1^{1}*x2^{3}*λ)/x1 = (λ*{1}*y0)/x1\r\nq2 = {0}*{3}*x1^{1}*x2^{4}*λ = ({0}*{3}*x1^{1}*x2^{3}*λ)/x2 = (λ*{3}*y0)/x2\r\ny0 = {0}*x1^{1}*x2^{3}\r\n",
                A, alpha, alpha - 1, beta, beta - 1));
            ansRTB.AppendText("Подставим выражение для x1 и x2 в третье уравнение системы:\r\n");
            ansRTB.AppendText(String.Format("x1 = λ*({0}*y0)/q1, \r\nx2 = λ*({1}*y0)/q2, \r\ny0 = {2}*(λ*({0}*y0)/q1)^{0} * (λ*({1}*y0)/q2)^{1}\r\n",
                alpha, beta, A));
            ansRTB.AppendText("Упростив последнее неравенство, получим\r\n");
            ansRTB.AppendText(String.Format("y0 = {0}*λ^{1}*(y0^{1}*{2}^{2}*{3}^{3})/(q1^{2}*q2^{3})\r\n",
                A, alpha + beta, alpha, beta));
            ansRTB.AppendText("Из данного уравнения найдем λ:\r\n");
            ansRTB.AppendText(String.Format("λ = (q1^{0}*q2^{1}*y0^{2})/{3}\r\nПодставляем λ в выражения для x1 и x2:\r\n" +
            "x1 = λ*({4}*y0)/q1 = (q1^{0}*q2^{1}*y0^{2})/{3} * ({4}*y0)/q1\r\n" +
            "x2 = λ*({5}*y0)/q2 = (q1^{0}*q2^{1}*y0^{2})/{3} * ({5}*y0)/q2\r\n",
                Math.Round(alpha * (1 / (alpha + beta)), R),
                Math.Round(beta * (1 / (alpha + beta)), R),
                Math.Round((1 / (alpha + beta)) - 1, R),
                Math.Round(znam1, R),
                alpha, beta));
            ansRTB.AppendText("Итак, оптимальный набор ресурсов по критерию минимизации издержек, обеспечивающий заданный выпуск продукции y0:\r\n");
            ansRTB.AppendText(String.Format("x1* = {0}*y0^{1}*q2^{2}/q1^{2}\r\nx2* = {3}*y0^{1}*q1^{4}/q2^{4}\r\n" +
            "Тогда минимальные затраты:\r\nz_min = q1 * x1* + q2 * x2* = \r\n" +
            "= q1*{0}*y0^{1}*q2^{2}/q1^{2} + q2*{3}*y0^{1}*q1^{4}/q2^{4} =\r\n= {5}*y0^{1}*q1^{4}*q2^{2}\r\n" +
            "Таким образом, функция издержек производства имеет вид:\r\n" +
            "C(y) = {5}*y0^{1}*q1^{4}*q2^{2}\r\n",
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
            ansRTB.AppendText(String.Format("\r\nНайдем предельные производительности ресурсов для заданных значений " +
                                            "x1_0 и x2_0, т.е. в точке X0 = ({0};{1})\r\n", x1, x2));
            ansRTB.AppendText("Предельные производительности 1-го ресурса:\r\n");
            ansRTB.AppendText(String.Format("dy/dx1 = {0}*{1}*x1^{2}*x2^{3} = {4}*x1^{2}*x2^{3}\r\n",
                A, alpha, alpha - 1, beta, A * alpha));
            ansRTB.AppendText(String.Format("dy/dx1|X0 = {0}*{1}^{2}*{3}^{4} = {5}\r\n",
                A * alpha, x1, alpha - 1, x2, beta, Math.Round(dydx1x0, R)));
            ansRTB.AppendText(
                String.Format(
                    "На 1 единицу дополнительно использованного ресурса 1-го вида приходится {0} единиц дополнительно выпущенной продукции\r\n",
                    Math.Round(dydx1x0, R)));

            ansRTB.AppendText("Предельные производительности 2-го ресурса:\r\n");
            ansRTB.AppendText(String.Format("dy/dx2 = {0}*{1}*x1^{2}*x2^{3} = {4}*x1^{2}*x2^{3}\r\n",
                A, beta, alpha, beta - 1, A * beta));
            ansRTB.AppendText(String.Format("dy/dx2|X0 = {0}*{1}^{2}*{3}^{4} = {5}\r\n",
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
            ansRTB.AppendText(String.Format("E1 = dy/dx1 * x1/y = {0}\r\n" +
            "При увеличении объема использование ресурса 1-го вида на 1% выпуска продукции увеличивается на {0}%\r\n", E1));
            ansRTB.AppendText("Коэффициенты эластичности выпуска продукции по 2-му ресурсу:\r\n");
            ansRTB.AppendText(String.Format("E2 = dy/dx2 * x2/y = {0}\r\n" +
            "При увеличении объема использование ресурса 2-го вида на 1% выпуска продукции увеличивается на {0}%\r\n", E2));
            ansRTB.AppendText("Общая эластичность от расширения масштабов производства:\r\n");
            ansRTB.AppendText(String.Format("E = E1 + E2 = {0} + {1} = {2}", E1, E2, E1 + E2));
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
                String.Format("n2,1 = -(dy/dx1)/(dy/dx2) = -({0}*{1}*x1^{2}*x2^{3})/({0}*{3}*x1^{1}*x2^{4}) =\r\n" +
                              "= -{5}/{6}*x2/x1 = -{5}/{6}*{7}/{8} = {9}\r\n", 
                              A, alpha, alpha - 1, beta, beta - 1, A * alpha, A * beta, x2, x1, 
                    Math.Round(n21, R)));
            ansRTB.AppendText(
                String.Format(
                    "Для замены 1 единицы ресурса 1-го вида требуется {0} единиц ресурса 2-го вида, чтобы выпуск продукции остался на прежнем уровне\r\n",
                    Math.Abs(Math.Round(n21, R))));
            ansRTB.AppendText("Норма замены 2-го ресурса 1-ым:\r\n");
            ansRTB.AppendText(
                String.Format("n1,2 = -(dy/dx2)/(dy/dx1) = -({0}*{1}*x1^{2}*x2^{3})/({0}*{2}*x1^{4}*x2^{1}) =\r\n" +
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
            ansRTB.AppendText(String.Format("p = {0}, q1 = {1}, q2 = {2}\r\n", p, q1, q2));
            ansRTB.AppendText("Модель оптимального выбора производителя в условиях совершенной конкуренции имеет вид:\r\n");
            ansRTB.AppendText("П = p * y - sum(q_i, q_j), j=[1,n],\r\n");
            ansRTB.AppendText("где y = f(x1, x2, ..., xn)\tq_j > 0,\tx_j >= 0, j = [1,n]\r\n");
            ansRTB.AppendText("В нашем случае:\r\nП = p * y - (q1*x1 + q2*x2) --> max, где\r\n");
            ansRTB.AppendText(String.Format("y = {0}*x1^{1}*x2^{2}, \r\nq1 > 0, q2 > 0, x1 >= 0, x2 >= 0.\r\n", A, alpha,
                beta));
            ansRTB.AppendText(
                String.Format(
                    "или П = p*{0}*x1^{1}*x2^{2} - q1*x1-q2*x2 --> max, где q1 > 0, q2 > 0, x1 >= 0, x2 >= 0.\r\n", A,
                    alpha, beta));
            ansRTB.AppendText("Необходимым условием экстремума функции нескольких переменных является равенство нулю всех ее частных производных.\r\n");
            ansRTB.AppendText(
                String.Format("dП/dx1 = p*{0}*{1}*x1^{2}*x2^{3}-q1 = 0\r\ndП/dx2 = p*{0}*{3}*x1^{1}*x2^{4}-q2 = 0\r\n" +
                              "Преобразуем полученную систему уравнений с неизвестными x1 и x2.\r\n" +
                              "q1 = p*{0}*{1}*x1^{2}*x2^{3},\r\nq2 = p*{0}*{3}*x1^{1}*x2^{4}\r\n" +
                              "Разделим первое уравнение на второе:\r\n" +
                              "q1/q2 = (p*{0}*{1}*x1^{2}*x2^{3})/(p*{0}*{3}*x1^{1}*x2^{4})\r\n" +
                              "q1 = p*{0}*{1}*x1^{2}*x2^{3}\r\nравносильно\r\nx2 = ({3}*x1*q1)/({1}*q2)\r\nq1 = p*{0}*{1}*x1^{2}*x2^{3}\r\n",
                    A, alpha, alpha - 1, beta, beta - 1));
            ansRTB.AppendText("Подставим x2 во второе уравнение системы:\r\n");
            ansRTB.AppendText(String.Format("q1 = p*{0}*{1}*x1^{2}*(({3}*x1*q1)/({1}*q2))^{3} =\r\n" +
                                            "= p*{0}*{1}*x1^{2}*({3}^{3}*x1^{3}*q1^{3})/({1}^{3}*q2^{3}) =\r\n" +
                                            "= p*{0}*{1}*x1^{4}*{3}^{3}*{1}^{5}*q1^{3}*q2^{5} =\r\n" +
                                            "= p*{0}*{3}^{3}*{1}^{6}*q1^{3}*q2^{5}*x1^{4}\r\n",
                A, alpha, alpha - 1, beta, alpha - 1 + beta, -beta, -beta + 1));
            ansRTB.AppendText(String.Format("Откуда\r\nx1^{0} = p*{1}*{2}^{2}*{3}^{4}*q1^{5}*q2^{6}\r\n" +
                                            "x1 = ((p*{1}*{2}^{2}*{3}^{4})/(q1^{4}*q2^{2}))^(1/{0}) =\r\n",
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
                    "Тогда,\r\nx2* = ({0} * x1* * q1)/({1}*q2) = (({0}*q1)/({1}*q2))*(({2}*p^{3})/(q1^{4}*q2^{5})) = \r\n" +
                    "= ({6}*p^{3})/(q1^{7}*q2^{8})\r\n" +
                    "Функции спроса на ресурсы имеют вид:\r\n" +
                    "x1* = {2}*p^{3}/(q1^{4}*q2^{5})\r\n" +
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
            ansRTB.AppendText(
                String.Format("Подставив в эти функции значения q1 = {0}, q2 = {1}, p = {2}, найдем оптимальный " +
                              "выбор производителя по критерию максимизации прибыли в условия совершенной конкуренции:\r\n" +
                              "x1* = {9}*{2}^{3}/({0}^{4}*{1}^{5}) = {10}\r\n" +
                              "x2* = ({6}*{2}^{3})/({0}^{7}*{1}^{8}) = {11}\r\n",
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
                    "x1* = {2}*p^{3}/(q1^{4}*q2^{5})\r\n" +
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



            #endregion



            ansRTB.AppendText("");
            ansRTB.AppendText("");
            ansRTB.AppendText("");
            ansRTB.AppendText("");
            ansRTB.AppendText("");
            ansRTB.AppendText("");
            ansRTB.AppendText("");
            ansRTB.AppendText("");
            ansRTB.AppendText("");
            ansRTB.AppendText("");
            ansRTB.AppendText("");
            ansRTB.AppendText("");
            ansRTB.AppendText("");
            ansRTB.AppendText("");
            ansRTB.AppendText("");

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

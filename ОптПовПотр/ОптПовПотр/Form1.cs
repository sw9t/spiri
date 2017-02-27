using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public double umax(double x1, double x2, double x3,double a,double b,double c)
        {
            return (a * x1 * x2 + b * x1 * x3 + c * x2 * x3);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            double n12,n21,n13,n31,n23,n32,dudx1,dudx2,dudx3, umaxx, alpha, betta, gamma, n, p1, p2, p3, m,x1,x2,x3,lambda;
            double znam,dx1dm, dx2dm, dx3dm, dx1dp1, dx2dp1, dx3dp1, dx1dp2, dx2dp2, dx3dp2, dx1dp3, dx2dp3, dx3dp3;
            double e1m, e11p, e12p, e13p, e2m, e21p, e22p, e23p, e3m, e31p, e32p, e33p;
            p1 = int.Parse(textBox1.Text) + int.Parse(textBox7.Text);
            p2 = int.Parse(textBox2.Text) + int.Parse(textBox7.Text);
            p3 = int.Parse(textBox3.Text) + int.Parse(textBox7.Text);
            alpha = int.Parse(textBox4.Text);
            betta = int.Parse(textBox5.Text);
            gamma = int.Parse(textBox6.Text);
            n = int.Parse(textBox7.Text);
            m = int.Parse(textBox8.Text);
            //оптимильный набор благ (аналитически- это функция спроса потребителя)
            x1=-(m*alpha*gamma*p3-m*gamma*gamma*p1+m*betta*gamma*p2)/(alpha*alpha*p3*p3-2*alpha*betta*p2*p3-2*alpha*gamma*p1*p3+betta*betta*p2*p2-2*betta*gamma*p1*p2+gamma*gamma*p1*p1);
            x2=-(m*alpha*betta*p3-m*betta*betta*p2+m*betta*gamma*p1)/(alpha*alpha*p3*p3-2*alpha*betta*p2*p3-2*alpha*gamma*p1*p3+betta*betta*p2*p2-2*betta*gamma*p1*p2+gamma*gamma*p1*p1);
            x3=-(m*alpha*betta*p2-m*alpha*alpha*p3+m*alpha*gamma*p1)/(alpha*alpha*p3*p3-2*alpha*betta*p2*p3-2*alpha*gamma*p1*p3+betta*betta*p2*p2-2*betta*gamma*p1*p2+gamma*gamma*p1*p1);
            umaxx = umax(x1, x2, x3, alpha, betta, gamma);
            lambda=-(2*m*alpha*betta*gamma)/(alpha*alpha*p3*p3-2*alpha*betta*p2*p3-2*alpha*gamma*p1*p3+betta*betta*p2*p2-2*betta*gamma*p1*p2+gamma*gamma*p1*p1);
            
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
            dx1dp1=-(m*gamma*gamma*(alpha*alpha*p3*p3+6*alpha*betta*p2*p3-2*alpha*gamma*p1*p3+betta*betta*p2*p2-2*betta*gamma*p1*p2+gamma*gamma*p1*p1))/(znam*znam);
            dx2dp1=(m*betta*gamma*(2*alpha*betta*p2*p3-3*alpha*alpha*p3*p3+2*alpha*gamma*p1*p3+betta*betta*p2*p2-2*betta*gamma*p1*p2+gamma*gamma*p1*p1))/(znam*znam);
            dx3dp1 = (m * alpha * gamma * (alpha * alpha * p3 * p3 + 2 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 - 3 * betta * betta * p2 * p2 + 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1)) / (znam * znam);
            //реакция потребителей при изменении цены на 2-е благо
            dx1dp2 = (m * betta * gamma * (2 * alpha * betta * p2 * p3 - 3 * alpha * alpha * p3 * p3 + 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 - 2 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1)) / (znam * znam);
            dx2dp2 =-(m*betta*betta*(alpha*alpha*p3*p3-2*alpha*betta*p2*p3+6*alpha*gamma*p1*p3+betta*betta*p2*p2-2*betta*gamma*p1*p2+gamma*gamma*p1*p1))/(znam*znam);
            dx3dp2 = (m * alpha * betta * (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 + 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 + 2 * betta * gamma * p1 * p2 - 3 * gamma * gamma * p1 * p1)) / (znam * znam);
            //реакция потребителей при изменении цены на 3-е благо
            dx1dp3 =(m*alpha*gamma*(alpha*alpha*p3*p3+2*alpha*betta*p2*p3-2*alpha*gamma*p1*p3-3*betta*betta*p2*p2+2*betta*gamma*p1*p2+gamma*gamma*p1*p1))/(znam*znam);
            dx2dp3 =(m * alpha * betta * (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 + 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 + 2 * betta * gamma * p1 * p2 - 3 * gamma * gamma * p1 * p1)) / (znam * znam);
            dx3dp3 = -(m * alpha * alpha * (alpha * alpha * p3 * p3 - 2 * alpha * betta * p2 * p3 - 2 * alpha * gamma * p1 * p3 + betta * betta * p2 * p2 + 6 * betta * gamma * p1 * p2 + gamma * gamma * p1 * p1)) / (znam * znam);
           //коэффициенты эластичности для блага 1
            e1m = dx1dm*m / x1;
            e11p = dx1dp1 * p1 / x1;
            e12p = dx2dp1 * p2 / x1;
            e13p = dx3dp1 * p3 / x1 ;

            e2m = dx2dm * m / x2;
            e21p = dx1dp2 * p1 / x2;
            e22p = dx2dp2 * p2 / x2;
            e23p = dx3dp2 * p3 / x2;

            e3m = dx3dm * m / x3;
            e31p = dx1dp3 * p1 / x3;
            e32p = dx2dp3 * p2 / x3;
            e33p = dx3dp3 * p3 / x3;


            label1.Text = string.Format("{0} \n{1} \n{2} \n{3} \n{4} \n{5} \n{6} \n{7} \n{8} \n{9} \n{10} \n{11} \n{12} \n{13}", x1, x2, x3, lambda, umaxx, dudx1, dudx2, dudx3, n12, n21, n13, n31, n23, n32);
            label10.Text = string.Format("{0} \n{1} \n{2} \n{3} \n{4} \n{5} \n{6} \n{7} \n{8} \n{9} \n{10} \n{11}", dx1dm, dx2dm, dx3dm, dx1dp1, dx2dp1, dx3dp1, dx1dp2, dx2dp2, dx3dp2, dx1dp3, dx2dp3, dx3dp3);
            label11.Text = string.Format("{0} \n{1} \n{2} \n{3} \n{4} \n{5} \n{6} \n{7} \n{8} \n{9} \n{10} \n{11}", e1m, e11p, e12p, e13p, e2m, e21p, e22p, e23p, e3m, e31p, e32p, e33p);
        }
    }
}

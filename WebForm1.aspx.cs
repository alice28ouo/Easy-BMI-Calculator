using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BMI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Person pp = new Person();
            pp.Height = Double.Parse(TextBox1.Text);
            pp.Weight = Double.Parse(TextBox2.Text);


            if (DropDownList1.SelectedValue == "cm")
            {
                pp.Height = pp.Height / 100;
            }
            else if (DropDownList1.SelectedValue == "in")
            {
                pp.Height *= 0.0254;
            }
            if (DropDownList2.SelectedValue == "kg")
            {
                pp.Weight = pp.Weight;
            }
            else if (DropDownList2.SelectedValue == "lb")
            {
                pp.Weight *= 0.45359237;
            }
            

            Label1.Text = pp.CalBMI().ToString()+"<br>";


            if (pp.CalBMI() < 18.5)
            {
                Label1.Text += "體重過輕";
            }
            else if(pp.CalBMI() >= 18.5 && pp.CalBMI() <= 24.9)
            {
                Label1.Text += "正常體重";
            }
            else if (pp.CalBMI() >= 25 && pp.CalBMI() <= 29.9)
            {
                Label1.Text += "體重過重";
            }
            else
            {
                Label1.Text += "肥胖";
            }

        }
    }
}
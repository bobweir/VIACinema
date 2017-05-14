using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Payement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 1; i < 13; i++)
        {
            if (i < 10)
            {
                DropDownList1.Items.Add("0" + i);
            }
            else
            {
                DropDownList1.Items.Add(i + "");
            }
        }
        for (int i = 0; i < 100; i++)
        {
            if (i < 10)
            {
                DropDownList2.Items.Add("0" + i);
            }
            else
            {
                DropDownList2.Items.Add(i + "");
            }
        }
        DropDownList3.Items.Add("MASTERCARD");
        DropDownList3.Items.Add("VISA");
        DropDownList3.Items.Add("AMEX");
        DropDownList3.Items.Add("DINERS");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        com.ftipgw.secure.CreditCardValidator checker = new com.ftipgw.secure.CreditCardValidator();
        string cdNum = TextBox1.Text;
        string cdType = DropDownList3.SelectedItem.Text;
        int cdMonth = 0; 
        Int32.TryParse(DropDownList1.SelectedItem.Text, out cdMonth);
        int cdYear = 0;
        Int32.TryParse(DropDownList2.SelectedItem.Text, out cdYear);
        
        int curYear = DateTime.Now.Year - 2000;
        int curMonth = DateTime.Now.Month;
        string curNum = checker.GetCardType(cdNum);
        bool validNum = checker.ValidMod10(cdNum);

        if ( curNum == cdType && validNum == true && (cdYear == curYear && cdMonth >= curMonth) || cdYear > curYear)
        {
            HttpContext.Current.Response.Write("Good"); //To Change -> Validate and all

        }else
        {
            HttpContext.Current.Response.Write("No Good"); //To change
        }
    }
}
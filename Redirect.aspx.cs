using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Redirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String message = "Your payement was accepted, your seat number is " + Session["Seat"] + " you will receive your ticket by mail";
        HttpContext.Current.Response.Write(message);

        //string smtpAddress = "smtp.gmail.com"; //If you want to send from an hotmail account, use: smtp.live.com
        //int portNumber = 587;
        //bool enableSSL = true;

        //string emailFrom = "jens.svartsjo@gmail.com"; // Use this instead if you want to send from your own email: TextBox1.Text
        //string password = "ichangeditfordnp"; //You have to put in your real password, yes - that is my real password.
        //string emailTo = "jens_svartsjo@msn.com"; // What email you want to send to.
        //string subject = "Movie Tickets";
        //string body = "Here is your ticket for seat number " + Session["Seat"];

        //using (MailMessage mail = new MailMessage())
        //{
        //    mail.From = new MailAddress(emailFrom);
        //    mail.To.Add(emailTo);
        //    mail.Subject = subject;
        //    mail.Body = body;
        //    mail.IsBodyHtml = false;
        //    // Can set to false, if you are sending pure text.

        //    //mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
        //    //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

        //    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
        //    {
        //        smtp.Credentials = new NetworkCredential(emailFrom, password);
        //        smtp.EnableSsl = enableSSL;
        //        smtp.Send(mail);
        //    }
        //}


    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Home.aspx");
    } 
}
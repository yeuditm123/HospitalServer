using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;


namespace Bl
{
    public class SendMailBL
    {
        public static void ConfirmSendMail(string mailTo, string subject, string messege)
        {
           
            //יצירת אוביקט עבור שליחת המייל
            MailMessage msg = new MailMessage();
            //הכתובת ממנה ישלח המייל - מומלץ אותם נתונים שיצרת בגמייל
            msg.From = new MailAddress("medicalservicerating@gmail.com", "MSR MSR");
            // למי לשלוח -ניתן להוסיף עוד 
            msg.To.Add(mailTo);
     
            // נושא המייל
            msg.Subject = subject;
            // ברירת מחדל תוכן טקסט פשוט HTML עדכון סוג התוכן 
            msg.IsBodyHtml = true;
            // Body, Html ניתן לשרשר ערכים. אין צורך להוסיף תגיות HTMLתוכן המייל 
            StringBuilder htmlBody = new StringBuilder("<div style='font-size:16px; color:black;'>.חוות דעתך נבדקה על ידי מנהלי האתר והוחלט להסירה עקב תוכן שאינו ראוי!מאחלים לך בריאות איתנה וכל טוב" + messege + " </div>");
            // HTML יצירת מעטפת לקוד 
            var htmlView = AlternateView.CreateAlternateViewFromString(htmlBody.ToString(), new ContentType("text/html"));
            //עדכון עבור זיהוי תוכן בעברית ה- 
            htmlView.ContentType.CharSet = Encoding.UTF8.WebName;
            //נעדכן את התוכן של ההודעה 
            msg.AlternateViews.Add(htmlView);
            // (ערכים קבועים אין צורך לשנות) Gmail יצירת אוביקט לשרת שליחת המייל של.
            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            //פרטי החשבון שיצרת, הכתובת והסיסמא
            smtp.Credentials = new NetworkCredential("medicalservicerating@gmail.com","nfeogyurnxupawfi");
            smtp.EnableSsl = true;
            smtp.Timeout = int.MaxValue;
            //הפונקציה ששולחת בפועל את המייל 
            smtp.Send(msg);
        }
    }
}
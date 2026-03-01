using UnityEngine;
using System;
using System.Net;
using System.Net.Mail;

public class SimpleEmailSender : MonoBehaviour {

    public StringEmail stringEmail;

    public bool SendEmail(float timeFinal)
    {
        string fromEmail = "nataliamartincoronado@gmail.com";
        string password = "vcfz oulx ovud jvyk";
        string toEmail = stringEmail.GetEmail();

        if (string.IsNullOrEmpty(toEmail))
        {
            Debug.Log("El correo está vacío.");
            return false;
        }

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(fromEmail);
        mail.To.Add(toEmail);
        mail.Subject = "Resultado del juego";
        mail.Body = "¡Felicidades!\n\nTu tiempo final fue: "
                    + timeFinal.ToString("F2") +
                    " segundos.";



        SmtpClient smtp = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromEmail, password),
            EnableSsl = true
        };

        try
        {
            smtp.Send(mail);
            Debug.Log("Email sended succesfuly");
            return true;

        }
        catch (Exception ex)
        {
            Debug.Log("Error: " + ex.Message);
            return false;
        }
    }
}
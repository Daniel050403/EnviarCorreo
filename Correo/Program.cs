using System;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;

namespace Correo
{
    internal class Program
    {
        static void Main()
        {
            Random random = new Random();
            int num = random.Next(1000, 9999);
            string codigo = num.ToString();
            string cuerpo = @"<style>h1{color:dodgerblue;}h2{color:darkorange;}</style><h3>Este es el código de verificación: " + codigo + "</h3>";
        
            SmtpClient smtpClient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("Tucorreo", "Tucontraseña"),
                EnableSsl = true,
            };

            // Crea un mensaje de correo electrónico
            MailMessage message = new MailMessage
            {
                From = new MailAddress("Tucorreo"),
                Subject = "Secundaria",
                Body = cuerpo,
                IsBodyHtml = true, // Cambia a true si el contenido es HTML
            };

            // Agrega destinatarios
            message.To.Add("destinatario");

            // Envía el correo electrónico
            try
            {
                smtpClient.Send(message);
                Console.WriteLine("Correo electrónico enviado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo electrónico: " + ex.Message);
            }
        }
    }
}

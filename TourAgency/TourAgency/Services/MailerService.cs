using System.Net;
using System.Net.Mail;
using System.Text;
using TourAgency.Models;

namespace TourAgency.Services;

public class MailerService
{
    private readonly string senderEmail = "optiflow.dz@gmail.com";
    private readonly string appPassword = "";

    public void SendBookingConfirmation(string recipientEmail, Booking booking)
    {
        var subject = "Your Booking Confirmation - Tour Agency";
        var body = BuildEmailBody(booking);

        using var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(senderEmail, appPassword)
        };

        var mail = new MailMessage(senderEmail, recipientEmail, subject, body)
        {
            IsBodyHtml = true
        };

        client.Send(mail);
    }

    private string BuildEmailBody(Booking booking)
    {
        var sb = new StringBuilder();
        sb.Append($"<h2>Thank you for your booking!</h2>");
        sb.Append($"<p><strong>Booking ID:</strong> {booking.Id}</p>");
        sb.Append($"<p><strong>Date:</strong> {booking.BookingDate:yyyy-MM-dd}</p>");
        sb.Append($"<p><strong>Email:</strong> {booking.UserEmail}</p>");
        sb.Append("<ul>");
        foreach (var item in booking.Items)
        {
            sb.Append($"<li><strong>Type:</strong> {item.Type} | <strong>Ref ID:</strong> {item.EntityBookingId}</li>");
        }
        sb.Append("</ul>");
        sb.Append("<p>We hope you enjoy your trip!</p>");
        return sb.ToString();
    }
}

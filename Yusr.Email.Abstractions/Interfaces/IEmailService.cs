using Yusr.Email.Abstractions.Primitives;

namespace Yusr.Email.Abstractions.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailMessage emailMessage);
    }
}
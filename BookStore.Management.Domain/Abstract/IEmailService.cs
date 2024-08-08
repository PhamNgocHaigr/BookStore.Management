using BookStore.Management.Domain.Setting;

namespace BookStore.Management.Infrastructure.Services
{
    public interface IEmailService
    {
        Task<bool> Send(EmailSetting emailSetting);
    }
}
using System.Threading.Tasks;

namespace EventCode.Services.Interfaces
{
    public interface IEmailService
    {
        public Task Send(string from, string subject, string message);
    }
}

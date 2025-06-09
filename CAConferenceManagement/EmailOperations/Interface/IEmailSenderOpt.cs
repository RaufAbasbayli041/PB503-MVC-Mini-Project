namespace CAConferenceManagement.EmailOperations.Interface
{
    public interface IEmailSenderOpt
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}


namespace Assesment.Domain
{
    public interface IUserEvent
    {
        string User {get;set;}
    }

    public class UserEvent : IUserEvent
    {
        public string User { get; set; }
    }
}
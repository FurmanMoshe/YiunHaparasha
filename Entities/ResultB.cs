
namespace YiunHa
{
    public class ResultB
    {
        public ResultB(UserDto user, bool canChangeFoodChain)
        {
            this.User = user;
            this.CanChangeFoodChain = canChangeFoodChain;
        }

        public UserDto User { get; set; }
        public bool CanChangeFoodChain { get; set; }

    }
}

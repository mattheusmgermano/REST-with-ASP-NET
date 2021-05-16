using REST_with_ASP_NET.Data.VO;
using REST_with_ASP_NET.Model;

namespace REST_with_ASP_NET.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string username);
        bool RevokeToken(string username);
        User RefreshUserInfo(User user);
    }
}

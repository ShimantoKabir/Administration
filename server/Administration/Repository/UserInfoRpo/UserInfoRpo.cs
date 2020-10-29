using System.Collections.Generic;
using System.Threading.Tasks;
using Administration.Models;

namespace Administration.Repository.UserInfoRpo
{
    public interface UserInfoRpo
    {

        Response getUserInfos();

        Response getUserInfoById(int id);

        Response createUserInfo(Request request);

    }
}
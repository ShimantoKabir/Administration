using Administration.Models;

namespace Administration.Repository.MenuRpo
{
    public interface MenuRpo
    {

        Response create(Request request);
        Response read();

    }
}
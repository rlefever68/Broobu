using Wulka.Domain;
using Wulka.Domain.Authentication;

namespace Broobu.Authentication.UI.Controls
{
    public interface ILoginWindow
    {
        AuthRequest Request { get; set; }
        bool? ShowDialog();
    }
}

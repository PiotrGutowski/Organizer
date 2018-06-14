using System.Threading.Tasks;

namespace Organizer.UI.ViewModel
{
    public interface IFriendDetailViewModel
    {
        Task LoadAsync(int friendId);
        bool HasChanges { get;  }
    }
}
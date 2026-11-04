using CommunityToolkit.Mvvm.Input;
using LicznikJS4f.Models;

namespace LicznikJS4f.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}
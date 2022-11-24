using CommonLibrary.Logging;
using Microsoft.AspNetCore.Components;

namespace RadarClient.Pages;

public partial class FetchLogs : ComponentBase, IDisposable
{
    private List<LogHandle>? _handles;

    private List<LogMessage>? _messages;
    private System.Threading.Timer _timer;

    public async Task GetData()
    {
        Console.WriteLine("Getting data");
        var getAllAwaiter = await _handlesRepository.GetAllAsync();
        if (getAllAwaiter != null)
        {
            var handles = new List<LogHandle>(getAllAwaiter);
            if (_handles == null)
            {
                _handles = handles;
                _messages = _handles.First().Messages;
                StateHasChanged();
            } else if (_handles == handles)
            {
                var currentmessage = handles.SingleOrDefault(
                    x => x.Id == _messages.FirstOrDefault().LogHandleId);
                if (currentmessage == null)
                {
                    _messages = _handles.First().Messages;
                    Console.WriteLine("Message changed!");
                    StateHasChanged();
                }
            }else
            {
                _handles = handles;
                var currentmessage = handles.SingleOrDefault(
                    x => x.Id == _messages.FirstOrDefault().LogHandleId);
                if (currentmessage == null)
                {
                    _messages = _handles.First().Messages;
                    Console.WriteLine("Message changed!");
                }
                StateHasChanged();
            }
        }
        else
        {
            _handles = new List<LogHandle>();
            _messages = new List<LogMessage>();
            StateHasChanged();
        }
    }
    
    protected override async Task OnInitializedAsync()
    {
        _timer = new Timer(_ =>
        {
            InvokeAsync(GetData);
        }, null, 2000, 2000);
    }
 
    
    void IDisposable.Dispose()
    {
        _timer?.Dispose();
        _timer = null;
    }
    
}
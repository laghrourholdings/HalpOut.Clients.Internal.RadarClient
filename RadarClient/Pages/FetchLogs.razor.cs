using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;

namespace RadarClient.Pages;

public partial class FetchLogs : ComponentBase, IDisposable
{
    private List<LogHandle>? _handles;
    private string val;
    private List<LogMessage>? _messages;
    private bool autoRefreshLogs = false;
    private System.Threading.Timer _timer;
    private SfGrid<LogHandle> logHandleGrid;
    private double selectedLogHandleIndex;
    private SfGrid<LogMessage> logMessageGrid;
    public async Task GetLogsData()
    {
        var getAllAwaiter = await _handlesRepository.GetAllAsync();
        if (getAllAwaiter != null)
        {
            var handles = new List<LogHandle>(getAllAwaiter);
            if (_handles == null)
            {
                _handles = new List<LogHandle>();
                _messages = new List<LogMessage>();
            }
            if (_handles != handles)
            {
                _handles = handles;
                if (_handles != null && _messages != null)
                {
                    var currentMessages = _handles.SingleOrDefault(
                        x => x.LogHandleId == _messages.FirstOrDefault()?.LogHandleId);
                    if (currentMessages == null)
                    {
                        _messages = _handles.First().Messages;
                        selectedLogHandleIndex = 0;
                    }
                    else if (currentMessages.Messages != _messages)
                    {
                        _messages = currentMessages.Messages;
                    }
                }
            }
        }
    }
    
    protected override async Task OnInitializedAsync()
    {
        await GetLogsData();
        _timer = new Timer(_ =>
        {
            if(autoRefreshLogs)
                InvokeAsync(GetLogsData);
        }, null, 0, 2000);
    }
    
    public void RowSelectHandler(RowSelectEventArgs<LogHandle> args)
    {
        _messages = args.Data.Messages;
        selectedLogHandleIndex = args.RowIndex;
    }
 
    public void RowSelectHandler(RowSelectEventArgs<LogMessage> args)
    {
        
    }

    
    
    
    public async Task OnDataBound(object args)
    {
        await logHandleGrid.SelectRowAsync(selectedLogHandleIndex);
    }
    
    void IDisposable.Dispose()
    {
        _timer?.Dispose();
        _timer = null;
    }

}
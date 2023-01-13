using CommonLibrary.Logging.Models.Dtos;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;

namespace RadarClient.Pages;

public partial class FetchLogs : ComponentBase, IDisposable
{
    private List<LogHandleDto>? _handles;
    private string val;
    private List<LogMessageDto>? _messages;
    private bool autoRefreshLogs = false;
    private System.Threading.Timer _timer;
    private SfGrid<LogHandleDto> logHandleGrid;
    private double selectedLogHandleIndex;
    private SfGrid<LogMessageDto> logMessageGrid;
    public async Task GetLogsData()
    {
        var getAllAwaiter = await _handlesRepository.GetAllAsync();
        if (getAllAwaiter != null)
        {
            var handles = new List<LogHandleDto>(getAllAwaiter);
            if (_handles == null)
            {
                _handles = new List<LogHandleDto>();
                _messages = new List<LogMessageDto>();
            }
            if (_handles != handles)
            {
                _handles = handles;
                if (_handles != null && _messages != null)
                {
                    var currentMessages = _handles.SingleOrDefault(
                        x => x.Id == _messages.FirstOrDefault()?.LogHandleId);
                    if (currentMessages == null)
                    {
                        _messages = _handles.First().Messages as List<LogMessageDto>;
                        selectedLogHandleIndex = 0;
                    }
                    else if (currentMessages.Messages != _messages)
                    {
                        _messages = currentMessages.Messages as List<LogMessageDto>;
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
    
    public void RowSelectHandler(RowSelectEventArgs<LogHandleDto> args)
    {
        _messages = args.Data.Messages as List<LogMessageDto>;
        selectedLogHandleIndex = args.RowIndex;
    }
 
    public void RowSelectHandler(RowSelectEventArgs<LogMessageDto> args)
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
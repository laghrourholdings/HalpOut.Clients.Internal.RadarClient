using CommonLibrary.Logging.Models.Dtos;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;

namespace RadarClient.Pages;

public partial class FetchLogs : ComponentBase, IDisposable
{
    private List<LogHandleDto> _handles = new();
    private string _val;
    private List<LogMessageDto> _messages = new();
    private bool _autoRefreshLogs = false;
    private System.Threading.Timer _timer;
    private SfGrid<LogHandleDto> logHandleGrid;
    private Guid _selectedLogHandleId = Guid.Empty;
    private double _selectedLogHandleRowIndex;
    private SfGrid<LogMessageDto> logMessageGrid;
    
    public async Task GetLogsData()
    {
        var getAllAwaiter = await _handlesRepository.GetAllAsync();
        if (getAllAwaiter != null)
        {
            var handles = new List<LogHandleDto>(getAllAwaiter);
            if (_handles != handles)
            {
                _handles = handles;
                var selectedLogHandle = _handles.SingleOrDefault(x => x.LogHandleId == _selectedLogHandleId);
                if (selectedLogHandle == null)
                {
                    var x = _handles.First().LogHandleId;
                    var y = _handles.First().Messages;
                    _selectedLogHandleId = x;
                    _messages = y.ToList();
                    _selectedLogHandleRowIndex = 0;
                }
                else if (!Equals(selectedLogHandle.Messages, _messages))
                {
                    _messages = selectedLogHandle.Messages.ToList();
                }
            }
        }
    }
    
    protected override async Task OnInitializedAsync()
    {
        await GetLogsData();
        _timer = new Timer(_ =>
        {
            if(_autoRefreshLogs)
                InvokeAsync(GetLogsData);
        }, null, 0, 2000);
    }
    
    public void RowSelectHandler(RowSelectEventArgs<LogHandleDto> args)
    {
        _selectedLogHandleId = args.Data.LogHandleId;
        _messages = args.Data.Messages.ToList();
        _selectedLogHandleRowIndex = args.RowIndex;
    }
 
    public void RowSelectHandler(RowSelectEventArgs<LogMessageDto> args)
    {
        
    }

    
    
    
    public async Task OnDataBound(object args)
    {
        logHandleGrid.SelectRowAsync(_selectedLogHandleRowIndex);
    }
    
    void IDisposable.Dispose()
    {
        _timer?.Dispose();
        _timer = null;
    }

}
using Fluxor;
using Microsoft.AspNetCore.Components;
using RadarClient.Store;
using RadarClient.Store.CounterUseCase;

namespace RadarClient.Pages;

public partial class Counter
{
    [Inject]
    private IState<CounterState> CounterState { get; set; }
    [Inject]
    public IDispatcher Dispatcher { get; set; }
    private void IncrementCount()
    {
        var action = new IncrementCounterAction();
        Dispatcher.Dispatch(action);
    }
}
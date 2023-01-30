using Fluxor;

namespace RadarClient.Store.CounterUseCase.Reducers;

public class Reducers
{
    [ReducerMethod]
    public static CounterState ReduceIncrementCounterAction(CounterState state, IncrementCounterAction action) =>
        new CounterState(clickCount: state.ClickCount + 1);
}
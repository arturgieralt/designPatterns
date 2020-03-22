using System;
using System.Threading;
using System.Threading.Tasks;
using designPatterns.StatePattern.Base;

namespace designPatterns.StatePattern
{
public enum ProcessingResult { Sucess, Fail, Cancel }
    public class StaticFunctions
    {
        public static ProcessingResult Result = ProcessingResult.Sucess;
        public static async void ProcessBooking(StateManager _stateManager, Action<StateManager, ProcessingResult> callback, CancellationTokenSource token)
        {

            try
            {
                await Task.Run(async delegate
                {
                    await Task.Delay(new TimeSpan(0, 0, 3), token.Token);
                });
            }
            catch (OperationCanceledException)
            {
                callback(_stateManager, ProcessingResult.Cancel);
                return;
            }

            callback(_stateManager, Result);
        }
        
        public static void WithResult(ProcessingResult _result) 
        {
            Result = _result;
        }
    }
}
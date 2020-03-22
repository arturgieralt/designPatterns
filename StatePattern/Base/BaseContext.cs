namespace designPatterns.StatePattern.Base
{
    public class BaseContext<S>: IContext where S: IState
    {
        protected S currentState;

        public BaseContext(S initialState) {
            TransitionToState(initialState);
        }

        public void TransitionToState(IState state) {
            currentState = (S)state;
            currentState.InitState(this);
        }
    }
}
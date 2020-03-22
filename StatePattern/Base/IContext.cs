namespace designPatterns.StatePattern.Base
{
    public interface IContext
    {
        void TransitionToState(IState state);
    }
}
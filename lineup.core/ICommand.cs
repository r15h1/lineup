namespace LineUp.Core
{
    public interface ICommand
    {
        IRequest Request { get; }
        void Execute();
    }
}

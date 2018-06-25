namespace LineUp.Core.Commands
{
    public interface ICommand
    {
        IRequest Request { get; }
        void Execute();
    }
}

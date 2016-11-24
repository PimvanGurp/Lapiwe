namespace Lapiwe.Common
{
    /// <summary>
    ///     Use a handler to listen for a command
    ///     and implement the handle method to add
    ///     functionality to when the command is fired.
    /// </summary>
    /// <example>
    ///     public class CreateRoomHandler : ICommandHandler<CreateRoomCommand>
    /// </example>
    /// <typeparam name="TEvent"></typeparam>
    public interface ICommandHandler<TRequest> 
        where TRequest : DomainCommand
    {
        /// <summary>
        ///     Add functionality to a triggered command
        /// </summary>
        /// <param name="domainCommand"></param>
        /// <returns></returns>
        void Handle(TRequest domainCommand);

        /// <summary>
        ///     Add functionality to a triggered command
        ///     and wait for its response
        /// </summary>
        /// <param name="domainCommand"></param>
        /// <returns></returns>
        DomainResponse<TResponse> HandleRPC<TResponse>(TRequest domainCommand);
    }
}
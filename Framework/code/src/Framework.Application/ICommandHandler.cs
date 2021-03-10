using System;
using System.Threading.Tasks;

namespace Framework.Application
{
    public interface ICommandHandler<T>
    {
        Task Handle(T command);
    }
}

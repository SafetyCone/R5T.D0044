using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0044
{
    [ServiceDefinitionMarker]
    public interface IStringSerializer<T> : IServiceImplementation
    {
        Task<T> Deserialize(string @string);

        Task<string> Serialize(T value);
    }
}

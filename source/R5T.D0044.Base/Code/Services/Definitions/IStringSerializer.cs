using System;
using System.Threading.Tasks;


namespace R5T.D0044
{
    public interface IStringSerializer<T>
    {
        Task<T> Deserialize(string @string);

        Task<string> Serialize(T value);
    }
}

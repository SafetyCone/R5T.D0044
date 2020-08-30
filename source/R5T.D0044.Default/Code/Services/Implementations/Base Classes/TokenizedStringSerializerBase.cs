using System;
using System.Threading.Tasks;

using R5T.Magyar;


namespace R5T.D0044.Default
{
    public abstract class TokenizedStringSerializerBase<T> : IStringSerializer<T>
    {
        public const char DefaultTokenSeparatorChar = '|';


        public virtual char TokenSeparatorChar => TokenizedStringSerializerBase<T>.DefaultTokenSeparatorChar;
        public virtual char[] Separators => ArrayHelper.From(this.TokenSeparatorChar);


        public Task<T> Deserialize(string @string)
        {
            var tokens = @string.Split(this.Separators);

            return this.DeserializeTokens(tokens);
        }

        protected abstract Task<T> DeserializeTokens(string[] tokens);

        public async Task<string> Serialize(T value)
        {
            var tokens = await this.GetTokens(value);

            var result = String.Join(this.TokenSeparatorChar.ToString(), tokens);
            return result;
        }

        public abstract Task<string[]> GetTokens(T value);
    }
}

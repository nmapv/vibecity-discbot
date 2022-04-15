using System.Linq;

namespace vibecity_discbot.infrastructure.Tools
{
    public static class StringTools
    {
        public static string GetValueSplit(this string param, string value, int index)
        {
            if (string.IsNullOrEmpty(param) || !param.Contains(value) || param.Split(value).Count() != index + 1)
                return null;

            return param.Split(value)[index];
        }
    }
}

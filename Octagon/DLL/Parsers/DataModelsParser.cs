using Octagon.DataModels;
using System.Data;

namespace DLL.Parsers
{
    public static class DataModelsParser
    {
        public static void Parse<T>(this DataRow row, ref T model) where T : IParseble
        {
            model.Parse(row);
        }
    }
}

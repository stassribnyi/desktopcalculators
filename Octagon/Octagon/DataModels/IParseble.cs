using System.Data;

namespace Octagon.DataModels
{
    public interface IParseble
    {
        void Parse(DataRow row); 
    }
}
using System.Data;

namespace Octagon.DataModels 
{
    public class UserMemory : IParseble
    {
        public int UserId { get; set; }

        public decimal Memory { get; set; }
        
        public void Parse(DataRow row)
        {
            UserId = (int)row["User_ID"];
            Memory = (decimal)row["Memory"];
        }
    }
}

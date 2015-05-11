using System;
using System.Data;

namespace Octagon.DataModels 
{
    public class UserMemoryModel : BaseDataModel, IParseble
    {
        private const string TableName = "UserMemory";

        public override string GetTableName()
        {
            return TableName;
        }

        public int UserId { get; set; }

        public double? Memory { get; set; }
        
        public void Parse(DataRow row)
        {
            UserId = (int)row["User_ID"];
            Memory = (double)row["Memory"];
        }
    }
}

using System.Data;

namespace Octagon.DataModels
{
    public class UserHistoryModel : BaseDataModel, IParseble
    {
        private const string TableName = "UserHistory";

        public override string GetTableName()
        {
            return TableName;
        }

        public int HistoryId { get; set; }

        public int? UserId { get; set; }

        public string Expression { get; set; }

        public void Parse(DataRow row)
        {
            HistoryId = (int)row["History_ID"];
            UserId = (int)row["User_ID"];
            Expression = (string)row["Expression"];
        }
    }
}

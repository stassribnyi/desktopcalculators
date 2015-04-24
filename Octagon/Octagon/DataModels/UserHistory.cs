using System.Data;

namespace Octagon.DataModels
{
    public class UserHistory : IParseble
    {
        public int HistoryId { get; set; }

        public int UserId { get; set; }

        public string Expression { get; set; }

        public void Parse(DataRow row)
        {
            HistoryId = (int)row["History_ID"];
            UserId = (int)row["User_ID"];
            Expression = (string)row["Memory"];
        }
    }
}

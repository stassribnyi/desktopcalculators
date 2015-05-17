namespace Octagon.DataModels
{
    public class UserNameModel : BaseDataModel, IParseble
    {
        private const string TableName = "UserName";

        public int UserId { get; set; }

        public string Name { get; set; }
        
        public override string GetTableName()
        {
            return TableName;
        }

        public void Parse(System.Data.DataRow row)
        {
            UserId = (int)row["User_ID"];
            Name = (string)row["Name"];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

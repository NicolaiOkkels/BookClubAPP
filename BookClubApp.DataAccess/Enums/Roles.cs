using System.ComponentModel;

namespace BookClubApp.DataAccess.Enums
{
    public enum Roles
    {
        [Description("Owner")] 
        Owner,
        [Description("Member")]
        Member
    }
}

using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;

public class DummyMembershipRepository : IMembershipRepository
{
    public Task<Membership> AddMembershipAsync(Membership membership)
    {
        throw new NotImplementedException();
    }

    public Task<Membership> DeleteMembershipAsync(Membership membership)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Membership>> GetAllMembershipsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Membership> GetMembershipAsync(int bookClubId, int value)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Membership>> GetMembershipsByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }
}

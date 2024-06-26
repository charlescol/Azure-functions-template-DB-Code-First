using Config.Database.Context;

namespace Services
{
    public class UsersService : IUsersService<Models.Users>
    {
        private readonly UsersContext _context;
        public UsersService(UsersContext context)
        {
            _context = context;
        }
        public void Add(Models.Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public Models.Users GetOne(int id)
        {
            return _context.Users.Find(id);
        }
    }
}

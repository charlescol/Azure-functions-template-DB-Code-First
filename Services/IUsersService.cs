namespace Services
{
    public interface IUsersService<TModel>
    {
        public void Add(TModel user);

        public TModel GetOne(int id);
    }
}

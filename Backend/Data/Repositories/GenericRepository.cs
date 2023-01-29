using Microsoft.EntityFrameworkCore;

namespace Tepe.Brt.Data.Repositories
{
    public interface IGenericRepository
    {
        #region User
        Task<IEnumerable<UserEntity>> GetUserList();
        #endregion
    }

    public class GenericRepository : IGenericRepository
    {
        private readonly ApplicationDbContext _model;
        public GenericRepository(ApplicationDbContext model)
        {
            _model = model;
        }

        #region User
        public async Task<IEnumerable<UserEntity>> GetUserList()
        {
            var model = await _model.Users.ToListAsync();
            return model;
        }
        #endregion
    }
}

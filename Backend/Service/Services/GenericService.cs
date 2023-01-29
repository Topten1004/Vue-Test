using Tepe.Brt.Data;
using Tepe.Brt.Data.Repositories;

namespace Tepe.Brt.Business.Services
{
    public interface IGenericService
    {
        #region User
        Task<IEnumerable<UserEntity>> GetUserList();
        #endregion

    }
    public class GenericService : IGenericService
    {
        private readonly IGenericRepository _userRepository;
        public GenericService(IGenericRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region User
        public async Task<IEnumerable<UserEntity>> GetUserList()
        {
            return await _userRepository.GetUserList();
        }

        #endregion
    }
}
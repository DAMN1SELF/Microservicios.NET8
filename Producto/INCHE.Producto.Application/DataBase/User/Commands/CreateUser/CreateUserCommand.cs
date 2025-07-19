using AutoMapper;
using INCHE.Producto.Common.Constants;
using INCHE.Producto.Domain.Entities.User;

namespace INCHE.Producto.Application.DataBase.User.Commands.CreateUser
{
    public class CreateUserCommand: ICreateUserCommand
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;
        public CreateUserCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }
        public async Task<CreateUserModel> Execute(CreateUserModel model)
        {
            try
            {
				var entity = _mapper.Map<UserEntity>(model);
				entity.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
				await _databaseService.User.AddAsync(entity);
				await _databaseService.SaveAsync();
				return model;
			}
            catch (Exception ex)
            {

				throw new ApplicationException(Messages.RecordCreationFailed, ex);
			}
        }
    }
}

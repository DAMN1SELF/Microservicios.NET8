using FluentValidation;
using INCHE.Producto.Application.DataBase.User.Commands.UpdateUserPassword;

namespace INCHE.Producto.Application.Validators.User
{
    public class UpdateUserPasswordValidator: AbstractValidator<UpdateUserPasswordModel>
    {
        public UpdateUserPasswordValidator()
        {
            RuleFor(x =>x.UserId).NotNull().GreaterThan(0);
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(10);
        }
    }
}

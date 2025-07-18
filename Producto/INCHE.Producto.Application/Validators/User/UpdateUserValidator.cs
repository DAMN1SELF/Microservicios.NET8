using FluentValidation;
using INCHE.Producto.Application.DataBase.User.Commands.UpdateUser;

namespace INCHE.Producto.Application.Validators.User
{
    public class UpdateUserValidator: AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(x=> x.UserId).NotNull().GreaterThan(0);
            RuleFor(x=> x.FirstName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x=> x.LastName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x=> x.UserName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x=> x.Password).NotNull().NotEmpty().MaximumLength(10);
        }
    }
}

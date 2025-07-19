using FluentValidation;
using INCHE.Producto.Application.DataBase.User.Commands.AuthUser;


namespace INCHE.Producto.Application.Validators.User
{
    public class AuthUserValidator : AbstractValidator<AuthUserModel>
    {
        public AuthUserValidator()
        {
			RuleFor(x => x.UserName)
				.NotNull().WithMessage("El usuario es obligatorio.")
				.NotEmpty().WithMessage("El usuario es obligatorio.")
				.MaximumLength(15).WithMessage("El usuario no debe superar 15 caracteres.")
				.Matches(@"^[a-zA-Z0-9_]+$").WithMessage("El usuario solo puede contener letras, números y guion bajo.");

			RuleFor(x => x.Password)
			   .NotNull().WithMessage("La contraseña es obligatoria.")
			   .NotEmpty().WithMessage("La contraseña es obligatoria.")
			   .MaximumLength(30).WithMessage("La contraseña no debe superar 30 caracteres.")
			   .Matches(@"^[a-zA-Z0-9]+$").WithMessage("La contraseña solo puede contener letras y números.");

		}
	}
}

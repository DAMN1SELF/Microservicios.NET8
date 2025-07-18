using FluentValidation;
using INCHE.Producto.Application.DataBase.Product.Commands.UpdateProduct;

namespace INCHE.Producto.Application.Validators.Product
{
    public class UpdateProductValidator: AbstractValidator<UpdateProductModel>
    {
        public UpdateProductValidator()
        {
			RuleFor(x => x.FullName)
					.NotNull().WithMessage("El nombre del producto es obligatorio.")
					.NotEmpty().WithMessage("El nombre del producto no puede estar vacío.")
					.MinimumLength(3).WithMessage("El nombre del producto debe tener al menos 3 caracteres.")
					.MaximumLength(50).WithMessage("El nombre del producto no puede superar los 50 caracteres.")
					.Matches(@"^[a-zA-Z0-9\s_\-\.()]+$")
					.WithMessage("El nombre del producto solo puede contener letras, números, espacios, guion, guion bajo, punto y paréntesis.");

			RuleFor(x => x.BatchNumber)
				   .MaximumLength(10).WithMessage("El número de lote no puede superar los 10 caracteres.")
				   .Matches(@"^[a-zA-Z0-9]+$").When(x => !string.IsNullOrEmpty(x.BatchNumber))
				   .WithMessage("El número de lote solo puede contener letras y números.");

			RuleFor(x => x.Cost)
				.NotNull().WithMessage("El costo es obligatorio.")
				.GreaterThan(0).WithMessage("El costo debe ser mayor a 0.")
				.LessThanOrEqualTo(1000000).WithMessage("El costo no puede ser mayor a 1,000,000.");

			RuleFor(x => x.SalePrice)
				.NotNull().WithMessage("El precio de venta es obligatorio.")
				.GreaterThan(0).WithMessage("El precio de venta debe ser mayor a 0.")
				.LessThanOrEqualTo(1000000).WithMessage("El precio de venta no puede ser mayor a 1,000,000.");
		}
    }
}

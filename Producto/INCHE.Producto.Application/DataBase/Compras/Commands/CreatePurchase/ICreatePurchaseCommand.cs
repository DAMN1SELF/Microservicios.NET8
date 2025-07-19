

namespace INCHE.Producto.Application.DataBase.Purchase.Commands.CreatePurchase
{
    public interface ICreatePurchaseCommand
    {
        Task<CreatePurchaseModel> Execute(CreatePurchaseModel model);
    }
}

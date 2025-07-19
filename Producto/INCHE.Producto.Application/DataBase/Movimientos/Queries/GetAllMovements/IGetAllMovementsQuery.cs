namespace INCHE.Producto.Application.DataBase.Inventory.Queries.GetAllMovements
{
    public interface IGetAllMovementsQuery
	{
        Task<List<ResponseMovementModel>> Execute(bool IncludeDetails);
    }
}

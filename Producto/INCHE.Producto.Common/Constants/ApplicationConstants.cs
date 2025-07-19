
namespace INCHE.Producto.Common.Constants
{
    public class ApplicationConstants
    {
		public static readonly decimal MARGEN_PRECIO_VENTA = 1.13M;
		public static readonly decimal IGV = 1.18M;
	}

	public static class Messages
	{

		public const string RecordCreated = "El registro se creó correctamente";
		public const string RecordRetrieved = "El registro se obtuvo correctamente";
		public const string RecordsRetrieved = "Los registros se obtuvieron correctamente";
		public const string RecordUpdated = "El registro se actualizó correctamente";
		public const string RecordDeleted = "El registro se eliminó correctamente";
		public const string RecordNotFound = "No se encontró el registro";
		public const string NoRecordsFound = "No se encontraron registros";
		public const string RecordAlreadyDeleted = "El registro ya ha sido eliminado";
		public const string RecordAlreadyExists = "El registro ya existe";
		public const string RecordCreationFailed = "No se pudo crear el registro";
		public const string RecordUpdateFailed = "No se pudo actualizar el registro";
		public const string RecordDeleteFailed = "No se pudo eliminar el registro";
		public const string InvalidRecordId = "El identificador no es válido";
		public const string MissingData = "Faltan datos obligatorios";

	}
}

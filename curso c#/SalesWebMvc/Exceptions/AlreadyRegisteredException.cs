namespace SalesWebMvc.Exceptions;
class AlreadyRegisteredException : Exception
{
    public AlreadyRegisteredException(string entity) 
        : base($"{entity} já está registrado.")
    {
    }
}
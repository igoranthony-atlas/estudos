namespace SalesWebMvc.Exceptions;
class NotFoundException : Exception
{
    public NotFoundException(string entidade) : base($"{entidade} não encontrada.")
    {
    }
}
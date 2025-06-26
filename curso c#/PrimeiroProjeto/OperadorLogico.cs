namespace Logica;
class OperadorLogico
{
    public static void Executar()
    {
        // && -> AND
        // || -> OR
        // !  -> NOT

        bool bomHumor = true;
        bool dinheiroNaConta = true;

        if (bomHumor && dinheiroNaConta)
        {
            Console.WriteLine("Vou sair de casa!");
        }
        else
        {
            Console.WriteLine("Não vou sair de casa!");
        }

    }
}
namespace POO;

class Calculadora
{
    static double Pi = 3.14159;
    static double Circunferencia(double raio)
    {
        return 2.0 * Pi * raio;
    }
    static double Volume(double raio)
    {
        return (4.0 / 3.0) * Pi * raio * raio * raio;
    }
}
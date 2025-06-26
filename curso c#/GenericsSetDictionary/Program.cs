using System.Globalization;

namespace GenericsSetDicionary;

class Program
{
    static void Main(string[] args)
    {
        string path = "C:\\temp\\arquivolog.txt";
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        try
        {
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] fields = line.Split(',');
                    string name = fields[0];
                    int votos = int.Parse(fields[1], CultureInfo.InvariantCulture);
                    if (dictionary.ContainsKey(name))
                    {
                        dictionary[name] += votos;
                    }
                    else
                    {
                        dictionary[name] = votos;
                    }
                }
            }
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocorreu um erro: " + e.Message);
        }
        
    }
}
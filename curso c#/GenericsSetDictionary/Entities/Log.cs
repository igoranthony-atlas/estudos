namespace GenericsSetDicionary;

class Log
{
    public string Name { get; set; }
    public DateTime Date { get; set; }

    public Log(string name, DateTime date)
    {
        Name = name;
        Date = date;
    }
    public override string ToString()
    {
        return $"{Name} - {Date:dd/MM/yyyy HH:mm:ss}";
    }
    public override bool Equals(object? obj)
    {
        if (!(obj is Log))
        {
            return false;
        }
        Log other = obj as Log;
        return Name.Equals(other.Name); 
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
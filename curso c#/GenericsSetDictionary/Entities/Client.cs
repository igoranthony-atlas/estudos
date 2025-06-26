namespace GenericsSetDicionary;

class Client
{
    public string Name { get; set; }
    public int Email { get; set; }

    public override bool Equals(object obj)
    {
        if (!(obj is Client))
        {
            return false;
        }
        Client other = obj as Client;
        return Name.Equals(other.Name) && Email.Equals(other.Email);
    }
    public override int GetHashCode()
    {
        return Email.GetHashCode();
    }
}
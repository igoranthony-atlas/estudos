namespace GenericsSetDicionary;
class PrintService<T>
{
    private List<T> _list = new List<T>();

    public void Add(T item)
    {
        _list.Add(item);
    }

    public void Print()
    {
        Console.Write("[");
        for (int i = 0; i < _list.Count - 1; i++)
        {
            Console.Write(_list[i]);
            if (i < _list.Count - 1)
            {
                Console.Write(", ");
            }
        }
        if (_list.Count > 0)
        {
            Console.Write(_list[_list.Count - 1]);
        }
        Console.WriteLine("]");
    }

    public T First()
    {
        if (_list.Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }
        return _list[0];
    }
}
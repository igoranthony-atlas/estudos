namespace GenericsSetDicionary;

class CalculationService
{
    public static T Max<T>(List<T> list) where T : IComparable<T>
    {
        if (list.Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }

        T max = list[0];
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i].CompareTo(max) > 0)
            {
                max = list[i];
            }
        }
        return max;
    }
}
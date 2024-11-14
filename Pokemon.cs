public class Pokemon 
{
    private string separator = ";";
    public string Name { get; private set; } // autoproperty (read-only)
    public Type Type { get; private set; }
    public int ID { get; private set; }
    public bool Discovered { get; private set; }

   

    public Pokemon(string name, Type type, int id, bool discover)
    {
        Name = name;
        Type = type;
        ID = id;
        Discovered = discover;
    }

    public Pokemon(string name, Type type, int id): this(name, type, id, false)
    {
    }

    public void Discover()
    {
        Discovered = true;
    }

    public override string ToString()
    {
        return $"{ID} {separator} {Name} {separator} {(int)Type} {separator} {Discovered}";
    }
    public string GetTypeAsString(Type type)
    {
        List<string> types = new List<string>();

        foreach (Type t in Enum.GetValues(typeof(Type)))
        {
            if (type.HasFlag(t) && Type.HasFlag(t))
            {
                types.Add(t.ToString());
            }
        }
        return string.Join(" | ", types);
    }

    public static void Documentation()
    {
        Console.WriteLine("Classe qui représente un pokémon.")
    }
}

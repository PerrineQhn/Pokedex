using System.Runtime.CompilerServices;

public class AddCommand : Command
{

    
    public AddCommand(Pokedex pokedex, string[] commandArgs) : base(pokedex, commandArgs)
    {
        if (arguments.Length < 3)
        {
            isValid = false;
        }
    }

    
    public override void Execute() 
    {
        if (!isValid)
        {
            Console.Error.WriteLine("Not enough arguments");
            Console.WriteLine("Usage: dotnet run add <index> <name> <type>");
            return;
        }

        if (!int.TryParse(arguments[0], out int index))
        {
            Console.Error.WriteLine("Invalid index");
            return;
        }

        string name = arguments[1];

        if (!Type.TryParse(arguments[2], out Type type))
        {
            Console.Error.WriteLine("Invalid type");
            return;
        }
        
        Pokemon pokemon = new Pokemon(name, type, index);
        Pokedex.Add(pokemon);

        Console.WriteLine($"Adding {name} to the pokedex ({type}, {index})");
    }
}
public class SearchCommand : Command
{
    
    public SearchCommand(Pokedex pokedex, string[] commandsArgs) : base(pokedex, commandsArgs)
    {
        if (commandsArgs.Length < 1)
        {
            isValid = false;
        }
    }

    public override void Execute()
    {
        if (!isValid)
        {
            Console.Error.WriteLine("Not enough arguments");
            Console.WriteLine("Usage: dotnet run search <name>");
            return;
        }

        Pokemon pokemon = Pokedex.Get(arguments[0]);
        if (pokemon != null)
        {
            Console.WriteLine($"{pokemon.Name}  ({pokemon.ID})");
            Console.WriteLine($"Type: {pokemon.GetTypeAsString(pokemon.Type)}");
        }
        else
        {
            Console.WriteLine("Pokemon not found");
        }
    }
}
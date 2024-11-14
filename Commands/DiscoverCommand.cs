public class DiscoverCommand : Command
{
    public DiscoverCommand(Pokedex pokedex, string[] commandArgs) : base(pokedex, commandArgs)
    {
        if (arguments.Length < 1)
        {
            isValid = false;
        }
    }

    public override void Execute()
    {
        if (!isValid)
        {
            Console.Error.WriteLine("Not enough arguments");
            Console.WriteLine("Usage: dotnet run discover <name>");
            return;
        }

        // Chercher le pokemon dans le pokedex
        Pokemon pokemon = Pokedex.Get(arguments[0]);
        pokemon.Discover(); // Découvrir le pokemon
    }
}
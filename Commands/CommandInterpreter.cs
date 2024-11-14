public class CommandInterpreter
{
    Pokedex pokedex;

    public CommandInterpreter(Pokedex pokedex)
    {
        this.pokedex = pokedex;
    }

    public Command Interpret(string[] arguments)
    {
        if (arguments.Length < 1)
        {
            Console.Error.WriteLine("Not enough arguments!");
            //Console.Error.WriteLine("Available commands : add, search, discover, pokedex");

            throw new ArgumentException();
        }

        string commandName = arguments[0];
        string[] commandArguments = arguments.Skip(1).ToArray();

        switch (commandName)
        {
            case "add":
                AddCommand addCommand = new AddCommand(pokedex, commandArguments);
                return addCommand;

            case "search":
                SearchCommand searchCommand = new SearchCommand(pokedex, commandArguments);
                return searchCommand;

            case "save":
                SaveCommand saveCommand = new SaveCommand(pokedex, commandArguments);
                return saveCommand;

            case "load":
                LoadCommand loadCommand = new LoadCommand(pokedex, commandArguments);
                return loadCommand;

            default:
                Console.Error.WriteLine($"Command '{commandName}' not recognized.");
                throw new ArgumentException();
        }
    }
}
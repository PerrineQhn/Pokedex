public class Program
{
    public static void Main(string[] args)
    {

        Pokedex pokedex = new Pokedex();
        
        // pokedex.Add(new Pokemon("Pikachu", Type.Electric, 25));
        // pokedex.Add(new Pokemon("Salamèche", Type.Fire, 4));
        // pokedex.Add(new Pokemon("Bulbizarre", Type.Grass | Type.Poison, 1));
        // pokedex.Add(new Pokemon("Dracaufeu", Type.Fire | Type.Flying, 6));
        // pokedex.Add(new Pokemon("Carapuce", Type.Water, 7));

        Pokemon.Documentation();

        while (true)
        {
            Console.Write("$ ");
            string line = Console.ReadLine();
            string[] commandArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            CommandInterpreter interpreter = new CommandInterpreter(pokedex);
            Command command = interpreter.Interpret(commandArgs);
            command.Execute();
        }
    }

}
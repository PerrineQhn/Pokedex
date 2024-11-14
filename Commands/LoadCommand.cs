// prendre un fichier
// vérifier que le fichier existe
// lire chaque ligne (faire attention aux lignes vides)
// lire et instancier un pokémon par ligne
// StreamReader
// ReadLine

public class LoadCommand : Command
{

    public LoadCommand(Pokedex pokedex, string[] commandArgs) : base(pokedex, commandArgs)
    {
        if (commandArgs.Length < 1)
        {
            isValid = false;
        }
    }
    public override void Execute()
    {
        string path = arguments[0];

        if (!isValid)
        {
            Console.Error.WriteLine("Not enough arguments");
            Console.WriteLine("Usage: dotnet run load <nomDuFichier>");
            return;
        }

        if (!File.Exists(path))
        {
            Console.Error.WriteLine("File Doesn't Exist");
            return;
        }


        StreamReader reader = new StreamReader(path);
        int count = 0;

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] data = line.Split(';');
            string name = data[1];

            if (!int.TryParse(data[0], out int index))
            {
                throw new Exception("Wrong type");
            }

            if (!Type.TryParse(data[2], out Type type))
            {
                throw new Exception("Wrong type");
            }

            if (!bool.TryParse(data[3], out bool discovered))
            {
                throw new Exception("Wrong type");
            }


            Pokemon pokemon = new Pokemon(name, type, index, discovered);
            
            Pokedex.Add(pokemon);
            count++;
        }
        Console.WriteLine($"{count} pokemon in pokedex.");
        
    }

    
}
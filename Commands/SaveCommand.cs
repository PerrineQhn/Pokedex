// save <nomDuFichier>
public class SaveCommand : Command
{
    string saveDirectory = "Data";
    public SaveCommand(Pokedex pokedex, string[] CommandArgs) : base(pokedex, CommandArgs)
    {
        if (CommandArgs.Length < 1)
        {
            isValid = false;
        }
    }
    public override void Execute()
    {
        string path = AddExtension(arguments[0]);
        path = $"{saveDirectory}/{path}";
        Directory.CreateDirectory(saveDirectory);

        StreamWriter streamWriter = new StreamWriter(path);

        SavePokedex(streamWriter);
        streamWriter.Flush();
        streamWriter.Close();
    }

    void SavePokedex(StreamWriter file)
    {
        Pokedex.Save(file);
    }

    string AddExtension(string path)
    {
        if (!path.Contains("."))
        {
            return $"{path}.csv";
        }
        return path;
    }
}
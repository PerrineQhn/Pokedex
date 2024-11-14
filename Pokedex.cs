public class Pokedex
{
    Pokemon[] pokemons = new Pokemon[151];

    public void Add(Pokemon pokemon)
    {
        pokemons[pokemon.ID-1] = pokemon;
    }

    public void Discover(Pokemon pokemon)
    {
        // pokemons[pokemon.ID-1].Discovered = true;
        pokemon.Discover();
    }
    
    public Pokemon Get(int id)
    {
        return pokemons[id-1];
    }
    
    public Pokemon Get(string name)
    {
        foreach (Pokemon pokemon in pokemons)
        {
            if (pokemon != null  && pokemon.Name.ToLower() == name.ToLower())
            {
                return pokemon;
            }
        }
        return null;
    }
    
    public Pokemon[] GetByType(Type type)
    {
        
        int arraySize = 0;
        foreach (Pokemon pokemon in pokemons)
        {
            if (pokemon != null && pokemon.Type.HasFlag(type)) // HasFlag is a method that checks if a flag is set in an enum, here it checks if the type of the pokemon has the flag type
            {
                arraySize++;
            }
        }

        int index = 0;
        Pokemon[] result = new Pokemon[arraySize];
        foreach (Pokemon pokemon in pokemons)
        {
            if (pokemon != null && pokemon.Type.HasFlag(type))
            {
                result[index++] = pokemon;
            }
        }

        return result;
    } 

    public void Save(StreamWriter file)
    {
        foreach (Pokemon pokemon in pokemons)
        {
            if (pokemon != null)
            {
                file.WriteLine(pokemon.ToString());
            }
        }
    }

    // public IEnumerable<Pokemon> GetByTypeEnumerate(Type t)
    // {
    //     foreach (Pokemon pokemon in pokemons)
    //     {
    //         if (pokemon!=null && pokemon.Type == t)
    //         {
    //             yield return pokemon;
    //         }
    //     }
    // }
    
}
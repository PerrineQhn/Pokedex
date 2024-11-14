struct Rectangle
{
    int longueur;
    public int Longueur 
    { 
        get // String GetName() { return name; }
        {
            return longueur;
        }
        set // void SetName(string value) { name = value; }
        {
            longueur = value; // toujours value dans le setter
        }
    }
        
    public int Largeur { get; private set; }   
    public int Surface
    {
        get // get to access the value of the property
        {
            return Longueur * Largeur;
        }
    }

    public Rectangle(int longueur, int largeur)
    {
        Longueur = longueur;
        Largeur = largeur;
    } 
}
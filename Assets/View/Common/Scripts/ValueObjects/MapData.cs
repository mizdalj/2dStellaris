[System.Serializable]
public class MapData
{
    public int size;
    public int planetLimit;
    
    public MapData(int size, int planetLimit)
    {
        this.size = size;
        this.planetLimit = planetLimit;
    }
}
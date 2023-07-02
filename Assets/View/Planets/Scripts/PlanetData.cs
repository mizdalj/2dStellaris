using UnityEngine;

[CreateAssetMenu(fileName = "New Planet", menuName = "ScriptableObjects/Planet", order = 1)]
public class PlanetData : ScriptableObject
{
    public string planetName;
    public Sprite sprite;
    // Productions
    public int food;
    public int science;
    public int industry;
    public int energy;

    // Stats
    public int districtLimit;
    public int population;
}
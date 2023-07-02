using UnityEngine;
using TMPro;

public class PlanetInfoPanel : MonoBehaviour
{
    public TextMeshProUGUI planetName;
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI scienceText;
    public TextMeshProUGUI industryText;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI districtLimitText;
    public TextMeshProUGUI populationText;

    public void UpdatePlanetInfo(Planet planet)
    {
        PlanetData data = planet.planetData; // Access the PlanetData instance

        planetName.text = data.planetName;
        foodText.text = "Food: " + data.food;
        scienceText.text = "Science: " + data.science;
        industryText.text = "Industry: " + data.industry;
        energyText.text = "Energy: " + data.energy;
        districtLimitText.text = "District Limit: " + data.districtLimit;
        populationText.text = "Population: " + data.population;
    }
}

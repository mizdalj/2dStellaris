using UnityEngine;

public class PlanetUiManager : MonoBehaviour
{
    // Singleton instance
    public static PlanetUiManager Instance { get; private set; }

    // Add this line to hold a reference to the PlanetInfoPanel
    public PlanetInfoPanel panel;

    private void Awake()
    {
        // Set up the Singleton instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdatePlanetInfo(Planet planet)
	{
    	// Update the planet info panel
    	panel.UpdatePlanetInfo(planet);

    	// Show the planet info panel
    	panel.gameObject.SetActive(true);
	}

    // Call this function to hide the planet info panel
    public void HidePlanetInfo()
    {
        // Hide the planet info panel
        panel.gameObject.SetActive(false);
    }
}

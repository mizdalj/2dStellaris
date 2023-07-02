using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    // Singleton instance
    public static SelectionManager Instance { get; private set; }

    // This will hold the reference to the selected planet
    private Planet selectedPlanet;

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

    void Update()
    {
        // Check if left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray to the position of the mouse cursor
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            // If the ray does not hit a planet, deselect the currently selected planet
            if (hit.collider == null || hit.collider.gameObject.GetComponent<Planet>() == null)
            {
                DeselectPlanet();
            }
        }
    }

    // Call this function to select a planet
    public void SelectPlanet(Planet planet)
    {
        // Deselect the currently selected planet
        DeselectPlanet();

        // Set the new selected planet
        selectedPlanet = planet;

        // Instantiate the selector
        selectedPlanet.InstantiateSelector();
    }

    // Call this function to deselect the selected planet
    public void DeselectPlanet()
    {
        if (selectedPlanet != null)
        {
            // Destroy the selector
            selectedPlanet.DestroySelector();

            // Reset the selected planet
            selectedPlanet = null;

            // Hide the planet info panel
            PlanetUiManager.Instance.HidePlanetInfo();
        }
    }
}
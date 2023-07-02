using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject selectorPrefab;
    public PlanetData planetData; // Assign this in the Unity editor
    private SpriteRenderer spriteRenderer;
    // This will hold the reference to the instantiated selector
    private GameObject selector;

    private void Awake()
    {
        
    }
    
    public void setPlanetData(PlanetData data)
    {
        planetData = data;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the sprite of the SpriteRenderer to the sprite specified in the PlanetData
        spriteRenderer.sprite = planetData.sprite;
    }

    private void OnMouseDown()
    {
        // Select this planet
        SelectionManager.Instance.SelectPlanet(this);
        PlanetUiManager.Instance.UpdatePlanetInfo(this);
    }

    // Call this function to instantiate the selector
    public void InstantiateSelector()
    {
        if (selector == null)
        {
            selector = Instantiate(selectorPrefab, transform.position, Quaternion.identity);
        }
    }

    // Call this function to destroy the selector
    public void DestroySelector()
    {
        if (selector != null)
        {
            Destroy(selector);
            selector = null;
        }
    }

    // Add this function to get the PlanetData
    public PlanetData GetPlanetData()
    {
        return planetData;
    }
}
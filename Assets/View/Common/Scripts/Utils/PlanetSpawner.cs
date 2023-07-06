using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetSpawner : MonoBehaviour
{
    // The planet prefab
    public GameObject planetPrefab;

    // The list of PlanetData objects
    public List<PlanetData> planetDataList;

    // The number of planets to spawn
    public int numberOfPlanets;

    // Range for the x and y positions of the planets
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
		MapData mapData = GameSettings.mapData;
		minX = -mapData.size / 2;
		maxX = mapData.size / 2;
		minY = -mapData.size / 2;
		maxY = mapData.size / 2;
		numberOfPlanets = mapData.planetLimit;
		Debug.Log("Spawning " + numberOfPlanets + " planets with a map size of " + mapData.size);
        SpawnPlanets();
	}

    void SpawnPlanets()
    {
        for (int i = 0; i < numberOfPlanets; i++)
        {
            // Instantiate a new planet
        GameObject newPlanet = Instantiate(planetPrefab);

        // Generate a random scale factor and apply it to the new planet
        float scaleFactor = Random.Range(0.5f, 1.5f);
        newPlanet.transform.localScale *= scaleFactor;

        // Assign a random PlanetData from the list
        PlanetData randomPlanetData = Instantiate(planetDataList[Random.Range(0, planetDataList.Count)]);

        // Scale the production stats of the PlanetData according to the scaleFactor
        randomPlanetData.food = Mathf.RoundToInt(randomPlanetData.food * scaleFactor);
        randomPlanetData.science = Mathf.RoundToInt(randomPlanetData.science * scaleFactor);
        randomPlanetData.industry = Mathf.RoundToInt(randomPlanetData.industry * scaleFactor);
        randomPlanetData.energy = Mathf.RoundToInt(randomPlanetData.energy * scaleFactor);
        randomPlanetData.districtLimit = Mathf.RoundToInt(randomPlanetData.districtLimit * scaleFactor);

        // Get the Planet script attached to the new planet
        Planet planetScript = newPlanet.GetComponent<Planet>();

        // Assign the modified PlanetData to the Planet script
        planetScript.setPlanetData(randomPlanetData);

            bool isColliding = true;
            int retryCount = 0;
            const int maxRetryCount = 50;

            // Retry placing the planet if it collides with another one
            while (isColliding && retryCount < maxRetryCount)
            {
                // Position the new planet at a random position within the defined range
                newPlanet.transform.position = new Vector3(
                    Random.Range(minX, maxX),
                    Random.Range(minY, maxY),
                    0
                );

				float originalRadius = planetScript.GetComponent<CircleCollider2D>().radius;
				float checkRadius = 1.5f * originalRadius + 5f;

				// Check for collisions with other planets
				Collider2D[] colliders = Physics2D.OverlapCircleAll(newPlanet.transform.position, checkRadius);


                isColliding = false;
                foreach (Collider2D collider in colliders)
                {
                    if (collider != newPlanet.GetComponent<Collider2D>())
                    {
                        isColliding = true;
                        break;
                    }
                }

                retryCount++;
            }

            if (isColliding)
            {
                Debug.LogWarning("Failed to find a non-colliding position for the planet after " + retryCount + " retries.");
                Destroy(newPlanet);
                continue; // Skip to the next iteration if no valid position is found
            }
        }
    }
}

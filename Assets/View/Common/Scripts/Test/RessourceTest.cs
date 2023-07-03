using UnityEngine;
using System.Collections;

public class ResourceTest : MonoBehaviour
{
    public float interval = 5f;  // The time in seconds between each resource increase
    public int increaseAmount = 100;  // The amount to increase the resources by each time

    private void Start()
    {
        // Start the IncreaseResources coroutine
        StartCoroutine(IncreaseResources());
    }

    private IEnumerator IncreaseResources()
    {
        while (true)  // This will loop indefinitely
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(interval);

            // Increase each resource by the specified amount
            ResourceMonitor.Instance.AddFood(increaseAmount);
            ResourceMonitor.Instance.AddScience(increaseAmount);
            ResourceMonitor.Instance.AddIndustry(increaseAmount);
            ResourceMonitor.Instance.AddEnergy(increaseAmount);
        }
    }
}
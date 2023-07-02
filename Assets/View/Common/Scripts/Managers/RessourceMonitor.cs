using System;
using UnityEngine;

public class ResourceMonitor : MonoBehaviour
{
    public static ResourceMonitor Instance { get; private set; }

    public int food;
    public int science;
    public int industry;
    public int energy;

    // An event that gets called whenever a resource changes.
    // The UI can subscribe to this event to update itself.
    public event Action<int, int, int, int> OnResourcesChanged;

    private void Awake()
    {
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

    // Methods for modifying the resources. These should be called whenever
    // something happens in the game that changes the amount of a resource.

    public void AddFood(int amount)
    {
        food += amount;
        NotifyResourceChanged();
    }

    public void AddScience(int amount)
    {
        science += amount;
        NotifyResourceChanged();
    }

    public void AddIndustry(int amount)
    {
        industry += amount;
        NotifyResourceChanged();
    }

    public void AddEnergy(int amount)
    {
        energy += amount;
        NotifyResourceChanged();
    }

    private void NotifyResourceChanged()
    {
        OnResourcesChanged?.Invoke(food, science, industry, energy);
    }
}
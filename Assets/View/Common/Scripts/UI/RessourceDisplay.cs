using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI scienceText;
    public TextMeshProUGUI industryText;
    public TextMeshProUGUI energyText;

    private void Start()
    {
        // Subscribe to the OnResourcesChanged event
        ResourceMonitor.Instance.OnResourcesChanged += UpdateResourceAmounts;

        // Update the display immediately to show the initial resource amounts
        UpdateResourceAmounts(
            ResourceMonitor.Instance.food,
            ResourceMonitor.Instance.science,
            ResourceMonitor.Instance.industry,
            ResourceMonitor.Instance.energy
        );
    }

    private void OnDestroy()
    {
        // Unsubscribe from the OnResourcesChanged event when this object is destroyed,
        // to prevent null reference errors if the event gets triggered after this object is destroyed
        ResourceMonitor.Instance.OnResourcesChanged -= UpdateResourceAmounts;
    }

    public void UpdateResourceAmounts(int food, int science, int industry, int energy)
    {
        foodText.text = "Food: " + food;
        scienceText.text = "Science: " + science;
        industryText.text = "Industry: " + industry;
        energyText.text = "Energy: " + energy;
    }
}
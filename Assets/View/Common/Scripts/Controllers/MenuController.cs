using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    // Assign these in the Inspector
    public GameObject mainMenuPanel;
    public GameObject skirmishSettingsPanel;
    public TMP_InputField mapSizeInputField;
    public TMP_InputField planetLimitInputField;

    public MapData mapData;
    public void StartSkirmishSettings()
    {
        // Hide Main Menu
        mainMenuPanel.SetActive(false);
        
        // Show Skirmish Settings
        skirmishSettingsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        // Show Main Menu
        mainMenuPanel.SetActive(true);
        
        // Hide Skirmish Settings
        skirmishSettingsPanel.SetActive(false);
    }
    
    public void StartGame()
    {
        // Read the map size from the input field
        int mapSize = int.Parse(mapSizeInputField.text);
        int planetLimit = int.Parse(planetLimitInputField.text);

        // Create MapData object
        GameSettings.mapData = new MapData(mapSize, planetLimit);

        // Now use mapSize for your game setup
        Debug.Log("Starting game with map size: " + GameSettings.mapData.size + ", and planet limit: " + GameSettings.mapData.planetLimit);

        // Load the GameScene
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        // If we are running in a standalone build of the game
        #if UNITY_STANDALONE
        // Quit the application
        Application.Quit();
        #endif

        // If we are running in the editor
        #if UNITY_EDITOR 
        // Stop playing the scene
        // UnityEditor.EditorApplication.isPlaying = false;
        #endif  
    }
}
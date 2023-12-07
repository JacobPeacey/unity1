using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Make sure to include this namespace for Text

public class YourClassName : MonoBehaviour
{
    [Header("UI Component")]
    public Text WaveText; // Make it public to assign in the Unity Editor

    private int waveNumber = 1; // You should have a variable to store the wave number

    void Start()
    {
        // Initialize your WaveText component if it's not assigned in the Editor
        if (WaveText == null)
        {
            WaveText = GetComponent<Text>();
        }

        // You might want to set the initial wave number
        UpdateWaveText();
    }

  void EnemyDied()
{
    // Increment waveNumber when an enemy dies
    waveNumber++;
    UpdateWaveText();
    Debug.Log("Enemy died. New waveNumber: " + waveNumber);
}

    #region Pickups

    // Your pickup logic goes here

    #endregion

    #region UI

    void UpdateWaveText()
    {
        WaveText.text = "Wave: " + waveNumber;
    }

    #endregion
}


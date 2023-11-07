// Sets difficulty of game according to which choice is clicked at the start of the scene

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty;

    // Waits for choice from player and gets game manager object
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Passes difficulty selected from button onto game manager
    void SetDifficulty() {
        gameManager.StartGame(difficulty);
    }
}

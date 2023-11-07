// Handles game assets and gameplay loop

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets; // Gets list of target balls
    
    // Variables for UI elements
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    public bool isGameActive; // Used for game over sequence

    private int score;
    private float spawnRate = 1.0f; // Spawn rate of target balls

    // Sets up main gameplay loop
    public void StartGame(int difficulty) {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false); // Deactivates title screen menu
    }

    // Every so often (decided by spawnRate), picks a random target from the list, and spawns it
    IEnumerator SpawnTarget() {
        while(isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    // Adjusts score and score text UI
    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Sets up game over window
    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    // Reloads scene
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
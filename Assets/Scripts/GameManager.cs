using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static int totalScore;
    private int currentScore;
    private static int lives;
    private static int health;
    private const int maxHealth = 3;
    private static List<int> levelScores;
    private int keyItems;
    
    // Start is called before the first frame update
    void Start() {
        currentScore = 0;
        keyItems = 0;
        if(SceneManager.GetActiveScene().buildIndex == 0) {
            health = 1;
            totalScore = 0;
            levelScores = new List<int>();
        }
    }

    // Update is called once per frame
    void Update() {
        if(health <= 0) {
            RestartLevel();
        }
    }

    public void AddScore(int _score) {
        currentScore += _score;
        if(currentScore % 100 == 0) {
            lives++;
        }
    }

    public void RestartLevel() {
        lives--;
        health = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() {
        levelScores.Add(currentScore);
        totalScore += currentScore;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void pickKeyItem() {
        keyItems++;
        if(keyItems == 3) {
            //TODO interface handle
        }
    }

    private void OnDestroy() {
        //levelScores.Add(currentScore);
        //totalScore += currentScore;
    }

}

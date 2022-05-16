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
    [SerializeField] GameObject goal;
    private static bool init = true;
    
    // Start is called before the first frame update
    void Start() {
        currentScore = 0;
        keyItems = 0;
        if(init) {
            health = 1;
            totalScore = 0;
            levelScores = new List<int>();
            init = false;
        }
        goal = GameObject.Find("Goal");
    }

    // Update is called once per frame
    void LateUpdate() {
        if(health <= 0) {
            RestartLevel();
        }
        if(lives <= 0) {
            RestartGame();
        }
        if(keyItems == 3) {
            goal.GetComponent<CambiarBandera>();
        }
    }

    public void AddScore(int _score) {
        currentScore += _score;
        if(currentScore % 100 == 0) {
            lives++;
        }
    }

    public void AddHealth() {
        if(health < 3) {
            health++;
        } 
    }

    public void Hurt() {
        health--;
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
    }

    public void RestartGame() {
        init = true;
        SceneManager.LoadScene(0);
    }

    private void OnDestroy() {
        //levelScores.Add(currentScore);
        //totalScore += currentScore;
    }

    public int GetCurrentScore() {
        return currentScore;
    }

    public int GetHealth() {
        return health;
    }

    public int GetLives() {
        return lives;
    }

    public int GetKeyItems() {
        return keyItems;
    }

    public int GetLevelScore(int level) {
        return levelScores[level];
    }

    public int GetTotalScore() {
        return totalScore;
    }

}

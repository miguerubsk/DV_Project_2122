using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static int totalScore;
    private int currentScore;
    private static int lives, health;
    private const int maxHealth = 3;
    private static List<int> levelScores;
    private int keyItems, pointsToLive;
    [SerializeField] GameObject goal;
    private static bool init = true;
    private float invincibilityCounter, flashCounter, flashTime = 0.1f, invincibilityTime = 1;
    [SerializeField] Renderer playerRenderer;

    // Start is called before the first frame update
    void Start() {
        currentScore = 0;
        keyItems = 0;
        if(init) {
            pointsToLive = 0;
            lives = 3;
            health = 1;
            totalScore = 0;
            levelScores = new List<int>();
            init = false;
        }
        goal = GameObject.Find("Goal");
        //playerRenderer = GameObject.Find("PlayerArmature");
    }

    // Update is called once per frame
    void Update() {
        
        if (invincibilityCounter > 0) {
            invincibilityCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0) {
                playerRenderer.enabled = !playerRenderer.enabled;

            }
            if (invincibilityCounter <= 0) {
                playerRenderer.enabled = true;
            }
        }

        if (pointsToLive >= 100) {
            lives++;
            pointsToLive -= 100;
        }

    }

    public void AddScore(int _score) {
        currentScore += _score;
        pointsToLive += _score;
        if(pointsToLive >= 100) {
            lives++;
            pointsToLive -= 100;
        }
    }

    public void HealPlayer() {
        if(health < 3) {
            health++;
        } else {
            AddScore(50);
        }
    }

    public void HurtPlayer() {
        if (invincibilityCounter <= 0) {
            health--;
            if (health <= 0) {
                RestartLevel();
            } else {
                invincibilityCounter = invincibilityTime;
                playerRenderer.enabled = false;
                flashCounter = flashTime;
            }
        }
    }

    public void RestartLevel() {
        lives--;
        if (lives <= 0) {
            RestartGame();
        }
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
        if (keyItems == 3) {
            //goal.GetComponent<>();
            GameObject.Find("Goal").GetComponent<CambioBandera>().cambiaBandera();
        }
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
        return levelScores[level-1];
    }

    public int GetTotalScore() {
        return totalScore;
    }

}

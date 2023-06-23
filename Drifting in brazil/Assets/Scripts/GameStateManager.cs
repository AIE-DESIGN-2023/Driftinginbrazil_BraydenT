using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    //variables for enemies left, total enemies, text display, win and lose canvas
    public int enemiesLeft;
    public int enemiesTotal;
    public TMP_Text enemiesText;
    public Canvas winCanvas, loseCanvas;
    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        //find all enemies in the scene and assign the total count to the amount it finds
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesTotal = enemies.Length;

        //assign the text the value of remaining and total enemies
        enemiesText.text = enemiesTotal + "/" + enemiesTotal + " Enemies remaining";

        //turning off the win and lose canvas
        winCanvas.gameObject.SetActive(false);
        loseCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //find all enemies in the scene and assign the remaining count to the amount it finds
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;

        //assign the text value of remaining enemies
        enemiesText.text = enemiesLeft + "/" + enemiesTotal + " Enemies remaining";

        //check if there are any enemis left, if not then player wins n turn of win canvas
        if (enemiesLeft == 0)
        {
            winCanvas.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            PlayerHealth player = FindObjectOfType<PlayerHealth>();

            if (player != null)
            {
                player.gameObject.SetActive(false);
            }
        }
    }

    public void PlayerDies()
    {
        loseCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadPlayScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void LoadControlsScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Controls");
    }

    public void LoadMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

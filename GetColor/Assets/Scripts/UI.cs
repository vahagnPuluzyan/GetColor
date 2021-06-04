using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public float timer = 10f;
    public Text text;
    public Text diamonds;
    public Player player;
    public GameObject gameOverMenu;
    public Text levelText;
    public GameObject startImage;
    public bool isPaused = false;

    public void ReplayGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Index"));
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        isPaused = true;
        player.joystick.SetActive(false);
        Time.timeScale = 0;
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer >= 0f)
        {
            text.text = System.Math.Floor(timer).ToString();
        }
        diamonds.text = player.diamonds.ToString();

        if (player == null)
        {
            gameOverMenu.SetActive(true);
        }
        levelText.text = "Level" + " " + PlayerPrefs.GetInt("Index").ToString();
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(startLoad());
    }

    IEnumerator startLoad()
    {
        startImage.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        startImage.SetActive(false);
    }
}
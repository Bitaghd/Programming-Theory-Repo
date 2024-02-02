using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject target;
    public GameObject countdown;
    public Text scoreText;
    public Text highscoreText;
    private Text timerText;
    public float timer = 30;
    Transform[] spawnPoints;
    public bool isStarted { get; private set; } // ENCAPSULATION
    private GameObject obj;
    private float timeleft;
    private int value = 100;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = spawn.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        timerText = countdown.GetComponentInChildren<Text>();
        ShowHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        if(isStarted)
            StartCountdown();

        if(isStarted && obj == null) 
        {
            obj = Instantiate(target, GenerateSpawnPoint()); // ABSTRACTION
        }

        if(!isStarted && obj != null)
            Destroy(obj);
    }

    public IEnumerator StartGame()
    {
        score = 0;
        timeleft = timer;
        isStarted = true;
        yield return new WaitForSeconds(timer);
        countdown.SetActive(false);
        scoreText.gameObject.SetActive(false);
        if (score > PlayerPrefs.GetInt("HScore", 0))
        {
            PlayerPrefs.SetInt("HScore", score);
            ShowHighscore();
        }
        isStarted = false;
    }

    Transform GenerateSpawnPoint()
    {
        var spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
        return spawn;
    }
    void StartCountdown()
    {
        countdown.SetActive(true);
        scoreText.gameObject.SetActive(true);
        timeleft -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(timeleft / 60);
        float seconds = Mathf.FloorToInt(timeleft % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void UpdateScore()
    {
        score += value;
        scoreText.text = score.ToString();
    }

    private void ShowHighscore()
    {
        var highscore = PlayerPrefs.GetInt("HScore", 0);
        if (highscore > 0)
        {
            highscoreText.gameObject.SetActive(true);
            highscoreText.text = "Highscore\n" + highscore.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;

    private int score = 0;
    public bool isGameOver = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;

        if (score % 10 == 0)
        {
            PoopCreater creater = FindObjectOfType<PoopCreater>();
            if (creater != null)
            {
                creater.DecreasePoopInterval();
                //Debug.Log("PoopInterval decreased");
            }
        }
    }

    public void SetGameOver()
    {
        if (isGameOver == false)
        {
            isGameOver = true;

            PoopCreater creater = FindObjectOfType<PoopCreater>();
            if (creater != null)
            {
                creater.StopCreating();
                //Debug.Log("PoopInterval decreased");
            }

            gameOverPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject GameText;
    [SerializeField] private TextMeshProUGUI scoreText;

    public bool isGameOver = false;
    private int score = 0;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        
    }

    public void GameOver()
    {
        isGameOver = true;
        GameText.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGameOver)
        {
            RestartGame();
        }
    }
}

using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Player1Text;
    [SerializeField] private TextMeshProUGUI Player2Text;

    [SerializeField] private Transform Player1Transform;
    [SerializeField] private Transform Player2Transform;
    [SerializeField] private Transform BallTransform;

    private int Player1Score = 0;
    private int Player2Score = 0;

    public static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<GameManager>();
              
            }
            return instance;
        }
    }

    public void Player1Scores()
    {
        Player1Score++;
        Player1Text.text = Player1Score.ToString();
        ResetPositions();
    }
    public void Player2Scores()
    {
        Player2Score++;
        Player2Text.text = Player2Score.ToString();
        ResetPositions();
    }
    public void ResetPositions()
    {
        Player1Transform.position = new Vector2(Player1Transform.position.x, 0);
        Player2Transform.position = new Vector2(Player2Transform.position.x, 0);
        BallTransform.position = Vector2.zero;
        
    }
}
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float speedIncrement = 1.1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            rb.linearVelocity *= speedIncrement;
        }
    }
    private void Launch()
    {
        float xDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        float yDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.linearVelocity = new Vector2(xDirection, yDirection) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal1"))
        {
            GameManager.Instance.Player2Scores();
            GameManager.Instance.ResetPositions();
            Launch();
        }
        else if (collision.CompareTag("Goal2"))
        {
            GameManager.Instance.Player1Scores();
            GameManager.Instance.ResetPositions(); 
            Launch();
        }
    }

}

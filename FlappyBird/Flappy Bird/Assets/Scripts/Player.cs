using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float upForce = 350f;

    private Rigidbody2D rb;
    private bool isDead;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDead)
        {
            Flap();
        }
    }
    private void Flap()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * upForce);
        animator.SetTrigger("Flap");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
       isDead = true;
       animator.SetTrigger("Die");
       GameManager.Instance.GameOver();
        
        
    }
}

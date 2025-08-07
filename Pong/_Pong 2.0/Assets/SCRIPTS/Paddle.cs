using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPlayer1;
    public float yLimit = 3.75f;

    // Update is called once per frame
    void Update()
    {

        float verticalInput;
        if (isPlayer1)
        {
            verticalInput = Input.GetAxis("Vertical2");
        }
        else
        {
            verticalInput = Input.GetAxis("Vertical");
        }
        Vector2 playerPosition = transform.position;
        playerPosition.y = Mathf.Clamp(playerPosition.y + verticalInput * speed * Time.deltaTime, -yLimit, yLimit);
        transform.position = playerPosition;
    }
}

using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidBodyBall;
    public float speed = 300;
    private Vector2 velocity;
    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
        ResetBall();        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            FindAnyObjectByType<GameManager>().LoseHealth();
        }
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        velocity = Vector2.zero;

        velocity.x = Random.Range(-1f, -1f);
        velocity.y = 1;
        // aca no se multiplica por el delta time porque no esta
        // dentro de un update
        rigidBodyBall.AddForce(velocity * speed);
    }
}

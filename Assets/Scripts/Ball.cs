using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidBodyBall;
    public float speed = 300;
    private Vector2 velocity;
    private Vector2 startPosition;
    public AudioSource audioSource;
    public AudioClip playerSound, brickSound, wallSound, deadZoneSound;

    void Start()
    {
        startPosition = transform.position;
        ResetBall();        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            audioSource.clip = deadZoneSound;
            audioSource.Play();
            FindAnyObjectByType<GameManager>().LoseHealth();
        }
        if (collision.gameObject.GetComponent<Player>())
        {
            audioSource.clip = playerSound;
            audioSource.Play();
        }
        if (collision.gameObject.GetComponent<Brick>())
        {
            audioSource.clip = playerSound;
            audioSource.Play();
        }
        if (collision.transform.CompareTag("Wall"))
        {
            audioSource.clip = wallSound;
            audioSource.Play();
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

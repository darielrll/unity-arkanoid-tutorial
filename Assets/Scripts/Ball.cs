using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidBodyBall;
    public float speed = 300;
    private Vector2 velocity;

    void Start()
    {
        velocity.x = Random.Range(-1f, -1f);
        velocity.y = 1;

        // aca no se multiplica por el delta time porque no esta
        // dentro de un update
        rigidBodyBall.AddForce(velocity * speed);
    }
}

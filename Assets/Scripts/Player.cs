using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBodyPlayer;
    private float inputValue;
    public float moveSpeed = 25;
    private Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        inputValue = Input.GetAxisRaw("Horizontal");

        if (inputValue == 1)
        {
            direction = Vector2.right;
        }
        else if (inputValue == -1)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.zero;
        }

        rigidBodyPlayer.AddForce(direction * moveSpeed * Time.deltaTime * 100);
    }
}

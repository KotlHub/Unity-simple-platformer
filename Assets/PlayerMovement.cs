using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Скорость движения игрока

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput < 0)
        {
            MoveDown();
        }
        else if (verticalInput > 0)
        {
            MoveUp();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(0);
        }
    }
    void MoveDown()
    {
        if(transform.position.y > -5.5) {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    void MoveUp()
    {
        if (transform.position.y < 5.5)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }
}

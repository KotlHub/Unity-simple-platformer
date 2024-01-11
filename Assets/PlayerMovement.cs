using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Скорость движения игрока
    public float jumpForce; // Сила прыжка
    private bool isGrounded; // Флаг, указывающий, находится ли игрок на полу
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Получаем ввод с клавиатуры
        float verticalInput = Input.GetAxis("Vertical");

        // Проверяем, находится ли игрок на полу
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        // Двигаем игрока вниз при нажатии на клавишу S только если он находится на полу
        if (verticalInput < 0 && isGrounded)
        {
            MoveDown();
        }
        // Двигаем игрока вверх при нажатии на клавишу W только если он находится на полу
        else if (verticalInput > 0 && isGrounded)
        {
            MoveUp();
        }

        // Прыжок при нажатии на клавишу Space только если он находится на полу
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void MoveDown()
    {
        // Двигаем игрока вниз
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void MoveUp()
    {
        // Двигаем игрока вверх
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void Jump()
    {
        // Применяем силу прыжка
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}

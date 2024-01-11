using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // �������� �������� ������
    public float jumpForce; // ���� ������
    private bool isGrounded; // ����, �����������, ��������� �� ����� �� ����
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �������� ���� � ����������
        float verticalInput = Input.GetAxis("Vertical");

        // ���������, ��������� �� ����� �� ����
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        // ������� ������ ���� ��� ������� �� ������� S ������ ���� �� ��������� �� ����
        if (verticalInput < 0 && isGrounded)
        {
            MoveDown();
        }
        // ������� ������ ����� ��� ������� �� ������� W ������ ���� �� ��������� �� ����
        else if (verticalInput > 0 && isGrounded)
        {
            MoveUp();
        }

        // ������ ��� ������� �� ������� Space ������ ���� �� ��������� �� ����
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void MoveDown()
    {
        // ������� ������ ����
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void MoveUp()
    {
        // ������� ������ �����
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void Jump()
    {
        // ��������� ���� ������
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    public float moveSpeed = 1f;
    public float jumpStrength = 1f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _direction = Vector2.up * jumpStrength;
        }
        else
        {
            _direction += Physics2D.gravity * Time.deltaTime;
        }

        _direction.x = Input.GetAxis("Horizontal") * moveSpeed;
        _direction.y = Mathf.Max(_direction.y, -1f);

        if (_direction.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (_direction.x < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * Time.fixedDeltaTime);
    }
}

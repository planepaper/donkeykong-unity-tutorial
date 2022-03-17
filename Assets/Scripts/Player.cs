using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider;
    private Collider2D[] _results;
    private Vector2 _direction;
    public float moveSpeed = 1f;
    public float jumpStrength = 1f;
    private bool grounded;
    private bool climbing;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _results = new Collider2D[4];
    }

    private async void CheckCollision()
    {
        grounded = false;
        climbing = false;
        Vector2 size = _collider.bounds.size;
        size.y += 0.1f;
        size.x /= 2f;

        int amount = Physics2D.OverlapBoxNonAlloc(transform.position, size, 0f, _results);

        for (int i = 0; i < amount; i++)
        {
            GameObject hit = _results[i].gameObject;

            if (hit.layer == LayerMask.NameToLayer("Ground"))
            {
                grounded = hit.transform.position.y < (transform.position.y - 0.5f);

                Physics2D.IgnoreCollision(_collider, _results[i], !grounded);
            }
            else if (hit.layer == LayerMask.NameToLayer("Ladder"))
            {
                climbing = true;
            }
        }
    }

    private void Update()
    {
        CheckCollision();

        if (climbing)
        {
            _direction.y = Input.GetAxis("Vertical") * moveSpeed;
        }
        else if (grounded && Input.GetButtonDown("Jump"))
        {
            _direction = Vector2.up * jumpStrength;
        }
        else
        {
            _direction += Physics2D.gravity * Time.deltaTime;
        }

        _direction.x = Input.GetAxis("Horizontal") * moveSpeed;

        if (grounded)
        {
            _direction.y = Mathf.Max(_direction.y, -1f);
        }

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

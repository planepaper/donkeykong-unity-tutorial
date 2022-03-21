using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float speed = 1f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _rigidbody.AddForce(collision.transform.right * speed, ForceMode2D.Impulse);
        }
    }
}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void AddForce(Vector2 direction, float speed)
    {
        _rigidbody.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}

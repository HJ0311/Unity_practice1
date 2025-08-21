using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float minSize = 0.5f;
    public float maxSize = 2.0f;
    public float minSpeed = 200f;
    public float maxSpeed = 300f;
    public float maxSpinSpeed = 10f;
    private Rigidbody2D rb;
    public GameObject bounceEffectPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1f);

        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize;
        Vector3 randomDirection = Random.insideUnitCircle;
        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        rb.AddForce(randomDirection * randomSpeed);
        rb.AddTorque(randomTorque);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 contactPoint = collision.GetContact(0).point;
        GameObject bounceEffect = Instantiate(bounceEffectPrefab, contactPoint, Quaternion.identity);

        // Destroy the effect after 1 second
        Destroy(bounceEffect, 1f);
    }

    void Update()
    {
        // 필요하면 매 프레임 동작 추가
    }
}

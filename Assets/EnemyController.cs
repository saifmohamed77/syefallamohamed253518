
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed = 2f;
    public int damage = 1;
    public SpriteRenderer sr;

      void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

     void Flip()
    {
        if (sr != null)
        {
            sr.flipX = !sr.flipX;
        }
    }

      void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            PlayerStats playerStats =
                other.GetComponentInParent<PlayerStats>();

            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }

            Flip();
        }
        else if (other.tag=="Wall")
        {
            Flip();
        }
    }
}

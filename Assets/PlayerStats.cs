
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 3;
    public int lives = 3;

    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer sr;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void SpriteFlicker()
    {
        if (flickerTime < flickerDuration)
        {
            flickerTime += Time.deltaTime;
        }
        else
        {
            sr.enabled = !sr.enabled;
            flickerTime = 0f;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isImmune == false)
        {
            health -= damage;

            if (health < 0)
            {
                health = 0;
            }

            if (lives > 0 && health == 0)
            {
                FindObjectOfType<levelmanger>().Respawnplayer();
                health = 3;
                lives--;
            }
            else if (lives == 0 && health == 0)
            {
                Debug.Log("Gameover");
                Destroy(gameObject);
            }

            Debug.Log("Player Health: " + health);
            Debug.Log("Player Lives: " + lives);

            isImmune = true;
            immunityTime = 0f;
        }
    }

    void Update()
    {
        if (isImmune == true)
        {
            SpriteFlicker();

            immunityTime += Time.deltaTime;

            if (immunityTime >= immunityDuration)
            {
                isImmune = false;
                sr.enabled = true;
            }
        }
    }
}

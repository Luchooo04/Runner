using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float maxHealth = 100f;
    private float currentHealth;
    private float timer = 0f;
    public float timeToDecrease = 1f;
    public float timeToAdd = 5f;

    void Start()
    {
        currentHealth = maxHealth;
        slider.value = currentHealth;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToDecrease)
        {
            DecreaseHealth();
            timer = 0f;
        }
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Orbe"))
        {
            AddHealth();
            
        }
    }

    void DecreaseHealth()
    {
        currentHealth -= 1f;
        slider.value = currentHealth;
    }

    void AddHealth()
    {
        currentHealth += 20f;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        slider.value = currentHealth;
        timer -= timeToAdd;
    }
}
using System.Configuration;
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

    public void Start()
    {
        currentHealth = maxHealth;
        slider.value = currentHealth;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToDecrease)
        {
            DecreaseHealth();
            timer = 0f;
        }
        
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Orbe")
        {
            AddHealth();
            Destroy(gameObject);
        }

    }
        

    void DecreaseHealth()
    {
        currentHealth -= 1f;
        slider.value = currentHealth;
    }

    public  void AddHealth()
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
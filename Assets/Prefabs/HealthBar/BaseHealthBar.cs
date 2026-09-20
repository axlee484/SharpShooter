using UnityEngine;
using UnityEngine.UI;

// [RequireComponent(typeof(Health))]
public class BaseHealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    private Slider slider;
    private Image fillImage;
    [SerializeField] private Gradient gradient;
    
    private float maxHealth;
    private float currentHealth;
    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        fillImage = GetComponentInChildren<Image>();
        maxHealth = health.MaxHealth;
        currentHealth = health.MaxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;

        health.HealthChangedEvent += OnHealthChanged;
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        slider.value = currentHealth;
        if(gradient!= null)
        {
            fillImage.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
    private void OnHealthChanged(float health)
    {
        UpdateSlider();
    }

}

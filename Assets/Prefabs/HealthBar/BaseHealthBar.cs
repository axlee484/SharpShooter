using UnityEngine;
using UnityEngine.UI;

// [RequireComponent(typeof(Health))]
public class BaseHealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    private Slider slider;
    private Image fillImage;
    [SerializeField] private Gradient gradient;
    
    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        fillImage = GetComponentInChildren<Image>();
        slider.maxValue = health.MaxHealth;
        slider.value = health.MaxHealth;
        health.HealthChangedEvent += OnHealthChanged;
    }

    private void Start()
    {
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        slider.value = health.CurrentHealth;
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

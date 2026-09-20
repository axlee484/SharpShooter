using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private float hitDamage = 0f;
    [SerializeField] private float hitRadius = 0.5f;
    public float HitRadius => hitRadius;
    public float HitDamage => hitDamage;
}

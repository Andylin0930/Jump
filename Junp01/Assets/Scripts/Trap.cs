using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("�ؼйϼh")]
    public LayerMask layerTarget;
    [Header("����q")]
    public float damage = -10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "�D��")
        {
            HurtSystem Damage = collision.GetComponent<HurtSystem>();
            Damage.Damage(damage);

        }
    }
}

using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("目標圖層")]
    public LayerMask layerTarget;
    [Header("扣血量")]
    public float damage = -10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "主角")
        {
            HurtSystem Damage = collision.GetComponent<HurtSystem>();
            Damage.Damage(damage);

        }
    }
}

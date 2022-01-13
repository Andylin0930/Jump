using UnityEngine;
using UnityEngine.UI;     // 引用 介面 API
using UnityEngine.Events; // 引用 事件 API

public class Health : MonoBehaviour
{
    [Header("目標圖層")]
    public LayerMask layerTarget;

    [Header("補血量")]
    public float heal = 20;

    [Header("扣血量")]
    public float damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "主角")
        {
            HurtSystem Health = collision.GetComponent<HurtSystem>();
            Health.Health(heal);
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "主角")
        {
            HurtSystem Health = collision.GetComponent<HurtSystem>();
            
            
        }
    }
}

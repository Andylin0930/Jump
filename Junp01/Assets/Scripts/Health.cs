using UnityEngine;
using UnityEngine.UI;     // �ޥ� ���� API
using UnityEngine.Events; // �ޥ� �ƥ� API

public class Health : MonoBehaviour
{
    [Header("�ؼйϼh")]
    public LayerMask layerTarget;

    [Header("�ɦ�q")]
    public float heal = 20;

    [Header("����q")]
    public float damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "�D��")
        {
            HurtSystem Health = collision.GetComponent<HurtSystem>();
            Health.Health(heal);
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "�D��")
        {
            HurtSystem Health = collision.GetComponent<HurtSystem>();
            
            
        }
    }
}

using UnityEngine;
using UnityEngine.UI;     // 引用 介面 API
using UnityEngine.Events; // 引用 事件 API

public class HpSystem : MonoBehaviour
{
    [Header("血量")]
    public Image imgHp;

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.name == "回復道具")
            {
                imgHp.fillAmount += 0.2f;

                Destroy(collision.gameObject);
            }
    }
}

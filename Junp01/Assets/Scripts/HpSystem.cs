using UnityEngine;
using UnityEngine.UI;     // �ޥ� ���� API
using UnityEngine.Events; // �ޥ� �ƥ� API

public class HpSystem : MonoBehaviour
{
    [Header("��q")]
    public Image imgHp;

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.name == "�^�_�D��")
            {
                imgHp.fillAmount += 0.2f;

                Destroy(collision.gameObject);
            }
    }
}

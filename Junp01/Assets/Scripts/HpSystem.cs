using UnityEngine;
using UnityEngine.UI;     // �ޥ� ���� API
using UnityEngine.Events; // �ޥ� �ƥ� API

public class HpSystem : MonoBehaviour
{
    [Header("��q")]
    public Image imgHp;
    [Header("��q")]
    public float hp = 100;

    private float maxHp;
    private void Awake()
    {
       
        maxHp = hp;
    }

    public void ChangeHealyh(float amount)
    {
        hp -= amount;
        imgHp.fillAmount = hp / maxHp;
    }
}

using UnityEngine;
using UnityEngine.UI;     // 引用 介面 API
using UnityEngine.Events; // 引用 事件 API

public class HpSystem : MonoBehaviour
{
    [Header("血量")]
    public Image imgHp;
    [Header("血量")]
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

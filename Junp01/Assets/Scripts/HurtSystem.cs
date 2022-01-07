using UnityEngine;
using UnityEngine.UI;     // �ޥ� ���� API
using UnityEngine.Events; // �ޥ� �ƥ� API

/// <summary>
///  ���˨t��
/// </summary>
public class HurtSystem : MonoBehaviour
{
    [Header("��q")]
    public Image imgHpBar;
    [Header("��q")]
    public float hp = 100;
    [Header("�ʵe�Ѽ�")]
    public string parameterDead = "���`";
    [Header("���`�ƥ�")]
    public UnityEvent onDead;

    private float hpMax;
    private Animator ani;

    // ����ƥ� : �b Start ���e����@��
    private void Awake()
    {
        ani = GetComponent<Animator>();
        hpMax = hp;
    }
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="damge">�����쪺�ˮ`</param>
    public void Hurt(float damge)
    {
        hp -= damge;
        imgHpBar.fillAmount = hp / hpMax;
        if (hp <= 0) Dead();
    }
    private void Dead()
    {
        ani.SetTrigger(parameterDead);
        onDead.Invoke();
    }
}

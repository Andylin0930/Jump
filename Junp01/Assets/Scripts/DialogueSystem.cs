using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{
    [Header("��ܨt��"), Range(0, 1)]
    public float interval = 0.2f;
    [Header("�e����ܨt��")]
    public GameObject goDialogue;
    [Header("��ܤ��e")]
    public Text TextContent;

    private void Start()
    {
        StartCoroutine(TypeEffect());
    }

    private IEnumerator TypeEffect()
    {
        string test = "�w�w�w�w�w�w�w";

        TextContent.text = "";                   // �M�Ź�ܤ��e
        goDialogue.SetActive(true);              // ��ܹ�ܪ���

        for (int i = 0; i < test.Length; i++)
        {
            TextContent.text += test[i];         // �|�[��ܤ��e��r����
            yield return new WaitForSeconds(interval);
        }
    } 
}

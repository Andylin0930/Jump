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
    [Header("��ܧ����ϥ�")]
    public GameObject goTip;
    [Header("��ܫ���")]
    public KeyCode keyDialogue = KeyCode.Mouse0;

    private void Start()
    {
        //StartCoroutine(TypeEffect());
    }
    /// <summary>
    /// ���r�ĪG
    /// </summary>
    /// <param name="contents">�Q�n�X�{�b��ܨt�Ϊ����e�A�ݭn�ϥΦr��}�C</param>
    /// <returns></returns>
    private IEnumerator TypeEffect(string[] contents)
    {
        // �󴫦W�٧ֱ��� Ctrl + R R
        // ���ե�
        //string test1 = "�A�n�A�_�I��";
        //string test2 = "�ĤG�q���";
        //string[] contents = { test1, test2 };        

        goDialogue.SetActive(true);              // ��ܹ�ܪ���

        for (int j   = 0; j < contents.Length; j++)  // �M�M�Ҧ����
        {
            TextContent.text = "";               // �M�Ź�ܤ��e
            goTip.SetActive(false);              // �M�ŤW����ܤ��e    

            for (int i = 0; i < contents[j].Length; i++)    // �M�M��ܪ��C�@�Ӧr
            {
                TextContent.text += contents[j][i];         // �|�[��ܤ��e��r����
                yield return new WaitForSeconds(interval);
            }

            goTip.SetActive(true);                      // ��ܹ�ܧ����ϥ� �T����
             
            while (!Input.GetKeyDown(keyDialogue))      // ���a�S������ܫ���ɫ������
            {
                yield return null;                      // ���� null �@�Ӽv��ɶ�
            }
        }

        goDialogue.SetActive(false);                    // ���� ��ܪ���
    } 
}

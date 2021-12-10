using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{
    [Header("對話系統"), Range(0, 1)]
    public float interval = 0.2f;
    [Header("畫布對話系統")]
    public GameObject goDialogue;
    [Header("對話內容")]
    public Text TextContent;

    private void Start()
    {
        StartCoroutine(TypeEffect());
    }

    private IEnumerator TypeEffect()
    {
        string test = "安安安安安安安";

        TextContent.text = "";                   // 清空對話內容
        goDialogue.SetActive(true);              // 顯示對話物件

        for (int i = 0; i < test.Length; i++)
        {
            TextContent.text += test[i];         // 疊加對話內容文字介面
            yield return new WaitForSeconds(interval);
        }
    } 
}

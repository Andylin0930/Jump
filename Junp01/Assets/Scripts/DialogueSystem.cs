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
    [Header("對話完成圖示")]
    public GameObject goTip;
    [Header("對話按鍵")]
    public KeyCode keyDialogue = KeyCode.Mouse0;

    private void Start()
    {
        //StartCoroutine(TypeEffect());
    }
    /// <summary>
    /// 打字效果
    /// </summary>
    /// <param name="contents">想要出現在對話系統的內容，需要使用字串陣列</param>
    /// <returns></returns>
    private IEnumerator TypeEffect(string[] contents)
    {
        // 更換名稱快捷鍵 Ctrl + R R
        // 測試用
        //string test1 = "你好，冒險者";
        //string test2 = "第二段對話";
        //string[] contents = { test1, test2 };        

        goDialogue.SetActive(true);              // 顯示對話物件

        for (int j   = 0; j < contents.Length; j++)  // 遍尋所有對話
        {
            TextContent.text = "";               // 清空對話內容
            goTip.SetActive(false);              // 清空上次對話內容    

            for (int i = 0; i < contents[j].Length; i++)    // 遍尋對話的每一個字
            {
                TextContent.text += contents[j][i];         // 疊加對話內容文字介面
                yield return new WaitForSeconds(interval);
            }

            goTip.SetActive(true);                      // 顯示對話完成圖示 三角形
             
            while (!Input.GetKeyDown(keyDialogue))      // 當玩家沒有按對話按鍵時持續執行
            {
                yield return null;                      // 等待 null 一個影格時間
            }
        }

        goDialogue.SetActive(false);                    // 隱藏 對話物件
    } 
}

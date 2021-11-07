
using UnityEngine;

public class Mid : MonoBehaviour
{
    // 主角名字
    [Tooltip("玩家取名")]
    public string Name = "冒險家";
    // 主角血量
    [Tooltip("主角血量")]
    public int hp = 100;
    // 移動速度
    [Tooltip("移動速度")]
    [Range(1, 10)]
    public float speed = 2.5f;
    // 主角移動
    public KeyCode KeyCodeJump = KeyCode.Space;
    public KeyCode KeyCodeuUpArrow = KeyCode.UpArrow;
    public KeyCode KeyCodeuDownArrow = KeyCode.DownArrow;
    public KeyCode KeyCodeuRightArrow = KeyCode.RightArrow;
    public KeyCode KeyCodeuLeftArrow = KeyCode.LeftArrow;
    // 主角起始位置
    public Vector2 character;
}

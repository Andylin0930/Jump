using UnityEngine;

/// <summary>
/// 控制器 : 2D橫向卷軸版本
/// <summary>

public class Controller : MonoBehaviour
{
    #region 欄位 : 公開
    [Header("移動速度"), Range(0, 500)]
    public float speed = 10.5f;
    [Header("跳躍高度"), Range(0, 1500)]
    public float jump = 300;
    [Header("檢查地板與位移")]
    [Range(0, 1)]
    public float cheakGroundRadius = 0.1f;
    public Vector3 ckeakGroundOffset;
    [Header("跳躍按鍵與可跳躍圖層")]
    public KeyCode keyjump = KeyCode.Space;
    public LayerMask canJumpLayer;
    [Header("動畫參數: 走路與跳躍")]
    public string parameterWalk = "跑步";
    public string parameterJump = "跳躍";

    #endregion

    #region 欄位 : 私人
    private Animator ani;
    /// <summary>
    /// 剛體元件
    /// <summary>
    private Rigidbody2D rig;
    [SerializeField]
    /// <summary>
    /// 是否在底板上
    /// <summary>
    private bool isGround;
    #endregion

    #region 事件
    /// <summary>
    /// 繪製圖示
    /// 在 Unity 繪製輔助用的圖示
    /// 線條 射線 圓形 方形 扇形 圖片
    /// <summary>

    private void OnDrawGizmos()
    {
        // 1. 決定圖示顏色
        Gizmos.color = new Color(1, 0f, 0.1f, 0.3f);
        // 2. 決定繪製圖形
        // transform.position 此物件的世界座標
        // transform.TransformDirection() 根據變形元件的區域座標轉換為世界座標
        Gizmos.DrawSphere(transform.position +transform.TransformDirection(ckeakGroundOffset), cheakGroundRadius);
    }
    

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    

    /// <summary>
    ///  Upate 約 60 秒 FPS
    ///  固定更新約 50 FPS
    ///  處理物理行為
    /// </summary>
    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Flip();
        CheckGround();
        Jump();
        fast();
    }
    #endregion

    #region 方法

    /// <summary>
    /// 1.玩家是否有按移動按鍵 左右方向鍵 或 A、D
    /// 處理物理行為
    /// <summary>
    private void Move()
    {
        // h 值 指定為 輸入.取得軸向(水平軸) - 水平軸代表左右鍵與 AD
        float h = Input.GetAxis("Horizontal");
        //print("玩家左右按鍵值:" + h);
        //剛體元件.加速度 = 新 二維向量(h 值 * 移動速度, 剛體.加速度.垂直);
        rig.velocity = new Vector2(h * speed, rig.velocity.y);
        // 當 水平值 不等於零 勾選 跑步參數
        ani.SetBool(parameterWalk, h != 0);
    }
    

    /// <summary>
    /// 翻面
    /// h 值 小於 左:角度 Y 180
    /// h 值 大於 右:角度 X 0
    /// </summary>
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");
        // 如果 h 值 小於 左:角度 Y 180
        if (h < 0 )
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        // 如果  h 值 大於 右:角度 X 0
        else if (h > 0 )
        {
            transform.eulerAngles = Vector3.zero;
        }
       
        
    }
    /// <summary>
    ///  檢查是否在地板
    /// </summary>
    private void CheckGround()
    {
        // 碰撞資訊 = 2D 物理.覆蓋圓形(中心點，半徑，圖層)
        Collider2D hit =  Physics2D.OverlapCircle(transform.position + transform.TransformDirection(ckeakGroundOffset), cheakGroundRadius, canJumpLayer);
        // print("碰到物件的名稱 : " + hit.name);
        isGround = hit;
        // 當 不在地板上 勾選
        ani.SetBool(parameterJump, !isGround);
    }
    private void Jump()
    {
        // 如果 在底板上 並且 按下指定按鍵(空白鍵)
        if (isGround && Input.GetKeyDown(keyjump))
        {
            // 剛體.添加推力(二為向量)
            rig.AddForce(new Vector2(0, jump));
        }
    }
    // 加速
    private void fast()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15;
        }
        else
        {
            speed = 10;
        }
        
    }

    #endregion
}

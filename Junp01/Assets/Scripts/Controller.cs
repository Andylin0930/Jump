using UnityEngine;

/// <summary>
/// 控制器 : 2D橫向卷軸版本
/// <summary>

public class Controller : MonoBehaviour
{
    #region
    [Header("移動速度"), Range(0, 500)]
    public float speed = 3.5f;
    [Header("跳躍高度"), Range(0, 1500)]
    public float jump = 300;

    /// <summary>
    /// 剛體元件
    /// <summary>
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    #endregion

    /// <summary>
    ///  Upate 約 60 秒 FPS
    ///  固定更新約 50 FPS
    ///  處理物理行為
    /// </summary>
    private void FixedUpdate()
    {
        Move();
    }

    #region 方法

    /// <summary>
    /// 1.玩家是否有按移動按鍵 左右方向鍵 或 A、D
    /// 處理物理行為
    /// <summary>
    private void Move()
    {
        // h 值 指定為 輸入.取得軸向(水平軸) - 水平軸代表左右鍵與 AD
        float h = Input.GetAxis("Horizontal");
        print("玩家左右按鍵值:" + h);
    }
    #endregion
}

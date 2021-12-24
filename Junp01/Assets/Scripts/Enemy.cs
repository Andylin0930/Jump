using UnityEngine;

/// <summary>
/// 敵人行為
/// 檢測目標物件是否再追蹤區域
/// 追蹤與攻擊目標
/// </summary>
public class Enemy : MonoBehaviour
{
    #region 欄位
    [Header("檢查追蹤區域大小與位移")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrackOffset;
    [Header("移動速度")]
    public float speed = 1.5f;
    [Header("目標圖層")]
    public LayerMask layerTraget;
    [Header("動畫參數")]
    public string parameterWalk = "跑步";
    [Header("面相目標物件")]
    public Transform target;

    private float angle = 0;
    private Rigidbody2D rig;
    private Animator ani;
    #endregion



    #region 事件
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    private void OnDrawGizmos()
    {
        // 指定圖示的顏色
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        // 繪製立方體(中心，尺寸)
        Gizmos.DrawCube(transform.position +transform.TransformDirection (v3TrackOffset), v3TrackSize);
    }

    private void Update()
    {
        CheakTargetArea();
    }
    #endregion

    #region 方法
    /// <summary>
    /// 檢查目標是否有在範圍內
    /// </summary>
    private void CheakTargetArea()
    {
        // 2D 物理.覆蓋盒形(中心，尺寸，角度)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize, 0, layerTraget);
        if (hit) Move();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // 三元運算子語法 : 布林值 ? 當布林值 為 true : 當布林值 為 false
        // 如果 目標的 X 小於 敵人的 X 就代表在左邊 角度 0
        // 如果 目標的 X 大於 敵人的 X 就代表在右邊 角度 180
        if(target.position.x > transform.position.x)
        {
            // 右邊 angle = 180
        }
        if (target.position.x < transform.position.x)
        {
            // 左邊 angle = 0
        }
        angle = target.position.x > transform.position.x ? 180 : 0;

        transform.eulerAngles = Vector3.up * angle;

        rig.velocity =transform.TransformDirection(new Vector2(-speed, rig.velocity.y));

        ani.SetBool(parameterWalk, true);

        // 距離 = 三圍向量.距離(A點，B點)
        float distance = Vector3.Distance(target.position, transform.position);
        print("與目標的距離 : " + distance);

    }
    #endregion

    
    
}

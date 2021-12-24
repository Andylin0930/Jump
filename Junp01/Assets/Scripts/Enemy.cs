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
    #endregion

    #region 事件
    private void OnDrawGizmos()
    {
        // 指定圖示的顏色
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        // 繪製立方體(中心，尺寸)
        Gizmos.DrawCube(transform.position +transform.TransformDirection (v3TrackOffset), v3TrackSize);
    }
    #endregion

    #region 方法
    /// <summary>
    /// 檢查目標是否有在範圍內
    /// </summary>
    private void CheakTargetArea()
    {
        // 2D 物理.覆蓋盒形(中心，尺寸，角度)
        Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize, 0);
    }
    #endregion

}

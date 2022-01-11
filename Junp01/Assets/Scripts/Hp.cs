using UnityEngine;

public class Hp : MonoBehaviour
{
    [Header("回復血量"), Range(0, -100)]
    public float health = -20;
    public Vector3 v3HealthSize = Vector3.one;
    public Vector3 v3HealthOffset;
    [Header("目標圖層")]
    public LayerMask layerTraget;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.3f);
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3HealthOffset), v3HealthSize);
    }

    public void Health()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3HealthOffset), v3HealthSize, 0, layerTraget);
        print("攻擊到物件 : " + hit.name);
        Destroy(gameObject);
    }
}

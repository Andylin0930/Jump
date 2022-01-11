using UnityEngine;

public class Hp : MonoBehaviour
{
    [Header("�^�_��q"), Range(0, -100)]
    public float health = -20;
    public Vector3 v3HealthSize = Vector3.one;
    public Vector3 v3HealthOffset;
    [Header("�ؼйϼh")]
    public LayerMask layerTraget;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.3f);
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3HealthOffset), v3HealthSize);
    }

    public void Health()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3HealthOffset), v3HealthSize, 0, layerTraget);
        print("�����쪫�� : " + hit.name);
        Destroy(gameObject);
    }
}

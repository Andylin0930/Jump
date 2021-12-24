using UnityEngine;

/// <summary>
/// �ĤH�欰
/// �˴��ؼЪ���O�_�A�l�ܰϰ�
/// �l�ܻP�����ؼ�
/// </summary>
public class Enemy : MonoBehaviour
{
    #region ���
    [Header("�ˬd�l�ܰϰ�j�p�P�첾")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrackOffset;
    [Header("���ʳt��")]
    public float speed = 1.5f;
    [Header("�ؼйϼh")]
    public LayerMask layerTraget;
    [Header("�ʵe�Ѽ�")]
    public string parameterWalk = "�]�B";
    [Header("���ۥؼЪ���")]
    public Transform target;

    private float angle = 0;
    private Rigidbody2D rig;
    private Animator ani;
    #endregion



    #region �ƥ�
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    private void OnDrawGizmos()
    {
        // ���w�ϥܪ��C��
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        // ø�s�ߤ���(���ߡA�ؤo)
        Gizmos.DrawCube(transform.position +transform.TransformDirection (v3TrackOffset), v3TrackSize);
    }

    private void Update()
    {
        CheakTargetArea();
    }
    #endregion

    #region ��k
    /// <summary>
    /// �ˬd�ؼЬO�_���b�d��
    /// </summary>
    private void CheakTargetArea()
    {
        // 2D ���z.�л\����(���ߡA�ؤo�A����)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize, 0, layerTraget);
        if (hit) Move();
    }

    /// <summary>
    /// ����
    /// </summary>
    private void Move()
    {
        // �T���B��l�y�k : ���L�� ? ���L�� �� true : ���L�� �� false
        // �p�G �ؼЪ� X �p�� �ĤH�� X �N�N��b���� ���� 0
        // �p�G �ؼЪ� X �j�� �ĤH�� X �N�N��b�k�� ���� 180
        if(target.position.x > transform.position.x)
        {
            // �k�� angle = 180
        }
        if (target.position.x < transform.position.x)
        {
            // ���� angle = 0
        }
        angle = target.position.x > transform.position.x ? 180 : 0;

        transform.eulerAngles = Vector3.up * angle;

        rig.velocity =transform.TransformDirection(new Vector2(-speed, rig.velocity.y));

        ani.SetBool(parameterWalk, true);

        // �Z�� = �T��V�q.�Z��(A�I�AB�I)
        float distance = Vector3.Distance(target.position, transform.position);
        print("�P�ؼЪ��Z�� : " + distance);

    }
    #endregion

    
    
}

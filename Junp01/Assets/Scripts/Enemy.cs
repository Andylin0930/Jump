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
    public string parameterAttack = "����";
    [Header("���ۥؼЪ���")]
    public Transform target;
    [Header("�����Z��"), Range(0, 5)]
    public float attackDistance = 2.8f;
    [Header("�����N�o�ɶ�"), Range(0, 10)]
    public float attackCD = 2.8f;
    public Vector3 v3AttackSize = Vector3.one;
    public Vector3 v3AttackOffset;

    private float angle = 0;
    private Rigidbody2D rig;
    private Animator ani;
    private float timerAttack;
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

        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3AttackOffset), v3AttackSize);
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
    #region �ϥΧP�_�� if �P�T���B��l�����
    {
        // �T���B��l�y�k : ���L�� ? ���L�� �� true : ���L�� �� false
        // �p�G �ؼЪ� X �p�� �ĤH�� X �N�N��b���� ���� 0
        // �p�G �ؼЪ� X �j�� �ĤH�� X �N�N��b�k�� ���� 180
        if (target.position.x > transform.position.x)
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
        //print("�P�ؼЪ��Z�� : " + distance);
        #endregion
        if (distance <= attackDistance)     // �p�G �Z�� �p�󵥩� �����Z��
        {
            rig.velocity = Vector3.zero;   // ����
            Attack();
        }
 
        }
    /// <summary>
    /// ����
    /// </summary>
    private void Attack()
    {
        if (timerAttack < attackCD)         // �p�G �p�ɾ� �p�� �N�o�ɶ�
        {
            timerAttack += Time.deltaTime;  // �ɶ��֥[ Time.deltaTime �@�w���ɶ�
        }
        else
        {
            ani.SetTrigger(parameterAttack); // �p�G �p�ɾ� �j�󵥩� �N�o�ɶ� �N ����
            timerAttack = 0;                 // �p�ɾ� �k�s
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3AttackOffset), v3AttackSize, 0, layerTraget);
            print("�����쪫�� : " + hit.name);
        }
    }
    #endregion



}

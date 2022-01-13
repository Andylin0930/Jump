using UnityEngine;

/// <summary>
/// ��� : 2D��V���b����
/// <summary>

public class Controller : MonoBehaviour
{
    #region ��� : ���}
    [Header("���ʳt��"), Range(0, 500)]
    public float speed = 10.5f;
    [Header("���D����"), Range(0, 1500)]
    public float jump = 300;
    [Header("�ˬd�a�O�P�첾")]
    [Range(0, 1)]
    public float cheakGroundRadius = 0.1f;
    public Vector3 ckeakGroundOffset;
    [Header("���D����P�i���D�ϼh")]
    public KeyCode keyjump = KeyCode.Space;
    public LayerMask canJumpLayer;
    [Header("�ʵe�Ѽ�: �����P���D")]
    public string parameterWalk = "�]�B";
    public string parameterJump = "���D";

    #endregion

    #region ��� : �p�H
    private Animator ani;
    /// <summary>
    /// ���餸��
    /// <summary>
    private Rigidbody2D rig;
    [SerializeField]
    /// <summary>
    /// �O�_�b���O�W
    /// <summary>
    private bool isGround;
    #endregion

    #region �ƥ�
    /// <summary>
    /// ø�s�ϥ�
    /// �b Unity ø�s���U�Ϊ��ϥ�
    /// �u�� �g�u ��� ��� ���� �Ϥ�
    /// <summary>

    private void OnDrawGizmos()
    {
        // 1. �M�w�ϥ��C��
        Gizmos.color = new Color(1, 0f, 0.1f, 0.3f);
        // 2. �M�wø�s�ϧ�
        // transform.position �����󪺥@�ɮy��
        // transform.TransformDirection() �ھ��ܧΤ��󪺰ϰ�y���ഫ���@�ɮy��
        Gizmos.DrawSphere(transform.position +transform.TransformDirection(ckeakGroundOffset), cheakGroundRadius);
    }
    

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    

    /// <summary>
    ///  Upate �� 60 �� FPS
    ///  �T�w��s�� 50 FPS
    ///  �B�z���z�欰
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

    #region ��k

    /// <summary>
    /// 1.���a�O�_�������ʫ��� ���k��V�� �� A�BD
    /// �B�z���z�欰
    /// <summary>
    private void Move()
    {
        // h �� ���w�� ��J.���o�b�V(�����b) - �����b�N���k��P AD
        float h = Input.GetAxis("Horizontal");
        //print("���a���k�����:" + h);
        //���餸��.�[�t�� = �s �G���V�q(h �� * ���ʳt��, ����.�[�t��.����);
        rig.velocity = new Vector2(h * speed, rig.velocity.y);
        // �� ������ ������s �Ŀ� �]�B�Ѽ�
        ani.SetBool(parameterWalk, h != 0);
    }
    

    /// <summary>
    /// ½��
    /// h �� �p�� ��:���� Y 180
    /// h �� �j�� �k:���� X 0
    /// </summary>
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");
        // �p�G h �� �p�� ��:���� Y 180
        if (h < 0 )
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        // �p�G  h �� �j�� �k:���� X 0
        else if (h > 0 )
        {
            transform.eulerAngles = Vector3.zero;
        }
       
        
    }
    /// <summary>
    ///  �ˬd�O�_�b�a�O
    /// </summary>
    private void CheckGround()
    {
        // �I����T = 2D ���z.�л\���(�����I�A�b�|�A�ϼh)
        Collider2D hit =  Physics2D.OverlapCircle(transform.position + transform.TransformDirection(ckeakGroundOffset), cheakGroundRadius, canJumpLayer);
        // print("�I�쪫�󪺦W�� : " + hit.name);
        isGround = hit;
        // �� ���b�a�O�W �Ŀ�
        ani.SetBool(parameterJump, !isGround);
    }
    private void Jump()
    {
        // �p�G �b���O�W �åB ���U���w����(�ť���)
        if (isGround && Input.GetKeyDown(keyjump))
        {
            // ����.�K�[���O(�G���V�q)
            rig.AddForce(new Vector2(0, jump));
        }
    }
    // �[�t
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

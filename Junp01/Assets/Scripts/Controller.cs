using UnityEngine;

/// <summary>
/// ��� : 2D��V���b����
/// <summary>

public class Controller : MonoBehaviour
{
    #region
    [Header("���ʳt��"), Range(0, 500)]
    public float speed = 3.5f;
    [Header("���D����"), Range(0, 1500)]
    public float jump = 300;

    /// <summary>
    /// ���餸��
    /// <summary>
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    #endregion

    /// <summary>
    ///  Upate �� 60 �� FPS
    ///  �T�w��s�� 50 FPS
    ///  �B�z���z�欰
    /// </summary>
    private void FixedUpdate()
    {
        Move();
    }

    #region ��k

    /// <summary>
    /// 1.���a�O�_�������ʫ��� ���k��V�� �� A�BD
    /// �B�z���z�欰
    /// <summary>
    private void Move()
    {
        // h �� ���w�� ��J.���o�b�V(�����b) - �����b�N���k��P AD
        float h = Input.GetAxis("Horizontal");
        print("���a���k�����:" + h);
    }
    #endregion
}

using UnityEngine;

// �إ߱M�פ������(menuName = "���W��") ��Ƨ�/�l���
[CreateAssetMenu(menuName = "Andy/��Ƥ��e")]
/// <summary>
/// ��ܸ��
/// �O�s npc �n�򪱮a������ܤ��e
/// <summary>
///  Scriptable Object �}���e���� : �N�{������x�s�� Project �������� 
public class DataDialogue : ScriptableObject
{
    // Text Area (�̤p��� �A �̤j���) - �ȭ� String
    [Header("��ܤ��e"), TextArea(3, 5)]
    public string[] dialogues;
}

using UnityEditor.Animations;
using UnityEngine;

public class CharactorRoot : MonoBehaviour
{
    [SerializeField] private Player[] player;
    [SerializeField] private MeshRenderer[] meshrenderer;

    private int childCount;
    public int ChildCount { get => childCount; }    

    public void OnStart()
    {
        childCount = transform.childCount;

        //�v���C���[�̕\�����폜
        for (int i = 0; i < childCount; i++)
        {
            meshrenderer[i].enabled = false;
        }
    }

    /// <summary>
    /// DontDestroy�ɏグ��
    /// </summary>
    public void OnDontDestroyScene()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ActivateSelectPlayer(int _num)
    {
        meshrenderer[_num].enabled = true;
    }

    public void InActivateSelectPlayer(int _num)
    {
        meshrenderer[_num].enabled = false;
    }

    public void InitilizePlayerStartPosition()
    {
        for(int i = 0; i < childCount; i++)
        {
            Transform trans = player[i].transform;
            Transform parentTrans = trans.parent;
            parentTrans.position = Vector3.zero;
            parentTrans.rotation = Quaternion.identity;
            player[i].StartPosition();
        }
    }

    /// <summary>
    /// �ԍ��̃v���C���[���I������Ă��邩
    /// </summary>
    /// <param name="_num"></param>
    /// <returns></returns>
    public bool GetIsDecision(int _num)
    {
        return player[_num].IsDecidion;
    }

    public void SetIsDecidion(int _num, bool _value)
    {
        player[_num].IsDecidion = _value;
    }
}

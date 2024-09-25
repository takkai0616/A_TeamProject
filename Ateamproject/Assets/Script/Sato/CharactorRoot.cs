using UnityEngine;
using UnityEngine.SceneManagement;

public class CharactorRoot : MonoBehaviour
{
    [SerializeField] private Player[] player;
    [SerializeField] private MeshRenderer[] meshrenderer;

    private int childCount;
    public int ChildCount { get => childCount; }

    public void OnStart()
    {
        childCount = transform.childCount;

        //プレイヤーの表示を削除
        for (int i = 0; i < childCount; i++)
        {
            meshrenderer[i].enabled = false;
        }
    }

    /// <summary>
    /// DontDestroyに上げる
    /// </summary>
    public void OnDontDestroyScene()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OnActiceScene()
    {
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
    }

    public void Animation(int _num)
    {
        Transform _parentTrans = player[_num].transform.parent;
        PlayerAnimation _playerAnimation = _parentTrans.GetComponent<PlayerAnimation>();
        _playerAnimation.PlayMotion();
    }

    public void SetActiveAnimation(int _num, bool _active)
    {
        Transform _parentTrans = player[_num].transform.parent;
        PlayerAnimation _playerAnimation = _parentTrans.GetComponent<PlayerAnimation>();
        _playerAnimation.enabled = _active;
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
            trans.localRotation = Quaternion.identity;
            Transform parentTrans = trans.parent;
            parentTrans.position = Vector3.zero;
            parentTrans.rotation = Quaternion.identity;
            player[i].StartPosition();
        }
    }

    /// <summary>
    /// リザルトシーンに移動したときにプレイヤーの位置を変更
    /// </summary>
    public void SetResultPosition()
    {        
        Vector3 outOfScreen = new Vector3(0.0f, 50.0f, 0.0f);
        for (int i = 0; i < childCount; i++)
        {
            player[i].Start = false;
            Transform trans = player[i].transform;
            trans.position = outOfScreen;
        }
    }

    /// <summary>
    /// 番号のプレイヤーが選択されているか
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

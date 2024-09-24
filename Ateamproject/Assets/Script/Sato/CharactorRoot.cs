using UnityEngine;

public class CharactorRoot : MonoBehaviour
{
    [SerializeField] private Player[] player;
    [SerializeField] private MeshRenderer[] meshrenderer;  
    private int childCount;
    public int ChildCount { get => childCount; }    
    private int numberingCharaCount;//番付をされたキャラの数をカウント
    
    public void OnStart()
    {
        childCount = transform.childCount;
        numberingCharaCount = 0;       
    } 

    public void OnDontDestroyScene()
    {
        DontDestroyOnLoad(gameObject);
    }   

    /// <summary>
    /// キャラクターの位置と回転を初期化
    /// </summary>
    public void InitializationChildTrans()
    {
        for (int i = 0; i < childCount; i++)
        { 
            Transform trans = player[i].transform;
            trans.position = Vector3.zero;
            trans.rotation = Quaternion.identity;
        }
    }

    public int GetCharactorNum()
    {
        int num = numberingCharaCount;
        ActivateSelectPlayer(num);
        numberingCharaCount++;
        return num;
    }

    public void ActivateSelectPlayer(int _value)
    {
        meshrenderer[_value].enabled = true;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [Header("キャラクターの初期位置を設定してください"),SerializeField]
    Vector3[] initialPos;

    GameObject charactorParent;//キャラクターの親
    Transform[] charactorTrans;

    void Start()
    {
        charactorParent = GameObject.Find("Charactors");//キャラクターのオブジェクト取得
        SceneManager.MoveGameObjectToScene(charactorParent, SceneManager.GetActiveScene());//DontDestroyからSceneへ移動

        Transform parentTrans = charactorParent.transform;

        for (int i = 0; i < parentTrans.childCount; ++i)
        {
            parentTrans.GetChild(i).transform.position = initialPos[i];
        }

    }
    
    void Update()
    {
        
    }
}

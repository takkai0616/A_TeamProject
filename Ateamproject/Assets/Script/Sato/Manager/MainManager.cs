using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sato
{
    public class MainManager : MonoBehaviour
    {
        [Header("キャラクターの初期位置を設定してください"), SerializeField]
        Vector2Int[] initialPos;

        GameObject charactorParent;//キャラクターの親
        Transform[] charactorTrans;

        void Start()
        {
            charactorParent = GameObject.Find("Charactors");//キャラクターのオブジェクト取得
            SceneManager.MoveGameObjectToScene(charactorParent, SceneManager.GetActiveScene());//DontDestroyからSceneへ移動

            Transform parentTrans = charactorParent.transform;

            for (int i = 0; i < parentTrans.childCount; ++i)
            {
                //ステージの大きさにあった位置に調整するまでコメントアウト

                //initialPos[0] = new Vector2Int(0, 0);
                //initialPos[1] = new Vector2Int(stageManager.StageSizeX - 1, 0);
                //initialPos[2] = new Vector2Int(0, stageManager.StageSizeY - 1);
                //initialPos[3] = new Vector2Int(stageManager.StageSizeX - 1, stageManager.StageSizeY - 1);

                parentTrans.GetChild(i).transform.position =
                    new Vector3(initialPos[i].x,
                                parentTrans.GetChild(i).transform.position.y,
                                initialPos[i].y);
            }

        }

        void Update()
        {

        }
    }
}
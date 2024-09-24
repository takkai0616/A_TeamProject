using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sato
{
    public class MainManager : MonoBehaviour
    {
        [Header("�L�����N�^�[�̏����ʒu��ݒ肵�Ă�������"), SerializeField]
        Vector2Int[] initialPos;

        GameObject charactorParent;//�L�����N�^�[�̐e
        Transform[] charactorTrans;

        void Start()
        {
            charactorParent = GameObject.Find("Charactors");//�L�����N�^�[�̃I�u�W�F�N�g�擾
            SceneManager.MoveGameObjectToScene(charactorParent, SceneManager.GetActiveScene());//DontDestroy����Scene�ֈړ�

            Transform parentTrans = charactorParent.transform;

            for (int i = 0; i < parentTrans.childCount; ++i)
            {
                //�X�e�[�W�̑傫���ɂ������ʒu�ɒ�������܂ŃR�����g�A�E�g

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
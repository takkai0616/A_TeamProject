using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [Header("�L�����N�^�[�̏����ʒu��ݒ肵�Ă�������"),SerializeField]
    Vector3[] initialPos;

    GameObject charactorParent;//�L�����N�^�[�̐e
    Transform[] charactorTrans;

    void Start()
    {
        charactorParent = GameObject.Find("Charactors");//�L�����N�^�[�̃I�u�W�F�N�g�擾
        SceneManager.MoveGameObjectToScene(charactorParent, SceneManager.GetActiveScene());//DontDestroy����Scene�ֈړ�

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

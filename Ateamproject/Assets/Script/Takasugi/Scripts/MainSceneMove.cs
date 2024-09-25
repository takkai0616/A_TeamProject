using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// �^�C�g����ʂ̐i�s�𐧌䂵�܂��B
public class MainSceneMove: MonoBehaviour
{
    private bool isLoadable = false;// ���̃V�[����ǂݍ��݉\�ȏꍇ��true�A����ȊO��false
    private bool isTimeUp = false;
    private bool isStart = false;
    private TimeCount timeCount;
    [SerializeField] private MultiPlay multiPlay;
    private CharactorRoot charactorRoot;
    GameObject charRootObj;

    private void Start()
    {
        charRootObj = GameObject.Find("Charactors");
        charactorRoot = charRootObj.GetComponent<CharactorRoot>();
        
        isStart = true;
        timeCount = GetComponent<TimeCount>();
        
    }

    // �Q�b�ҋ@��Ɏ��̃V�[����Ǎ��݉\�ɂ��܂��B
    IEnumerator OnStart()
    {
        yield return new WaitForSeconds(2);
        isLoadable = true;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            StartCoroutine(OnStart());
        }

        if (timeCount.InGameTime() <= 0)
        {
            isTimeUp = true;
        }

        if (isLoadable|| isTimeUp)
        {
            SceneManager.LoadScene("ResultScene");
        }

        if (multiPlay.IsFinish)
        {
            SceneManager.LoadScene("Result3PScene");
        }
    }
}

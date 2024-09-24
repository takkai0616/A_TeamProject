using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// �^�C�g����ʂ̐i�s�𐧌䂵�܂��B
public class MainSceneMove: MonoBehaviour
{

    // ���̃V�[����ǂݍ��݉\�ȏꍇ��true�A����ȊO��false
    private bool isLoadable = false;

    private bool isTimeUp = false;

    public bool isStart = false;

    private TimeCount timeCount;

    private void Start()
    {
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
    }
}

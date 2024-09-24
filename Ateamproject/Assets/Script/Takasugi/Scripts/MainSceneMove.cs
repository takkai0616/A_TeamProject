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
    private GameObject charactorObject;
    private Transform charactorTrans;
    private Player[] players;



    private void Start()
    {
        charactorObject = GameObject.Find("Charactors");
        charactorTrans = charactorObject.GetComponent<Transform>();
        players = new Player[charactorTrans.childCount];
        for (int i = 0; i < charactorTrans.childCount; i++)
        {
            Transform child = charactorTrans.GetChild(i);
            players[i] = child.GetComponent<Player>();
        }
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

using UnityEngine;
using UnityEngine.InputSystem;

public class MultiPlay : MonoBehaviour
{
    private GameObject charactorObject;
    private Player[] players;
    private Transform charactorTrans;
    private int playerCount;
    public bool IsFinish { get; private set; }

    void Start()
    {
        playerCount = Gamepad.all.Count;
        charactorObject = GameObject.Find("Charactors");
        CharactorRoot charactorRoot =  charactorObject.GetComponent<CharactorRoot>();
        charactorRoot.InitilizePlayerStartPosition();
        charactorTrans = charactorObject.GetComponent<Transform>();
        players = new Player[charactorTrans.childCount];
        for (int i = 0; i < charactorTrans.childCount; i++)
        {
            Transform child = charactorTrans.GetChild(i);
            Transform grandChild = child.GetChild(0);
            players[i] = grandChild.GetComponent<Player>();
            players[i].OnStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        IsFinish = players[0].Finish;

        for (int i = 0; i < playerCount; ++i)
        {
            var leftStickValue = Gamepad.all[i].leftStick.ReadValue();

            if (leftStickValue.x == 0 && leftStickValue.y == 0) continue;

            if (Mathf.Abs(leftStickValue.x) < Mathf.Abs(leftStickValue.y))
            {
                leftStickValue.x = 0;
                leftStickValue.y /= Mathf.Abs(leftStickValue.y);
            }
            else
            {
                leftStickValue.x /= Mathf.Abs(leftStickValue.x);
                leftStickValue.y = 0;
            }

            players[CommonData.useCharactorNum[i]].PlayerMove(leftStickValue.x, leftStickValue.y);
        }
    }
}

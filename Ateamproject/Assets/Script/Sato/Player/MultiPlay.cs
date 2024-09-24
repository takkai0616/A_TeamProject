using UnityEngine;
using UnityEngine.InputSystem;

public class MultiPlay : MonoBehaviour
{
    [SerializeField] Player[] player;

    int playerCount;
    void Start()
    {
        playerCount = Gamepad.all.Count;
    }

    // Update is called once per frame
    void Update()
    {
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

            player[CommonData.useCharactorNum[i]].PlayerMove(leftStickValue.x, leftStickValue.y);
        }
    }
}

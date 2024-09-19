using UnityEngine;
using UnityEngine.InputSystem;

public class MultiPlay : MonoBehaviour
{
    [SerializeField] Player[] player;

    int playerCount;

    bool[] isRotate;
 
    void Start()
    {
        playerCount = 4;
        isRotate = new bool[playerCount];

        for(int i = 0; i < playerCount; ++i)
        {
            isRotate[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < playerCount; ++i)
        {
            if (Gamepad.all.Count == i) break;

            var leftStickValue = Gamepad.all[i].leftStick.ReadValue();
           
            if (leftStickValue == Vector2.zero)
            {
                isRotate[i] = false;
                continue;
            }

            if (leftStickValue == Vector2.zero) return;

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

            player[i].PlayerMove(leftStickValue.x, leftStickValue.y);
        }
    }
}

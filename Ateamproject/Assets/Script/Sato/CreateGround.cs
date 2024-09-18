using UnityEngine;

public class CreateGround : MonoBehaviour
{
    [SerializeField] GameObject bCube;
    [SerializeField] GameObject wCube;
    [SerializeField] Transform cubeParent;
    [SerializeField] int mapSize;

    bool whiteFlag;

    bool startColorWhite;

    void Start()
    {
        whiteFlag = false;

        for (int i = 0; i < mapSize; i++)
        {
            if (startColorWhite)
            {
                startColorWhite = false;
                whiteFlag = true;
            }
            else
            {
                startColorWhite = true;
                whiteFlag = false;
            }

            for (int j = 0; j < mapSize; j++)
            {
                if (whiteFlag)
                {
                    Instantiate(wCube,new Vector3(i,0,j), Quaternion.identity, cubeParent);
                    whiteFlag = false;
                }
                else
                {
                    Instantiate(bCube, new Vector3(i, 0, j), Quaternion.identity, cubeParent);
                    whiteFlag =true;
                }
            }
        }
    }
}

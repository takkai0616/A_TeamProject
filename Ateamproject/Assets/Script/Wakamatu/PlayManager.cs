using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] Player[] player;
    public bool[][] moob;

    int playerCount;
    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0;i < 6; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                for (int k = 0; k < playerCount; ++k)
                {
                    if (player[k].stagemanager[i][j])
                    {
                        moob[i][j] = true;
                    }
                    else
                    {
                        moob[i][j] = false;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                for (int k = 0; k < playerCount; ++k)
                {
                    if (player[k].stagemanager[i][j])
                    {
                        moob[i][j] = true;
                    }
                    else
                    {
                        moob[i][j] = false;
                    }
                }
            }
        }
    }
}

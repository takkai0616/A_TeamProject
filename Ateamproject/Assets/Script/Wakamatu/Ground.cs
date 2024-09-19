using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject GroundB; // 生成するオブジェクトのプレハブ
    public GameObject GroundW; // 生成するオブジェクトのプレハブ
    public Vector3 AreaMin = new Vector3(0.0f, 0.0f, 0.0f); // 最小値
    public Vector3 AreaMax = new Vector3(12.0f, 0.0f, 12.0f);   // 最大値
    private int press_count;

    void Update()
    {
        // スペースキーを押すと新しいオブジェクトを生成
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ランダムな位置を計算
            Vector3 randomPosition = new Vector3(
                Random.Range(AreaMin.x, AreaMax.x),
                Random.Range(AreaMin.y, AreaMax.y),
                Random.Range(AreaMin.z, AreaMax.z)
            );

            // Instantiate関数を使用してオブジェクトを生成
            GameObject newObject = Instantiate(GroundB, randomPosition, transform.rotation);
            press_count++; // スペースキーが押された回数をカウントアップ
            Debug.Log("Space key has been pressed " + press_count + " times.");
            Debug.Log("Random Position: " + randomPosition);
        }
    }
}

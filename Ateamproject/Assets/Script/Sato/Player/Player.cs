using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] PlayManager moob;
    [SerializeField]
    private CollisionChecker wallChecker_Right = null;
    [SerializeField]
    private CollisionChecker wallChecker_Left = null;
    [SerializeField]
    private CollisionChecker wallChecker_Up = null;
    [SerializeField]
    private CollisionChecker wallChecker_Down = null;
    [SerializeField]
    private CollisionChecker wallChecker_Top = null;
    [SerializeField]
    public float rotationPeriod = 0.3f;     // 隣に移動するのにかかる時間
    [SerializeField]
    public float sideLength = 1f;           // Cubeの辺の長さ

    bool isRotate = false;                  // Cubeが回転中かどうかを検出するフラグ
    float directionX = 0;                   // 回転方向フラグ
    float directionZ = 0;                   // 回転方向フラグ

    Vector3 startPos;                       // 回転前のCubeの位置
    float rotationTime = 0;                 // 回転中の時間経過
    float radius;                           // 重心の軌道半径
    Quaternion fromRotation;                // 回転前のCubeのクォータニオン
    Quaternion toRotation;                  // 回転後のCubeのクォータニオン

    public bool[][] stagemanager;

    bool finish = false;

    bool ismoob;

    // Use this for initialization
    void Start()
    {

        ismoob = true;
        // 重心の回転軌道半径を計算
        radius = sideLength * Mathf.Sqrt(2f) / 2f;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                stagemanager[i][j] = false;
            }
        }
    }

    // Update is called once per frame
    public void PlayerMove(float x, float y)
    {
        //var leftStickValue = Gamepad.all[0].leftStick.ReadValue();

        if (wallChecker_Up.IsCasted && y > 0)
        {
            y = 0;
        }
        if (wallChecker_Down.IsCasted && y < 0)
        {
            y = 0;
        }
        if (wallChecker_Left.IsCasted && x < 0)
        {
            x = 0;
        }
        if (wallChecker_Right.IsCasted && x > 0)
        {
            x = 0;
        }
        if (wallChecker_Top.IsCasted)
        {
            x = 0;
            y = 0;
            finish = true;
        }
        if ((x != 0 || y != 0) && !isRotate)
        {
            int intposx = (int)transform.position.x / 2;
            int intposz = (int)transform.position.z / 2 * -1;
            int intx = (int)x;
            int inty = (int)y * -1;
            stagemanager[intposx][intposz] = true;
            if (moob.moob[intposx + intx][intposz + inty])
            {
                ismoob = false;
            }
            else
            {
                stagemanager[intposx + intx][intposz + inty] = true;
                stagemanager[intposx][intposz] = false;
            }
        }
            // キー入力がある　かつ　Cubeが回転中でない場合、Cubeを回転する。
            if ((x != 0 || y != 0) && !isRotate && ismoob )
        {
            directionX = -x;                                                             // 回転方向セット (x,yどちらかは必ず0)
            directionZ = y;                                                             // 回転方向セット (x,yどちらかは必ず0)
            startPos = transform.position;                                              // 回転前の座標を保持
            fromRotation = transform.rotation;                                          // 回転前のクォータニオンを保持
            transform.Rotate(directionZ * 90, 0, directionX * 90, Space.World);     // 回転方向に90度回転させる
            toRotation = transform.rotation;                                            // 回転後のクォータニオンを保持
            transform.rotation = fromRotation;                                          // CubeのRotationを回転前に戻す。（transformのシャローコピーとかできないんだろうか…。）
            rotationTime = 0;                                                           // 回転中の経過時間を0に。
            isRotate = true;                                                            // 回転中フラグをたてる。
        }
    }

    void FixedUpdate()
    {

        if (isRotate)
        {
            rotationTime += Time.fixedDeltaTime;                                    // 経過時間を増やす
            float ratio = Mathf.Lerp(0, 1, rotationTime / rotationPeriod);          // 回転の時間に対する今の経過時間の割合

            // 移動
            float thetaRad = Mathf.Lerp(0, Mathf.PI / 2f, ratio);                   // 回転角をラジアンで。
            float distanceX = -directionX * radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));      // X軸の移動距離。 -の符号はキーと移動の向きを合わせるため。
            float distanceY = radius * (Mathf.Sin(45f * Mathf.Deg2Rad + thetaRad) - Mathf.Sin(45f * Mathf.Deg2Rad));                        // Y軸の移動距離
            float distanceZ = directionZ * radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));           // Z軸の移動距離
            transform.position = new Vector3(startPos.x + distanceX, startPos.y + distanceY, startPos.z + distanceZ);                       // 現在の位置をセット

            // 回転
            transform.rotation = Quaternion.Lerp(fromRotation, toRotation, ratio);      // Quaternion.Lerpで現在の回転角をセット

            // 移動・回転終了時に各パラメータを初期化。isRotateフラグを下ろす。
            if (ratio == 1)
            {
                isRotate = false;
                directionX = 0;
                directionZ = 0;
                rotationTime = 0;
                ismoob = true;
            }
        }

        //シーン移動
        if (finish == true)
        {
            SceneManager.LoadScene("rezorutScene");
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //当たり判定指定
    [SerializeField]
    private CollisionChecker CollisionChecker_Right = null;
    [SerializeField]
    private CollisionChecker CollisionChecker_Left = null;
    [SerializeField]
    private CollisionChecker CollisionChecker_Up = null;
    [SerializeField]
    private CollisionChecker CollisionChecker_Down = null;
    [SerializeField]
    private CollisionChecker CollisionChecker_Top = null;
    [SerializeField]
    public float rotationPeriod;     // 隣に移動するのにかかる時間
    [SerializeField]
    public float sideLength;           // Cubeの辺の長さ
    [SerializeField]
    public float intervalSecond;

    //座標指定用
    [SerializeField]
    private float x;
    [SerializeField]
    private float y;
    [SerializeField]
    private float z;

    private int number;
    public int Number { get => number; set => number = value; }

    private bool isDicision;
    public bool IsDecidion { get => isDicision; set => isDicision = value; } //プレイヤーが決まっているか

    private float time;

    private bool isInterval;
    public bool isRotate;                  // Cubeが回転中かどうかを検出するフラグ
    private float directionX = 0;                   // 回転方向フラグ
    private float directionZ = 0;                   // 回転方向フラグ

    private Vector3 startPos;                       // 回転前のCubeの位置
    private float rotationTime;                 // 回転中の時間経過
    private float radius;                           // 重心の軌道半径
    private Quaternion fromRotation;                // 回転前のCubeのクォータニオン
    private Quaternion toRotation;                  // 回転後のCubeのクォータニオン


    public bool finish = false;

    // Use this for initialization
    void Start()
    {
        rotationPeriod = 0.1f;
        sideLength = 1f;
        intervalSecond = 1f;

        isInterval = false;
        rotationTime = 0;

        // 重心の回転軌道半径を計算
        radius = sideLength * Mathf.Sqrt(2f) / 2f;
    }

    // Update is called once per frame
    private void Update()
    {        
        time += Time.deltaTime;
        if (intervalSecond <= time)
        {
            isInterval = true;
        }
    }
    
    public void StartPosition()
    {
        transform.position = new Vector3(x, y, z);
    }

    public void PlayerMove(float x, float y)
    {
        //var leftStickValue = Gamepad.all[0].leftStick.ReadValue();

        if (CollisionChecker_Up.IsCasted && y > 0)
        {
            y = 0;
        }
        if (CollisionChecker_Down.IsCasted && y < 0)
        {
            y = 0;
        }
        if (CollisionChecker_Left.IsCasted && x < 0)
        {
            x = 0;
        }
        if (CollisionChecker_Right.IsCasted && x > 0)
        {
            x = 0;
        }
        if (CollisionChecker_Top.IsCasted)
        {
            x = 0;
            y = 0;
            finish = true;
        }
        // キー入力がある　かつ　Cubeが回転中でない場合、Cubeを回転する。
        if ((x != 0 || y != 0) && !isRotate && isInterval)
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
                isInterval = false;
                isRotate = false;
                directionX = 0;
                directionZ = 0;
                rotationTime = 0;
                time = 0;
            }
        }

        //シーン移動
        if (finish == true)
        {
            SceneManager.LoadScene("rezorutScene");
        }
    }
}
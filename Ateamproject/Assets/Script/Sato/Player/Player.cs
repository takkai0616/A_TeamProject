using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
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
    public float rotationPeriod = 0.3f;     // �ׂɈړ�����̂ɂ����鎞��
    [SerializeField]
    public float sideLength = 1f;           // Cube�̕ӂ̒���
    [SerializeField]
    public float Interval = 1f;

    float time;

    bool inter = false;
    public bool isRotate = false;                  // Cube����]�����ǂ��������o����t���O
    float directionX = 0;                   // ��]�����t���O
    float directionZ = 0;                   // ��]�����t���O

    Vector3 startPos;                       // ��]�O��Cube�̈ʒu
    float rotationTime = 0;                 // ��]���̎��Ԍo��
    float radius;                           // �d�S�̋O�����a
    Quaternion fromRotation;                // ��]�O��Cube�̃N�H�[�^�j�I��
    Quaternion toRotation;                  // ��]���Cube�̃N�H�[�^�j�I��


    bool finish = false;

    // Use this for initialization
    void Start()
    {
        // �d�S�̉�]�O�����a���v�Z
        radius = sideLength * Mathf.Sqrt(2f) / 2f;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (Interval <= time)
        {
            inter = true;
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
        // �L�[���͂�����@���@Cube����]���łȂ��ꍇ�ACube����]����B
        if ((x != 0 || y != 0) && !isRotate && inter)
        {
            directionX = -x;                                                             // ��]�����Z�b�g (x,y�ǂ��炩�͕K��0)
            directionZ = y;                                                             // ��]�����Z�b�g (x,y�ǂ��炩�͕K��0)
            startPos = transform.position;                                              // ��]�O�̍��W��ێ�
            fromRotation = transform.rotation;                                          // ��]�O�̃N�H�[�^�j�I����ێ�
            transform.Rotate(directionZ * 90, 0, directionX * 90, Space.World);     // ��]������90�x��]������
            toRotation = transform.rotation;                                            // ��]��̃N�H�[�^�j�I����ێ�
            transform.rotation = fromRotation;                                          // Cube��Rotation����]�O�ɖ߂��B�itransform�̃V�����[�R�s�[�Ƃ��ł��Ȃ��񂾂낤���c�B�j
            rotationTime = 0;                                                           // ��]���̌o�ߎ��Ԃ�0�ɁB
            isRotate = true;                                                            // ��]���t���O�����Ă�B
        }
    }

    void FixedUpdate()
    {

        if (isRotate)
        {
            rotationTime += Time.fixedDeltaTime;                                    // �o�ߎ��Ԃ𑝂₷
            float ratio = Mathf.Lerp(0, 1, rotationTime / rotationPeriod);          // ��]�̎��Ԃɑ΂��鍡�̌o�ߎ��Ԃ̊���

            // �ړ�
            float thetaRad = Mathf.Lerp(0, Mathf.PI / 2f, ratio);                   // ��]�p�����W�A���ŁB
            float distanceX = -directionX * radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));      // X���̈ړ������B -�̕����̓L�[�ƈړ��̌��������킹�邽�߁B
            float distanceY = radius * (Mathf.Sin(45f * Mathf.Deg2Rad + thetaRad) - Mathf.Sin(45f * Mathf.Deg2Rad));                        // Y���̈ړ�����
            float distanceZ = directionZ * radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));           // Z���̈ړ�����
            transform.position = new Vector3(startPos.x + distanceX, startPos.y + distanceY, startPos.z + distanceZ);                       // ���݂̈ʒu���Z�b�g

            // ��]
            transform.rotation = Quaternion.Lerp(fromRotation, toRotation, ratio);      // Quaternion.Lerp�Ō��݂̉�]�p���Z�b�g

            // �ړ��E��]�I�����Ɋe�p�����[�^���������BisRotate�t���O�����낷�B
            if (ratio == 1)
            {
                inter = false;
                isRotate = false;
                directionX = 0;
                directionZ = 0;
                rotationTime = 0;
                time = 0;
            }
        }

        //�V�[���ړ�
        if (finish == true)
        {
            SceneManager.LoadScene("rezorutScene");
        }
    }
}
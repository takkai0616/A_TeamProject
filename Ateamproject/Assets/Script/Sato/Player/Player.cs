using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //�����蔻��w��
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
    public float rotationPeriod;     // �ׂɈړ�����̂ɂ����鎞��
    [SerializeField]
    public float sideLength;           // Cube�̕ӂ̒���
    [SerializeField]
    public float intervalSecond;

    //���W�w��p
    [SerializeField]
    private float x;
    [SerializeField]
    private float y;
    [SerializeField]
    private float z;

    private int number;
    public int Number { get => number; set => number = value; }

    private bool isDicision;
    public bool IsDecidion { get => isDicision; set => isDicision = value; } //�v���C���[�����܂��Ă��邩

    private float time;

    private bool isInterval;
    public bool isRotate;                  // Cube����]�����ǂ��������o����t���O
    private float directionX = 0;                   // ��]�����t���O
    private float directionZ = 0;                   // ��]�����t���O

    private Vector3 startPos;                       // ��]�O��Cube�̈ʒu
    private float rotationTime;                 // ��]���̎��Ԍo��
    private float radius;                           // �d�S�̋O�����a
    private Quaternion fromRotation;                // ��]�O��Cube�̃N�H�[�^�j�I��
    private Quaternion toRotation;                  // ��]���Cube�̃N�H�[�^�j�I��


    public bool finish = false;

    // Use this for initialization
    void Start()
    {
        rotationPeriod = 0.1f;
        sideLength = 1f;
        intervalSecond = 1f;

        isInterval = false;
        rotationTime = 0;

        // �d�S�̉�]�O�����a���v�Z
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
        // �L�[���͂�����@���@Cube����]���łȂ��ꍇ�ACube����]����B
        if ((x != 0 || y != 0) && !isRotate && isInterval)
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
                isInterval = false;
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
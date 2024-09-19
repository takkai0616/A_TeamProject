using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float rotationPeriod = 0.3f;     // �ׂɈړ�����̂ɂ����鎞��
    public float sideLength = 1f;           // Cube�̕ӂ̒���

    bool isRotate = false;                  // Cube����]�����ǂ��������o����t���O
    float directionX = 0;                   // ��]�����t���O
    float directionZ = 0;                   // ��]�����t���O

    Vector3 startPos;                       // ��]�O��Cube�̈ʒu
    float rotationTime = 0;                 // ��]���̎��Ԍo��
    float radius;                           // �d�S�̋O�����a
    Quaternion fromRotation;                // ��]�O��Cube�̃N�H�[�^�j�I��
    Quaternion toRotation;                  // ��]���Cube�̃N�H�[�^�j�I��

    // Use this for initialization
    void Start()
    {

        // �d�S�̉�]�O�����a���v�Z
        radius = sideLength * Mathf.Sqrt(2f) / 2f;

    }

    private void Update()
    {
        //var leftStickValue = Gamepad.all[0].leftStick.ReadValue();

        //if (leftStickValue == Vector2.zero) return;

        //if (Mathf.Abs(leftStickValue.x) < Mathf.Abs(leftStickValue.y))
        //{
        //    leftStickValue.x = 0;
        //    leftStickValue.y /= Mathf.Abs(leftStickValue.y);
        //}
        //else
        //{
        //    leftStickValue.x /= Mathf.Abs(leftStickValue.x);
        //    leftStickValue.y = 0;
        //}

        //PlayerMove(leftStickValue.x, leftStickValue.y);
    }

    // Update is called once per frame
    public void PlayerMove(float x, float y)
    {
        // �L�[���͂�����@���@Cube����]���łȂ��ꍇ�ACube����]����B
        if ((x != 0 || y != 0) && !isRotate)
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
                isRotate = false;
                directionX = 0;
                directionZ = 0;
                rotationTime = 0;
            }
        }
    }
}
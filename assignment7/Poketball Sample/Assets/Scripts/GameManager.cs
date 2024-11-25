using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIManager MyUIManager;

    public GameObject BallPrefab;   // prefab of Ball

    // Constants for SetupBalls
    public static Vector3 StartPosition = new Vector3(0, 0, -6.35f);
    public static Quaternion StartRotation = Quaternion.Euler(0, 90, 90);
    const float BallRadius = 0.286f;
    const float RowSpacing = 0.02f;

    GameObject PlayerBall;
    GameObject CamObj;

    const float CamSpeed = 3f;

    const float MinPower = 15f;
    const float PowerCoef = 1f;

    void Awake()
    {
        // PlayerBall, CamObj, MyUIManager를 얻어온다.
        // ---------- TODO ---------- 
        PlayerBall = GameObject.Find("PlayerBall");
        CamObj = GameObject.Find("Main Camera");
        MyUIManager = FindObjectOfType<UIManager>();
        // -------------------- 
    }

    void Start()
    {
        SetupBalls();
    }

    // Update is called once per frame
    void Update()
    {
        // 좌클릭시 raycast하여 클릭 위치로 ShootBallTo 한다.
        // ---------- TODO ---------- 
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo)) ShootBallTo(hitInfo.point);
        }
        // -------------------- 
    }

    void LateUpdate()
    {
        CamMove();
    }

    void SetupBalls()
    {
        // 15개의 공을 삼각형 형태로 배치한다.
        // 가장 앞쪽 공의 위치는 StartPosition이며, 공의 Rotation은 StartRotation이다.
        // 각 공은 RowSpacing만큼의 간격을 가진다.
        // 각 공의 이름은 {index}이며, 아래 함수로 index에 맞는 Material을 적용시킨다.
        // Obj.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/ball_1");
        // ---------- TODO ---------- 
        int index = 1;
        Vector3 pos = StartPosition;
        Vector3 tmp_pos = pos;
        for (int i = 0; i < 5; i++)
        {
            tmp_pos = pos;
            for (int j = 0; j <= i; j++)
            {
                GameObject ball = Instantiate(BallPrefab, pos, StartRotation);
                ball.name = index.ToString(); // 공 이름 설정
                ball.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/ball_" + index.ToString());
                index++;
                pos.x += RowSpacing;
            }
            pos.z -= RowSpacing * Mathf.Sqrt(3) / 2;
            pos.x = tmp_pos.x - (RowSpacing / 2);
        }
        // -------------------- 
    }
    void CamMove()
    {
        // CamObj는 PlayerBall을 CamSpeed의 속도로 따라간다.
        // ---------- TODO ---------- 
        if (PlayerBall != null)
        {
            Vector3 TargetPos = PlayerBall.transform.position;
            TargetPos.y = CamObj.transform.position.y;
            CamObj.transform.position = Vector3.Lerp(
                CamObj.transform.position,
                TargetPos,
                Time.deltaTime * CamSpeed
            );
        }
        else return;
        // -------------------- 
    }

    float CalcPower(Vector3 displacement)
    {
        return MinPower + displacement.magnitude * PowerCoef;
    }

    void ShootBallTo(Vector3 targetPos)
    {
        // targetPos의 위치로 공을 발사한다.
        // 힘은 CalcPower 함수로 계산하고, y축 방향 힘은 0으로 한다.
        // ForceMode.Impulse를 사용한다.
        // ---------- TODO ---------- 
        if (PlayerBall != null)
        {
            Rigidbody rb = PlayerBall.GetComponent<Rigidbody>();
            Vector3 force = targetPos - PlayerBall.transform.position;
            force.y = 0;
            rb.AddForce(force.normalized * CalcPower(force), ForceMode.Impulse);
        }
        // -------------------- 
    }
    
    // When ball falls
    public void Fall(string ballName)
    {
        // "{ballName} falls"을 1초간 띄운다.
        // ---------- TODO ---------- 
        MyUIManager.DisplayText(ballName, 1f);
        // -------------------- 
    }
}

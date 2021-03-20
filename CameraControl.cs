using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Texture2D cursorTexture;
    public float cursorSize=100f;
    // 鼠標圖樣Texture與大小Size

    private Camera mainCamera;
    private Vector3 CameraAng;  // 用於表示camera視角 (rotation)

    private float angX = 0;
    private float angY = 0;
    //跨其抓取x值,y值 且可用於限制x,y的範圍

    public float angSpeed = 0.5f;
    public float angLerpParam = 50;
    // 為了讓角度動作更順暢 且speed=0可實現停止

    public float yMinLimit = -80;
    public float yMaxLimit = 80;
    //用於最低與最高限制視野 避免視野翻轉
    
    private float cameraFov;
    public float fovSpeed = 160f;

    public float fovMinLimit = 10;
    private float fovMaxLimit = 60;
    // 60是最初的大小

    private Vector2 oldPosition1;
    private Vector2 oldPosition2; // 用以儲存上一次update()的tounch資料
    // oldPos需要跨期update() 故需在外部設變數


    public GameObject hitObject;
    private NPCDialogue NPC;

    internal bool isDialogState = false;
    internal bool isButtonState = false;


    // Start is called before the first frame update
    void Start()
    {
        Input.multiTouchEnabled = true; // 開啟多點觸控

        mainCamera = this.GetComponent<Camera>();
        CameraAng = mainCamera.transform.eulerAngles;

        angY = CameraAng.x;
        angX = CameraAng.y;
        // rotation的上下為x軸 position的上下為y軸 不影響原視野的都為z軸
        // 直覺上採用position的設定： 將x軸設為左右 y軸設為上下 

        cameraFov = mainCamera.fieldOfView;

    }

    // Update is called once per frame
    void Update()
    {
        int n = Input.touchCount; // 為處理任何觸控手勢
        Debug.Log("finger:" + n);

        if (!isDialogState) // 非對話模式 可以使用任何一種觸控操作方式
        {
            if (n == 3 && AllTouchMoved(n))
                RotateScreen(Input.GetTouch(0).deltaPosition.x, Input.GetTouch(0).deltaPosition.y);
            //三指全部同向 則只取第一指

            else if (n == 2)
            {
                if (AllTouchMoved(n))
                    ZoomScreen(Input.GetTouch(0).position, Input.GetTouch(1).position);
                // 二指實現縮放

                else if (Input.GetTouch(1).phase == TouchPhase.Began)
                    oldPosition2 = Input.GetTouch(1).rawPosition;
                // 紀錄第二指的初始位置 為實現ZoomScreen()
            }

            else if (n == 1)
            {
                if (Input.GetTouch(0).tapCount >= 2)
                {
                    Debug.Log("tapCount:" + n);
                    ClickObject(Input.GetTouch(0).position);
                    // 點擊2次以上來選擇物件
                }

                else if (Input.GetTouch(0).phase == TouchPhase.Began)
                    oldPosition1 = Input.GetTouch(0).rawPosition;
                // 紀錄第一指的初始位置 為實現ZoomScreen()
            }
        }
        else // 進入對話模式 此時螢幕不能移動 
        {
            if (isButtonState)
            {
                Debug.Log("進入按鍵模式");
            } //只有點擊button觸發事件才能離開此狀態

            // 表示無論用任何一種點擊方式都會被算入
            else if (n >= 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                NPC.isContinueDialog = true;
            } // NPC講完一句話後isContinueDialog關閉 camera點擊完後再將isContinueDialog打開
        }
    }

    // 用於顯示cursor
    void OnGUI()
    {
        foreach(Touch touch in Input.touches)
        {
            Rect rect = new Rect(touch.position.x, Screen.height - touch.position.y, cursorSize, cursorSize);
            GUI.DrawTexture(rect, cursorTexture);
        }
    }

    private bool AllTouchMoved(int touchCount)
    {
        for (int i=0; i < touchCount; i++)
        {
            if(Input.GetTouch(i).phase != TouchPhase.Moved)
                return false;
            //交集只要有一個為false則後續不用在檢查
        }
        return true;
    }

    private void RotateScreen(float deltaX, float deltaY)
    {
        angX -= deltaX * angSpeed;
        angY += deltaY * angSpeed;
        angY = Mathf.Clamp(angY, yMinLimit, yMaxLimit);
        Quaternion rotation = Quaternion.Euler(angY, angX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, angLerpParam * Time.deltaTime);
        // 用Lerp修正動作 避免幀數差異大時的卡頓
    }


    private void ZoomScreen(Vector2 tempPosition1, Vector2 tempPosition2)
    {
        float oldDist = Vector2.Distance(oldPosition1, oldPosition2);
        float newDist = Vector2.Distance(tempPosition1, tempPosition2);

        if (newDist > oldDist) //縮小
            cameraFov -= fovSpeed * Time.deltaTime;
   
        else if (newDist < oldDist) //放大
            cameraFov += fovSpeed * Time.deltaTime;

        cameraFov = Mathf.Clamp(cameraFov, fovMinLimit, fovMaxLimit);
        mainCamera.fieldOfView = cameraFov;

        oldPosition1 = tempPosition1;
        oldPosition2 = tempPosition2;

    }
    private void ClickObject(Vector2 screenPosition)
    {
        RaycastHit hit;
        Vector3 screenPos = new Vector3(screenPosition.x, screenPosition.y, 0);
        Ray ray = mainCamera.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out hit))
        {
            hitObject = hit.collider.gameObject;
            hitObject.GetComponent<Renderer>().material.color = Color.red; // 物件被點選轉成紅色
            NPC = hitObject.GetComponent<NPCDialogue>(); // 所有物件都有對話
            NPC.isDialog = true; // NPC開啟對話
            isDialogState = true; // 表示mainCamera目前在對話 進入對話模式
        }
        else
            hitObject.GetComponent<Renderer>().material.color = Color.black; //當沒有點選此物時則轉回黑色
    }
}
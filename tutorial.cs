using System.Collections;  //C#的命名空間
using System.Collections.Generic;  //C#的命名空間 泛型
using UnityEngine;

// ================= C# =================
// using 為指示詞 建立類別的別名 或 使用命名空間內的類別
// 導入命名空間 如同 import package 

// 命名空間內：預設為internal 只有public跟internal兩種
// class內： 會依據變數類型而有不同的預設

// 存取層級並非大小關係 而是看當前狀況決定最適合的
// 使用任何資料型態都必須先宣告
// C#宣告必須加上: 存取層級+ 屬性只能用類別使用(static) + 繼承相關(abstract or sealed)

// static method不需要透過實例化的對象進行 而mothod則通常須先實例化對象

// abstract class 與 interface很接近 但interface可以多人使用
// interface 當許多類別需要使用同一個方法時 並希望能統一管理
// interface 只可讓class實作 本身並不實例化
// abstract class 因為有繼承關係 通常子類別為父類別延伸而至

// 另外delegate則是把用於宣告method
// delegate void compute(); 如此便能被當成參數在被代入其他method(compute)

// bool isArticle(origin:Vector3 origin=(0,0,0))
// (註解:變數類型 變數名=預設)

// 單引號用於字元 雙引號用於字串

// foreach (Transform child in parentTransform){} 用於子類遍及

// out ref in都是以reference的形式傳入
// out傳入後必須實作 因為傳入的物件可能尚未初始化(實例化)
// ref傳入後則可以不實作 因為需要先初始化才能傳入
// in傳入後不能實作 不充許修改 用於修改物件內屬性prpperties

// ; 就是pass的概念
// C#不能用{0,1}表示flase,true


// method或class常用開頭大寫駱駝體 property或variables(自己設的變數)為開頭小寫駱駝體 
// 主要目的的因為 class與property時常重名 需要大小寫區分
// struct和emun與class相同 使用開頭大寫駱駝體
// class和struct要用new做實例化 而emun為抽象型態則不用
// class 用指標做指派 故兩個指標會指向一個相同個體
// struct本身就是值類型 做指派會再創建一個相同值的不同個體

// class為物件(可以有方法methods和屬性properties 兩者都為成員member)
// struct為資料結構(一般只存放資料properties 但也可能為static methods通常只用於做運算)
// emun也為資料結構(存放同類型資料)


// public Dictionary<int, int> ConversationAdd = new Dictionary<int, int>();
// using System.Linq 用List,Dictionary做操作 要加上LINQ 才能用相關的method
// int t=ConversationAdd.ElementAt(0).Key; 
// 單純使用list則用Array[]就好

// using System.Threading; C#的休息指令
// Thread.Sleep(1000);


// ================= unity =================
// 製作遊戲的邏輯是：針對每個時間點做腳本內容
// 某些物件是在發生事時才會出現

// 盡量減少與unity重名的命名方式：可以在前面加上特有形容詞 以確保易讀性

// emptyObject 可用來當作生成位置 或 scene中的層級管理

// model與prefab 第一個做出來就是model 而之後複製而來的是prefab
// 當model發生變化時 所右prefab也會一起變動
// prefabs為預製 為unity的重點-預製 因為遊戲需過重複單位來拼湊 ex:地形
// prefabs又可以說是在project中建立物件 此物件改動時 可使所有重複單位物件一起變動
// 在scene做完內容後 可先存入prefabs中 直到需要時再取出

// mateiral 由shader與texture組合而成
// texture為一般可導入的圖檔 shader則近似於texture的呈現方式

// plane面積較大 用200個三角形 適合做地形 terrain是plane的延伸
// quad面積較小 只用2個三角形組合而成 適合做看版
// plane跟quad差別在紋理貼圖 plane因為紋理多適合做地形 quad適合直接用image貼圖

// 做出scene中的GameObject的實體 必須考慮Mesh和Material
// 做出Material 則需要考慮shader和texture
// shader相關: diffuse漫射 也就是一般貼圖 specular反射 用於呈現特殊光影效果
// Additive加濾鏡柔光 Alpha Blended透明混合 VertexLit Blended點光混合
// Unit無任何反射模式

// 當選擇不多時 可利用測試的方式來做遍及法
// 會比一直上網找冷門資料來的有效率

// sprite跟cube分別為2D與3D的最基本單位
// 用light跟camera來仿照真實世界
// lightmap為光影貼圖 normalmap為法線貼圖 前者是後者的延伸加強版 都需要特殊的紋理貼圖
// single channel 用於單色調調整透明度

// 遊戲圖片的像素大小一般會統一規格 ex:32x32
// 為方便做ppu管理 ppu也就是在座標中一格(unit)所顯示的像素
// 遊戲製作常用單一圖檔 做multiple多圖分割 以方便管理

// 常見script:每個player都會有控制器controller 狀態條health 武器weapon 動畫animator
// 每個物件也要有統一的設定

// 相機要有自己的cam_script 只要是動態進行的東西都需要script

// anim_script 先做出動作的script code 再將多張pic放進script中
// anim會被視為物件 再直接拉入觸發事件即可

// Debug.Log("........") 會在console顯示 用於除錯

// Vector2,Vector3...皆為struct 而KeyCode,TouchPhase...則為emun
// Input,Time,Debug...則為class 成員都是static 則表示此類不能實例化

// unity 最常見的繼承關係：
// Object(所有內置對象的基類)->GameObect(所有實體entity的基類)
// Object->Component(全部都不能創建 只能用附加的方式)->Transfrom(只描述一幀當中的靜態屬性)
// Component一定需要依附GameObject 而兩者都是Object的子類
// 而Component.transform就是返回GameObjec當情的屬性狀態 等同GameObject.transform

// Object->Component->Behaviour->Camera(能被開啟關閉enabled)
// Object->Component->Behaviour->MonoBehaviour(所有的script的基類)

// screen space point 左下為(0,0) 右上為(Screen.width, Screen.height)
// viewport space point 左下為(0,0) 右上為(1,1)(已做標準化)
// world space point 就是scene中的position

//unity採用左手座標系統(大部分遊戲都是如此)：
// Vector3.right(1,0,0) Vector3.up(0,1,0) Vector3.forward(0,0,1)
// Vector3.one(1,1,1) Vector3.zero(0,0,0)
// Vector3.one用於同時三軸縮放物體

// transform.Rotate(Vector3.up, -Input.GetTouch(0).deltaPosition.x * 0.5f);
// 此方法為繞軸(Vector3.up)旋轉 deltaPosition.x為每幀變動量

// TouchPhase.Began 手指觸碰的當下 只有一幀 
// TouchPhase.Moved 手指在螢幕上滑動 很多幀 
// TouchPhase.Stationary 手指在螢幕上靜止 很多幀
// TouchPhase.Ended 手指離開的當下 只有一幀 
// TouchPhase.Canceled 當phase被取消時 可能超過5指操作


// Time.time 為程式執行至此刻的時間
// Time.deltatime 用以表示間隔一幀的時間(秒數) 30fps約為32ms
// 通常用於 speed * Time.deltaTime 讓動作滑順

// isOneFinger(): true/false 進入兩指狀態前一定會經過一指狀態
// 即單一的使用者觸控動作都能拆成多幀的不連續動作
// 同理 isTwoFinger/isThreeFinger...

// Debug.DrawLine(transform.position, hit.transform.position, Color.red, 0.1f, true);
// 只能在scene模式中看到
// Color為struct

// Debug.DrawRay()使射線變成可見型態
// DrawRay()出發點與方向 DrawLine()兩點

// this.GetComponent<>() 或gameObject.GetComponent<>() 都行 兩者意思相同
// gameObject開頭為小寫 是被綁定物件的屬性


// OnMouseDown 當滑鼠按鍵按下時 可觸發此事件
// OnMouseUp 當滑鼠按鍵鬆開時 可觸發此事件
// OnMouseDrag 當滑鼠按下且尚未鬆開時 可觸發事件
// OnMouseMove 當滑鼠移動時 可觸發事件

// OnMouseEnter 移入觸發區域的當下 觸發此事件
// OnMouseExit 移出觸發區域的當下 觸發此事件
// OnMouseOver 移入觸發區域且尚未移出觸發區域前 (多幀)連續觸發事件
// OnMouse常用於2D遊戲 使用前提是物件要有Collider 因為如此才是在2D空間中的實物 

// Messages大多用在事件管理EventSystem中
// EventSystem會管理事件的執行順序
// 常見的Start()->OnTrigger ->OnColision ->OnMouse->Update()->LateUpdate()->OnRenderObject

// 還有OnClick,OnDblClick 以及 onKeyPress(多幀),onKeyDown,onKeyUp

// OnCollisionEnter 當此物件接觸到另一個帶有Rigidbody/Collider的物件時觸發
// 剛體Rigidbody在事件管理中常用於被動物件Wall,Floor等

// OnCollisionExit 當此物件停止接觸時觸發
// OnCollisionStay 在接觸時間每幀都會觸發

// 另有OnTriggerEnter,OnTriggerExit,OnTriggerStay 用於非實體的物件 像是指定區域,通關布條等

// 共有5種：OnMouse,OnClick,OnKey,OnCollision,OnTrigger
// 除了上述五種之外 也可以用Input類別直接抓玩家輸入的資訊

// using UnityEngine.EventSystems 可以創建自己的Message method

// 必須創建一個interface 再讓class去實作這個interface
// public interface ICustomMessageTarget : IEventSystemHandler
// {
// functions that can be called via the messaging system
//    void Message1();
//    void Message2();
// }


// 如此就能在class中創線自己的Message method
// public class CustomMessageTarget : MonoBehaviour, ICustomMessageTarget
// {
//    public void Message1()
//    {
//        Debug.Log("Message 1 received");
//    }

//    public void Message2()
//    {
//        Debug.Log("Message 2 received");
//    }
// }




// 編輯unity功能：
//public class ConversationData : ScriptableObject 繼承自ScriptableObject可以讓你在Editor中使用自訂的功能
//{
//       public List<SpeakerData> list;
//}


// using UnityEditor;  腳本要加上UnityEditor
// public class YourClassAsset
// {
//    [MenuItem("Assets/Create/Conversation Data")]
//    public static void CreateConversationData()
//    {
//         ScriptableObjectUtility.CreateAsset<ConversationData>();
//          可以Create 繼承自ScriptableObject的子類
//    }
// }
// 不掛在任何一個物件上 而是放在Editor的資料夾就能使用


// Component.enabled = true/false; 用於組件的激活
// GameObject.SetActive(true/false); 用於物件的開啟
// 一般用GameObject.SetActive()表示物件出現
// Component.enabled則用於關閉功能 物件還在但不能點擊觸發

// 另外也可以用GameObject.active = true/false
// 但同理效率也沒有GameObject.SetActive()好

// 差別在於 還未生成的或GameObject.active=false者 無法被GameObject.Find()找到

// 繼承自UI.Graphic的UI Component 只能有一項
// 通常用於顯示物件 image跟text只能存在一項
// panel下面要有text就要用子類實現 button的文字就是內建的text子類實現的

// 繼承自UI.Selectable的UI Component可以有多個 而且不衝突
// 像是panel物件可以再加上button 做出onclicK()


// RectTransform有分為anchor,pivot,position
// 其目的為使UI能適應各種裝置的螢幕大小
// anchor的範圍只有x:[0,1] y:[0,1] 代表在各種螢幕上的位置比例
// 只有小錨點anchorMin與大錨點anchorMax兩個座標 [0,0]在左下方 [1,1]在右上方
// 故小錨點為長方形的左下點 大錨點為長方形的右上點

// 另有代表偏移量的offsetMin和offsetMax
// 分別表示 和小錨點anchorMin之間的距離 以及 和大錨點anchorMax之間的距離
// 由於充許超出框外 故範圍沒有界線

// 通常UI的父子配置：Canvas -> Panel ->text,image,button

// pivot 由offsetMin和offsetMax為圍出的長方形來決定
// pivot用來做物體的縮放與旋轉
// UI放在2d平面上 position的Z軸與rotation的X軸,Y軸都沒有意義


// 所有的UI都一定要放在canvas上面 主要依據相對位置排放


// 使用GameObject的static method找腳本
// GameObject.Find("ObjectName").GetComponent<scriptName>().enabled = true;  打開腳本
// GameObject.Find("ObjectName").GetComponent<scriptName>().enabled = false;  關閉腳本

// using UnityEngine.Events;
// Invoke("method_name",秒數) 和 InvokeRepeating("method_name",秒數,repeatRate)
// 用來做出延遲調用 直接將method_name改為字串即可用 秒數是在幾秒後使用
// CancelInvoke(“MethodName") 則搭配使用 取消調用程式
// Invoke()是MonoBehaviour的方法

// Application.Quit(); Application為系統相關的類別 Quit(很常被使用)


// this.GetComponent<Button>().onClick.AddListener(ClickEvent);
// onClick 為Button的屬性 用來呼叫ButtonClickedEvent類別

// AddListener()中需要放func
// 而能夠被呼叫的func又稱為callback function

// AddListener(()=>{
//     ClickEvent();   lamba作法可以讓AddListener可以放入多個methods 此外ClickEvent也可以放入參數
// })

// 只要GameObject存在必會執行start(),update()
// 加掛script目的：只是在物件產生後 實現其個別需求而已
// 故GameObject.SetActive比Component.enabled更好節約效能

// Animator動畫的目的：
// 因為有些動作不是每幀都要update() 存在連續動作
// 等同是用Animator填滿後續數幀的時間
// 動畫或3D,2d物件都不適合在unity中製作 應該是外部數用軟體製作完後導入unity


// camera :Field of View,Clipping Plane,Viewpoint Rect 控制相機的四角錐體
// Clear Flags,Culling Mask,Depth 控制多個相機時應如何搭配顯示畫面

// [SerializeField] 用於在inspector中顯示跟button一樣的效果
// UnityEvent onLoad = new UnityEvent();



//================================================
// AroundObject.cs
// 用於在Game中變動物件參數: [ExecuteInEditMode] play後不可保留更動

// 在update()中宣告：每次都更新且只在此block中使用
// update()外宣告：引用其他組件參數
// 變數不需要供外部使用或是跨不同期的block時 才選擇在update()內部宣告

// rotation * position 取代 position * rotation
// 因為rotation為Quaternion四元數 矩陣具方向性

// onRenderObject() 在LateUpdate()之後
// 另有前的onPreRender() 和後的onPostRender()




// CameraControl.cs
// player要掛的功能是操作型動作
// 且對於所有對象的反應都相同的 如此就不用額外寫辨識方法

//private Camera m_Camera;
//private Vector3 CameraAng; 表示camera視角 (rotation)
//private Vector3 CameraPos; 表示camera位置 (position)

// Input.multiTouchEnabled = true;
// 開啟多點觸控 為預防行動裝置操作過於複雜 故一般不開啟
// 並搭配 Input.touchCount 決定多指操作

// transform.eulerAngles 每次都必須重設 可直接導入Vector3
// transform.rotation 可以單方向做加減變動 不可導入Vector3

// mobile大致分為 觸控 與 陀螺儀 二種
// Input.touch[i]為觸控操作 可用Input.GetTouch(i)替換

// 滑鼠鍵盤一次是一幀 但手機觸控一次是好幾幀
// 故要加上TouchPhase Began,Ended都只會有一幀

// Mathf.Abs()取絕對值 Mathf.Clamp()取數值範圍
// public float yMinLimit = -80;
// public float yMaxLimit = 80; 可用於最低與最高限制視野
// angY = Mathf.Clamp(angY, yMinLimit, yMaxLimit);

// ZoomScreen兩種作法：1.兩點距離判斷 或 2.內積cos的正負值判斷
// Vector2 Position = Input.GetTouch(0).position;
// bottom-left為(0,0) top-right為(Screen.width, Screen.height)

// osition當前的位置(通常用於TouchPhase.Moved) rawPosition最初的位置(TouchPhase.Began的座標位置)
// position 為當前位置 deltaPosition表示移動量

// FOV 放入view的field變小 即為放大
// 一般skybox的原始FOV為60

// Input.GetTouch(i).tapCount >= 2 表示多次雙擊

// RaycastHit hit; //只有宣告而還未初始化
// RayCastHit為struct 有屬性表示相關的碰撞訊息

// [法一]用screen射線
// Vector3 screenPos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0);
// Ray ray = mainCamera.ScreenPointToRay(screenPos);
// ray由origin位置與direction射線方向 組合而成
// 將螢幕點擊座標換成3D物件的座標 screen就是camera故可直接轉換

// [法二]直接在World Space找點
// Vector3 point = m_Camera.ScreenToWorldPoint(screenPos);
// 但z軸應放m_Camera.nearClipPlane;

// if (Physics.Raycast(ray, out hit){} //觸碰到物體與否 預設為無窮遠(Mathf.Infinity)
// Raycast()與LayerMask相關 用以表示哪些層的物件要觸發 哪些不用
// 一般若沒有特別設定 物件都放在Default層

// 最常用可以用GameObject.name或GameObject.tag兩種

// hit.transform.tag=="animy"
// hit.transform.CompareTag("animy")
// 兩者功能完全相同 但CompareTag()效率較高 當大量使用Tag時應用後者
// 另外GameObject.FindGameObjectsWithTag("")也很常被使用
// 返回GameObjects[]





// NPCDialogue.cs
// Dialogue應該掛在NPC上
// 因為掛在player上 就必須從多個可能對話的對象中找出其中一個

// [System.Serializable] 必須放在class,struct,emun上面 讓unity可以在inspector中設定參數

//public List<string> dialogue = new List<string> { "test" };
// 用List<>取代array 才能動態增加字串

// private GameObject panel;  dialogue面板
// 只要在Hierarchy出現的都是GameObject 無論是物件或UI都能使用transform找子類

// 用setActive()來控制物件出現與否 可用此方法來彈出對話框
// 做Hierarchy的目的：只要父類別沒有激發 則子類別全部沒激發

//gameObject.SetActive(false);
// 不能用this.SetActive(false) 因為this為這個組件 不是物件GameObject
// this.getComponent<>()是因為為求方便 充許組件直接找組件

// 也可以用GameObject.Find("Canvas/Panel/text")
// GameObject的Find()是找尋整個scene中的物件
// Find()為static methods :只有GameObject可以使用 實例化的物件則不行

// 物件的父子關係最主要的用途就是相對位置的設置 故用Transform來找
// 此外只要物件存在 必然會有Transfrom 故最適合用於找parent,child

// "=>"為專有用法lamba 不同於">="

// Specker = gameObject.GetComponent<SpeakerData>();
// 製作 SpeakerData class 用以存放Dialog資料：目前沒用到




// DialogueImage.cs

// script應該直接掛在物件上 而不是透過panel調用
// 如此更符合物件導向：因為不是每一個panel都需要使用到 有些panel只需要text

// 掛script應該到所有物件具一致性
// 不用選擇特定對象物件 也不用因為部分狀態條件不同而改變
// script都代表一種功能 一個物件可以掛多個script：表示為實現多種功能

// 因此LevelChange與NPCDialogue應該分為兩個script
// 因為不是所有的NPC都有LevelChange的需求
// 但script越少越好 ：因為組件掛越多 彼此交錯影響只會更複雜

// code需要考慮擴展性
// 如果現在不只2種狀態 如何方便擴展到能容納多種狀態
// 但擴展性越高 就越容易產生bug ： 因視專案需求 決定code擴展的程度

// private NPCDialogue dialogue;
// 父類別從外面綁定 只跟Panel相關 與Camera無關

// transform.parent與transform.Find()不同
// 前者找到的是父輩物件的transform組件 後者就是找到物件本身

// activeSelf和activeHirarchy 前者只有自己 後者為全部子類

// 換圖：用Image.texture換照片 必須加入texture2D類別的參數
// 除了texture之外 也可用sprite類別替代
// 此方法最好：因為位置和其他屬性都不變 不需要另外宣告物件

// 或用 Resources.Load("Image/picture_name", typeof(Sprite)) as Sprite
// 較差的方法 應該一開始就在inspecter中掛載


// DialogueButton.cs
//public void ClickEventOK()
//{
//    text.SetActive(true);  //由btn觸發text這個GameObject
//    GameObject.Find("notice").GetComponent<Text>().text = "以由btn觸發text";
//}
// 用GameObject掛上Text Component來處理文字訊息



// void onAction()
// 使用Event Trigger Component 增加new event type來掛上寫在script上面的方法



// imageObject = GameObject.Find("Image");
// imageObject.SetActive(false);
// 被關起來後就不能找到了 所以通常要綁定的要放在前面


//ChangeLevel.cs

// 切換scene
// SceneManager.LoadScene("場景名稱") 或 SceneManager.LoadScene(場景索引值)
// 必須先在Build Setting中將Scene加入 Scenes In Build 清單


// ChangeLevel.cs
// this.enabled = false/true; 不要為了省效能而關起來 因為不是GameObject

// Time.time方式:
// private float startTime = 0;
// private float animationTime = 2f;


// ================= 專案 =================
// skybox最原始的版本：TintColor:808080 Exposure:1
// camera fov:60 ViewpointRect(x=0,y=0,w=1,h=1) ClippingPlanes(0.3,1000)

// 遊戲：
// 狗狗放大放小或魚目混珠
// 貓貓魚目混珠：使你離不開 天竺鼠車車：視窗變小 鱷魚咬了你：行動遲緩 牛牛今年牛年：新年快樂  猴子邀你喝酒：喝醉酒
// 箭頭進行轉場： 移動動畫
// 要有文字敘述告知目前狀態

// 每一種動物都有不同的效果 鱷魚在此區無法探索 或 天竺鼠使鏡頭變慢 牛年恭喜發財 猴子愛喝酒
// 只有三關：1.只有狗跟貓 2.五種都有 3. 
// 必須要將鏡頭完整放入才算
// 隨攝像頭移動而用提示與玩家互動 最後會有找到目標的提示

// scene中放入可點選物件： 1.箭頭：用於skybox轉換 2.動物：觸發效果 3.其中的狗狗會觸發關卡轉換介面
// 加入GUI：開頭介面,關卡轉換,結束畫面後返回開頭介面

// 開頭畫面只要一個button就好 便可開始做轉場

//  用mac預覽程式與bgremover便可完成去背

public class tutorial : MonoBehaviour
{
    // 宣告attr.的目的：讓component可以直接在Inspector中加入參數 藉此供script的method使用

    public Vector3[] vertices;
    private Vector3 Pos1;
    // Vector3[] vertices 和 List<Vector3> list 兩者都是用list儲存資料
    // 前者適合靜態資料 創建時一定要宣告elmt數量 通常用於存入mesh的多個頂點資料 常用vertices.Length
    // 後者則能做動態修改 如list.Add(),list.Insert(),list.Remove()等
    // list.ToArray() 可以從list轉回array

    List<int> myIntLists = new List<int>(); //另一種宣告方式
    Dictionary<string, string> MyDic = new Dictionary<string, string>(); //Dictionary同理
    // MyDic["mystring"]與myIntLists[0] 使用方法完全相同



    // Start is called before the first frame update
    void Start()
    {
        // 在start()就先抓取 以避免update()不間斷抓取
        // start() 由於遊戲執行時只會執行一次 一般用於做物件抓取

        Pos1 = this.GetComponent<Transform>().position;
        // GetComponent() 只能抓自身的component 目的為用script來完成更細微的操作
        // GetComponent<Transform>().position 指定特定的組件
        // 要使用其他物件的component 必須在script中加上attr. 並在inpector中指向該物件
        // 若沒指向物件 則要用GameObject.Find()做搜尋

        // public 宣告變數 是為了能在外部限制數值的範圍

    }

    // Update is called once per frame
    // Update()全部執行完一回即為一幀 要想辦法做成一秒30幀以上
    void Update()
    {

        // [法一]update()增加變數：不一定是每一幀都要產生的屬性
        // [法二]update()不增加變數：此變數每一幀都需要 則應直接在外部宣告

        //[法一]抓取變動量
        //float rotationX = Input.GetAxis("Mouse X") * xSpeed * sensitivity;
        //float rotationY = Input.GetAxis("Mouse Y") * ySpeed * sensitivity;
        // 由鼠標的移動位置判斷 靜止時為0
        // ios不能用Mouse X,Mouse Y 而android則充許滑鼠手機通用

        //this.transform.Rotate(-rotationY, rotationX, 0);  Rotate()可直接帶入三維向量
        // transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0);  則要用尤拉角來帶入
        // transform.rotation x軸為上下 y軸為左右 而且x值越小則越往上移
        // Quaternion 四元數用來描寫變動角度rotation
        // 但直覺上我們用x,y,z三軸 故要用Euler()轉換

        //[法二]直接使其影響x值,y值
        //x += Input.GetAxis("Mouse X") * xSpeed * sensitivity;
        //y -= Input.GetAxis("Mouse Y") * ySpeed * sensitivity;
        //y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
        // 用於限制transform.rotation的範圍
        // 若只抓取變動量 則難以實現
        //Quaternion rotation = Quaternion.Euler(y, x, 0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * angleSpeed);
        // Quaternion.Lerp用來取得2個rotation之間的插補動作



        if (Input.GetKey(KeyCode.RightArrow))  //Input.GetButton("Right")
                                               // GetKey使用KeyCode做參數 GetButton則用InputManager自行設定參數名稱
                                               // 另外有GetKeyDown按下的那一禎 GetKeyUp按下後釋放的那一禎 GetKey只要按下的狀態就會連續執行

        // Input.GetButton()和GetAxis()的參數可由project settings調整 另外參數名稱常與emum KeyCode搞混

        {
            this.transform.position += new Vector3(0.1f, 0, 0);
           
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3(-0.1f, 0, 0);
        }

        // 透過螢幕點擊作法：
        // RaycastHit hit; 只有宣告而還未初始化
        // RayCastHit為struct 有屬性表示相關的碰撞訊息

        // Physics.Raycast()
        // Physics為class  member全為static 用於做scene中的物理性質設定 
        // Physics.Raycast()只回傳是否碰到 其餘資料在RaycastHit中

        // if(Physics.Raycast(ray, out hit))
        // out常用於射線功能 讓物件以參照reference的形式引入 而不是變數的形式

        // RaycastHit[] hits;
        // hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);
        // 此時不用out 來找被觸碰到的物件
        // 物件需要有Collider 才能被hit打到


    }
    // rigidbody剛體只用來描述自身 Collider碰撞器則是描述兩物體之間的關係 Trigger觸發器則用於其一沒有實體的關係

    // rigidbody:
    // dynamic所有物理特性 kinematic不具重力或其他受力點 static沒有剛體只描述固定不動的物體



    void LateUpdate()
    {
        // 在Update()執行動作 表示這件事只有一個參與者 自己的動作用此
        // 在LateUpdate()執行 表示有多位參與者 同時在一幀處理事件

        // 用於重置變數 當secne中的一幀內的各個物件的update()執行完後接著執行
        // 此外要確保全部的update()在每一幀內都能執行完畢 才不會卡頓
        // 常用於多個物件update()結束後 進行重置camera
    }



    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        //刪除自己 必須指定物件gameObject不能用this 因為this只是在class中的代名詞
    }
    // Messages Method的使用方式 就是在做出反應物件下的Script中宣告此方法


}

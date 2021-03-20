using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 所有可點擊物件都具有NPCDialogue
public class NPCDialogue : MonoBehaviour
{
    public List<string> dialogue = new List<string> { "dialogue" };
    internal int index_dialogue; // 讓子類別Image可以插入

    internal bool isDialog;
    internal bool isContinueDialog;
    // 只讓CameraControl使用 不能在inspector中使用

    private GameObject panel;  // dialogue面板
    private Text conversation;

    private CameraControl mainCamera;

    // Start is called before the first frame update
    void Awake()
    {
        panel = GameObject.Find("Panel");
        conversation = panel.transform.Find("Dialogue").GetComponent<Text>();

        mainCamera = GameObject.Find("Main Camera").GetComponent<CameraControl>();
    }
    void Start()
    {
        isDialog = false; //isDialog 判斷是否全部講完
        isContinueDialog = true; // isContinueDialog 判斷是否點擊下一頁
        index_dialogue = 0;
        panel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (isDialog && isContinueDialog)
        {
            panel.SetActive(true);
            if (index_dialogue < dialogue.Count)
            // index_dialogue < dialogue.Count表示還沒講完 
            {
                Debug.Log("npc index_dialogue: "+index_dialogue);
                Debug.Log("npc Count: " + dialogue.Count);

                conversation.text = dialogue[index_dialogue];
                index_dialogue++;
                isContinueDialog = false;

            }

            else if(index_dialogue>= dialogue.Count)
            {
                Debug.Log("NPC index:"+ index_dialogue);
                mainCamera.isDialogState = false;
                index_dialogue = 0; // conversation結束後 把index歸零
                panel.SetActive(false);

                isContinueDialog = true;
                isDialog = false; // 用isDialog把對話關起來
            }
        }
    }


}

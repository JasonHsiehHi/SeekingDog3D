using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    private GameObject buttonObject;
    private Button button;

    private NPCDialogue NPC;

    private CameraControl mainCamera;

    private int dialogueLength;
    // button必定是插在Dialogue的最後一句 才能依據player的動作做反應
    internal int followUpLength;
    // 傳給其他script以觸發事件

    private List<string> originalDialogue;
    public List<string> followUpDialogue = new List<string> { "followup" };
    // 只要有button一定會存在後續劇情 才不會結束得太突兀

    public string buttonName;
    // 因為button可以有多個 所以在外部綁定

    internal bool isHaveChange = false;

    // Start is called before the first frame update

    void Awake()
    {
        buttonObject = GameObject.Find(buttonName);
    }
    void Start()
    {
        button = buttonObject.GetComponent<Button>();
        NPC = this.GetComponent<NPCDialogue>();
        buttonObject.SetActive(false);

        mainCamera = GameObject.Find("Main Camera").GetComponent<CameraControl>();
        originalDialogue = NPC.dialogue;
        dialogueLength = originalDialogue.Count;
    }
    // Update is called once per frame
    void Update()
    {
        if (NPC.index_dialogue == dialogueLength && !isHaveChange) // 在最後一句時顯示
                                                                   // 存在順序之差 NPCDialogue的順序在DialogueButton之前
        {
            Debug.Log("bnt index_dialogue: " + NPC.index_dialogue);
            Debug.Log("bnt count: " + dialogueLength);

            buttonObject.SetActive(true);

            mainCamera.isButtonState = true;
            // 不同於isDIagueState由CameraControl開啟

            if (Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                button.onClick.AddListener(ClickFollowUp);
            }
         
        }
        if (!mainCamera.isButtonState)
            buttonObject.SetActive(false);

        if (NPC.isDialog == false)
        {
            NPC.dialogue = originalDialogue; // 全部走完在把原先的資料帶回來
            isHaveChange = false;
        }    
            

        // button後必定存在後續劇情 故觸發後一定會大於dialogueLength
    }
    void ClickFollowUp()
    {
        NPC.index_dialogue = 0;
        NPC.dialogue = followUpDialogue;
        NPC.isContinueDialog = true;

        Debug.Log("followup count:" + NPC.dialogue.Count);
        followUpLength = followUpDialogue.Count;
        mainCamera.isButtonState = false;

        isHaveChange = true;


    }

}

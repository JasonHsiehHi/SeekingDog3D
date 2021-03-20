using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonEffect : MonoBehaviour
{
    public int scenceIndex;

    private NPCDialogue NPC;
    private DialogueButton[] BTNS;
    //private Camera maincamera;

    private Color originalColor = new Color(128, 128, 128);
    private Color changeColor;

    void Awake()
    {
        NPC = this.GetComponent<NPCDialogue>();
        BTNS = GetComponents<DialogueButton>();
        // 為處理物件有多個btn狀況
    }

    void Start()
    {

    }

    void Update()
    {
        Debug.Log("effect dialogue:"+BTNS[0].followUpDialogue[0]);
        Debug.Log("effect index:"+NPC.index_dialogue+ "  effect isHaveChange:" + BTNS[0].isHaveChange);

        if (NPC.index_dialogue > BTNS[0].followUpLength && BTNS[0].isHaveChange)
        {
            changeColor = originalColor;
            InvokeRepeating("ChangeLevelAnimation",2,0.1f);
            SceneManager.LoadScene(scenceIndex);
            RenderSettings.skybox.SetColor("_Tint", originalColor);
            // 要把原本scene的skybox調回來
        }
    }
    void ChangeLevelAnimation()
    {
        changeColor -= Color.white;// 慢慢變黑
        RenderSettings.skybox.SetColor("_Tint", changeColor);
        // 慢慢變暗的轉場動畫
    }

}

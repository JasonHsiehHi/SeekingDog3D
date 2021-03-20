using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueImage : MonoBehaviour
{
    private NPCDialogue NPC;
    private GameObject imageObject;
    private Image animalImage;
    // 只有animal物件需要DialogueImage

    public List<int> indexInserted =new List<int>{ -1 };
    public List<int> indexEnded = new List<int> { -1 };
    public List<Sprite> spritesInserted;
    // 選擇在第幾頁插入圖片indexInserted 並在第幾頁結束插入indexEnded
    //故indexInserted,indexEnded都不能超過NPC.dialogue.Count

    public string firstDiague;
    // 綁第一句話 用此方法辨識按哪一個btn 或 btn前後

    private int index=0;
    // Start is called before the first frame update
    void Awake()
    {
        imageObject = GameObject.Find("Image");
        animalImage = imageObject.GetComponent<Image>();
        NPC = this.GetComponent<NPCDialogue>();
    }

    void Start()
    {

        imageObject.SetActive(false);
    }
// Update is called once per frame
    void Update()
    {
        
        if (firstDiague == NPC.dialogue[0])
        {
            // indexInserted[i]<indexEnded[i] 必定成立
            if (NPC.index_dialogue == indexInserted[index])
            {
                imageObject.SetActive(true);
                animalImage.sprite = spritesInserted[index];
            }
            else if (NPC.index_dialogue == indexEnded[index])
            {
                imageObject.SetActive(false);
                index++; //表示換插入下一張圖
                if (index >= indexInserted.Count)
                    index = 0; //表示重置

            }

        }
    }
}

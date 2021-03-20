using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// script綁在UI Image上
public class AnimalMouse : MonoBehaviour
{
    private NPCDialogue dialogue;
    private int followUpLength;
    private CameraControl m_camera;

    private Image effectImage;
    public Sprite effectPic;

    public float effectTime = 10f;
    private float startTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = transform.parent.GetComponent<NPCDialogue>();
        followUpLength = GetComponent<DialogueButton>().followUpLength;
        this.gameObject.SetActive(false);
        effectImage = this.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.index_dialogue > followUpLength && startTime == 0)
        {
            this.gameObject.SetActive(true);
            startTime = Time.time; // 取得效果開始時間

            // 生成Image GameObject物件 用其中的image Component組件
            // Object.Instantiate(Object original) 用於在遊戲中做出prefab
            // 通常會掛在生成點original_position下 由此物件做生成
            // 生成點為沒有實體的物件
            // Instantiate()與Destroy()用於生成多個重複物件

        }
        if (Time.time > startTime + effectTime)
        {
            this.gameObject.SetActive(false);
            startTime = 0; //player可以二次以上按到

        }

    }
}

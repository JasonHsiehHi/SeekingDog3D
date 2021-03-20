using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 所有的特殊效果都與CameraControl相似
public class AnimalCrocodile : MonoBehaviour
{

    private NPCDialogue dialogue;
    private int followUpLength;
    private CameraControl m_camera;

    public float effectTime = 10f;
    private float startTime=0;

    public float decelerateSpeed = 5f;

    public Color changedColor;
    private Color originalColor = new Color(128, 128, 128);

    // Start is called before the first frame update
    void Start()
    {
        dialogue = transform.parent.GetComponent<NPCDialogue>();
        followUpLength = GetComponent<DialogueButton>().followUpLength;
        this.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.index_dialogue > followUpLength && startTime == 0)
        {
            this.enabled = true;
            startTime = Time.time; // 取得效果開始時間
            RenderSettings.skybox.SetColor("_Tint", changedColor);
        }

        if (Time.time<= startTime + effectTime)
        {
            m_camera.angSpeed -= decelerateSpeed;
            m_camera.fovSpeed -= decelerateSpeed;
        }

        else
        {
            m_camera.angSpeed += decelerateSpeed;
            m_camera.fovSpeed += decelerateSpeed;
            startTime = 0; //player可以二次以上按到
            RenderSettings.skybox.SetColor("_Tint", originalColor);
            // RenderSettings.skybox = skybox_name 直接改skybox圖

        }



    }
}

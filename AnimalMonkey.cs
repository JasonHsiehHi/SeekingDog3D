using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMonkey : MonoBehaviour
{
    private NPCDialogue dialogue;
    private int followUpLength;
    private Camera m_camera;

    public float effectTime = 10f;
    private float startTime = 0;

    private int frameInt = 0;
    public int frameFrequency = 5;

    private Quaternion originalRotation;
    public int effectDegree=5;



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
            originalRotation = m_camera.transform.rotation;

        }

        // InvokeRepeating("method_name",3,0.5f) 3秒之內每0.5秒調用一次
        // 但此方法不能融入參數


        if (Time.time <= startTime + effectTime)
        {
            frameInt++;
            if (frameInt% frameFrequency == 0)
            {
                if(frameInt%2 ==0)
                    m_camera.transform.Rotate(0,0,-effectDegree);
                else
                    m_camera.transform.Rotate(0, 0, effectDegree);

            }    
        }
        else
        {
            m_camera.transform.rotation = originalRotation;
            startTime = 0; //player可以二次以上按到
        }
    }
}

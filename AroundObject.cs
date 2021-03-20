using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 僅用於處理物件與MainCamera之間的距離
[ExecuteInEditMode]
public class AroundObject : MonoBehaviour
{
    public GameObject target;

    public float x;
    public float y;
    public float z;
    public float distance;

    private void OnRenderObject()
    {        
        AroundMove();
    }

    private void AroundMove()
    {
        Quaternion rotation = Quaternion.Euler(y, x, z);

        Vector3 position = target.transform.position + distance * Vector3.up;
        transform.position =  rotation * position + target.transform.position;
        // position為由(0,0,0)向外的向量 沿著rotation的方向轉動
    }


    // catTail
    // position:17.76622,-6.386992,-23.91628
    // rotation:-10.9,-49.8,14.7

    // dogTail
    // position:-35.19642,0.1918787,11.72966
    // rotation:-185.84,-101,-184.4

    // monkeyLeg
    // position:-31.30301,-5.355073,-12.1427
    // rotation:-8.8,51.58,0



    //L1.arrow distance:200 rotation.x=-140
    //position:-193.1909,-37.04811,36.12049
    //rotation:-140,-87.1,0

    //L2.arrow1 distance:230 rotation.x=140
    //position:-222.8436,-51.23932,24.80427
    //rotation:140,-103.7,0

    //L2.arrow2 distance:230 rotation.x=140
    //position:-165.1155,-53.13497,-151.0416
    //rotation:140,-148.8,0

    //L2.arrow3 distance:180 rotation.x=-140
    //position:161.9765,-48.4262,61.79418
    //rotation:-140,-104.3,0


}

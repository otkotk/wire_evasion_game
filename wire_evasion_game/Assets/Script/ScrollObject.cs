using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public float speed;
    public float startPosition;
    public float endPosition;


    // Update is called once per frame
    void Update()
    {
        //毎フレーム、左に向かって移動させる
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        //x=-8 まで来たら、 x=8 に移動する
        if(transform.position.x <= endPosition)
        {
            ScrollEnd();
        }
    }


    void ScrollEnd()
    {
        float diff = transform.position.x - endPosition;
        Vector3 restartPosition = transform.position;
        restartPosition.x = startPosition + diff;
        transform.position = restartPosition;

        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }
}

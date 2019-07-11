using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // makes Unity render 10 frames/sec instead of default 60 frames/sec
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
    }

    // Update is called once per frame
    void Update()
    {
        // ** HORIZONTAL MOVEMNT ** 
        // press left: axis -1, making position.x = -0.1f
        // press right: axis +1, making positon.x = +0.1f.
        // press no key: axis 0, making position 0f;

         //** TIME ** 
        // must update movement speed by multiplying it with time it takes for Unity to render a frame.
        // ex: if game runs 10 frame/sec, each frame takes 0.1 sec. 60 frames/sec = each frame takes 0.0167 sec
        // Time.deltaTime important in making sure character runs at the same speed, regardless of the number of frames rendered by our game.
        // it is now **frame independent**.

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Debug.Log($"(x,t): ({horizontal}, {vertical})");
        Vector2 position = transform.position;
       
        // added Time.deltaTime to make sure movement based on units/seconds not frames/second
        // slightly change to movement code multiplies amount the GameObject moves by the value of the axis.
        position.x = position.x + 3f * horizontal * Time.deltaTime;
        position.y = position.y + 3f * vertical * Time.deltaTime;
        transform.position = position;

    }
}

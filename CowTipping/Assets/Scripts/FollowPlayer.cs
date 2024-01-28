using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float backScale;
    public float upScale;
    public float vert_sens;
    public float horiz_sens;
    Vector3 currentAngle  = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position - player.transform.forward*backScale + player.transform.up*upScale;
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = Quaternion.Euler(new Vector3(0,-180,0));
    }

    // Update is called once per frame
    void Update()
    {
        float horiz  = horiz_sens * Input.GetAxis("Mouse X");
        float vert = -vert_sens * Input.GetAxis("Mouse Y");
        
        
        currentAngle += new Vector3(vert,horiz,0);
        transform.rotation = Quaternion.Euler(currentAngle);
        //player.transform.Rotate(0,horiz,0);
        float cameraY =  transform.rotation.y;
        player.transform.rotation = Quaternion.Euler(0,currentAngle.y,0);
        transform.position = player.transform.position - player.transform.forward*backScale + player.transform.up*upScale;

    }
}

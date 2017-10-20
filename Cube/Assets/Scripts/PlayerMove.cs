using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Transform m_transform, m_camera;//人物自己以及相机的对象
    private CharacterController controller;//Charactor Controller组件
    private Animator anim;
    public float MoveSpeed = 20.0f;//移动的速度
                                   // Use this for initialization
    void Start()
    {
        m_transform = this.transform;//尽量不要再update里获取this.transform，而是这样保存起来，这样能节约性能
        m_camera = GameObject.FindGameObjectWithTag("MainCamera").transform;//
        controller = this.GetComponent<CharacterController>();
        anim = this.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))
        {
            anim.SetBool("walk", true);
            // transform.GetComponent().SetFloat("speed", "run");//将人物的动画改为移动状态，这里有个问题，就是动画组件的获取也要在update里获取，请读者自行修改吧
            if (Input.GetKey(KeyCode.W))
            {
                //根据主相机的朝向决定人物的移动方向，下同
                controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 180f, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 270f, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 90f, 0);
            }

            controller.Move(m_transform.forward * Time.deltaTime * MoveSpeed);
        }
        else anim.SetBool("walk", false);
        //静止状态
        // transform.GetComponent().SetFloat("speed", "stand");
        //if (Input.GetKey(KeyCode.Q))
        //{
           // transform.Translate(Vector3.up * Time.deltaTime * MoveSpeed);
        //}
         if(!controller.isGrounded)
        {
            //模拟简单重力，每秒下降10米，当然你也可以写成抛物线
            controller.Move(new Vector3(0, -10f * Time.deltaTime, 0));
        }





    }
}



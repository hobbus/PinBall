using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;
    private float defaultAngle = 20.0f;
    private float flickAngle = -20.0f;





    // Start is called before the first frame update
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //左矢印キーを押した時左フリッパーを動かす
        if ((Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag"))
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if ((Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag"))
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if ((Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag"))
        {
            SetAngle(this.defaultAngle);
        }
        if ((Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag"))
        {
            SetAngle(this.defaultAngle);
        }

        //１つ以上のタップで実行
        if (Input.touchCount > 0)
        {
            // 1つ目のタッチを取得
            Touch touch0 = Input.GetTouch(0);

            if (touch0.phase == TouchPhase.Began)
            {
                // 1つ目のタッチ位置でフリッパーを操作
                if (touch0.position.x > Screen.width / 2 && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                if (touch0.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
            }
            if (touch0.phase == TouchPhase.Ended && touch0.position.x > Screen.width / 2)
            {
                // フリッパーを元の位置に戻す（右）
                if (tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }
            if (touch0.phase == TouchPhase.Ended && touch0.position.x < Screen.width / 2)
            {
                // フリッパーを元の位置に戻す（左）
                if (tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }

            //2つめのタップで実行
            if (Input.touchCount == 2)
            {
                // 2つ目のタッチも取得
                Touch touch1 = Input.GetTouch(1);

                if (touch1.phase == TouchPhase.Began)
                {
                    Debug.Log("タッチ２開始");

                    // 2つ目のタッチ位置でもう一方のフリッパーを操作
                    if (touch1.position.x > Screen.width / 2 && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }


                    if (touch1.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }

                }
                if (touch1.phase == TouchPhase.Ended && touch1.position.x > Screen.width / 2)
                {
                    // フリッパーを元の位置に戻す（右）
                    if (tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
                if (touch1.phase == TouchPhase.Ended && touch1.position.x < Screen.width / 2)
                {
                    // フリッパーを元の位置に戻す（左）
                    if (tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }

    }





    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}

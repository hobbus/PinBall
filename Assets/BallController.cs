using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    private GameObject ScoreText;

    //スコア加算
    public int Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.ScoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
        ScoreText.GetComponent<Text>().text = "SCORE:" + Score;

    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            Score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            Score += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
        {
            Score += 5;
        }
    }
}

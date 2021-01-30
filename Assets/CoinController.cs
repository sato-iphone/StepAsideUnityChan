using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    //unitychanのオブジェクト
    private GameObject unitychan;

    //coinのRenderer
    private Renderer coinRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のunitychanオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        //Rendererを取得
        this.coinRenderer = GetComponent<Renderer>();

        //回転を開始する角度を設定
        this.transform.Rotate(0, Random.Range(0, 360), 0);

    }

    // Update is called once per frame
    void Update()
    {
        //回転
        this.transform.Rotate(0, 3, 0);

        Debug.Log("Visible");
        //unitychanの位置より後ろ、且つカメラの範囲外の場合、自身を破棄
        if (this.unitychan.transform.position.z > this.transform.position.z && ! this.coinRenderer.isVisible)
        //if (this.unitychan.transform.position.z > this.transform.position.z)
        {
            Debug.Log("not Visible");
            Destroy(this.gameObject);
        }
    }

    /*
    //unitychanの位置より後ろ、且つカメラの範囲外の場合、自身を破棄
    private void OnBecameInvisible()
    {
        Debug.Log("not Visible");
        if (this.unitychan.transform.position.z > this.transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
    */
    
}

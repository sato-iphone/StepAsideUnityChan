using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficConeController : MonoBehaviour
{
    //unitychanのオブジェクト
    private GameObject unitychan;

    //TrafficConeのRenderer
    private Renderer TrafficConeRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のunitychanオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        //Rendererを取得
        this.TrafficConeRenderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //unitychanの位置より後ろ、且つカメラの範囲外の場合、自身を破棄
        if (this.unitychan.transform.position.z > this.transform.position.z && !this.TrafficConeRenderer.isVisible)
        {
            Destroy(this.gameObject);
        }
    }
}

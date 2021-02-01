using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;

    //coinPrefabを入れる
    public GameObject coinPrefab;

    //cornPrefabを入れる
    public GameObject conePrefab;

    //スタート地点(最初にアイテムを出現させる地点)
    private int startPos = 80;

    //ゴール地点
    private int goalPos = 360;

    //アイテムを出す方向xの範囲
    private float posRange = 3.4f;

    //アイテム生成地点とUnityちゃんとの距離。（Unityちゃんがこの距離まで近づいたらアイテムを生成する。）
    private int itemGenDistance = 50;

    //unitychanのオブジェクト
    private GameObject unitychan;

    //アイテム出現位置zを格納した配列
    private float[] itemPosZ;

    //アイテムを生成した回数
    private int itemGenTimes = 0;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のunitychanオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        //アイテムが出現する回数。startPosからz=15間隔固定でアイテム生成する。
        int itemGenTimes = Mathf.FloorToInt((goalPos - startPos) / 15) + 1;

        //アイテム位置を管理する配列を生成・初期化する。
        itemPosZ = new float[itemGenTimes];
        for (int i = 0;i < itemPosZ.Length;i++)
        {
            itemPosZ[i] = startPos + 15 * i;
        }

        /*
        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < goalPos; i += 15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if(num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for(float j =-1;j <= 1; j+= 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);

                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30%車配置：10%何もなし
                    if(1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, carPrefab.transform.position.y, i + offsetZ);
                    }
                    else if(7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);

                    }
                }
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        //次のアイテム出現位置
        float nextItemPosZ = itemPosZ[itemGenTimes];

        //Unityちゃんが次のアイテムの出現位置に達したかどうか判定。（アイテムは出現開始位置からz=15毎に出現する。）
        if (nextItemPosZ < this.unitychan.transform.position.z + itemGenDistance)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, nextItemPosZ);

                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30%車配置：10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, carPrefab.transform.position.y, nextItemPosZ + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, nextItemPosZ + offsetZ);

                    }
                }
            }

            //アイテム出現回数を＋＋
            itemGenTimes++;
        }

    }
}

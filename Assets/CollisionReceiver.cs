using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CollisionReceiver : MonoBehaviour
{
    public GameObject String;
    public GameObject TopPointer;
    public UnityEvent OnColliderStart = null;
    public UnityEvent OnColliderUpdate = null;
    public UnityEvent OnColliderEnd= null;

    public void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Finger":
                Vector3 _fingerposition;
                if(other.gameObject.GetComponent<HandReceiver>().GetTransForm(out _fingerposition))
                {
                    float dist = Vector3.Distance(TopPointer.transform.position, _fingerposition);
                    //取得出来た際の処理
                    if(OnColliderStart != null)
                    {
                        OnColliderStart.Invoke();
                    }
                    Debug.Log("Start : " + dist);
                }
                break;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Finger":
                Vector3 _fingerposition;
                if (other.gameObject.GetComponent<HandReceiver>().GetTransForm(out _fingerposition))
                {
                    float dist = Vector3.Distance(TopPointer.transform.position, _fingerposition);
                    //取得出来た際の処理
                    if (OnColliderStart != null)
                    {
                        OnColliderUpdate.Invoke();
                    }
                    Debug.Log("update : " + dist);
                }
                break;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        // fluctの初期化処理を行う。(開放弦にする。カポ設定とか作るならここでカポの設定にするとかありそう)
        String.GetComponent<StringParm>().Setfluct(1.0f);
        OnColliderEnd.Invoke();
        Debug.Log("Collider Exit");
    }
}

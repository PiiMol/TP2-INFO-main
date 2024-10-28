using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class ControladorJugador_extOSC_Receive_Blob : MonoBehaviour
{
    private Rigidbody body;

    public OSCReceiver osc;

    private Vector3 positionFromOSC;
    private Vector3 velocityFromOSC;

    void Start()
    {
        body = GetComponent<Rigidbody>();

        osc.Bind("/bblobtracker/blobs", ReceivedMessage);
    }

    
    void Update()
    {
        this.transform.position = positionFromOSC;

        //Vector3 movimiento = new Vector3(velocityFromOSC.x, 0, velocityFromOSC.z);

        //body.velocity = movimiento * 10;

        //velocityFromOSC *= 0.98f;
    }

    private void ReceivedMessage(OSCMessage message)
    {
        float x = message.Values[2].FloatValue * 50f - 25f;
        float y = message.Values[3].FloatValue * (-10f) + 5;

        positionFromOSC = new Vector3(y, 0.5f, x * (-1));

        //float x = message.Values[2].FloatValue * 2f - 1f;
        //float y = message.Values[3].FloatValue * 2f - 1f;

        //velocityFromOSC = new Vector3(x, 0, y * (-1));

        //Debug.Log("OnReceiveBlob message " + message);
        Debug.Log("OnReceiveBlob velocity " + positionFromOSC);
    }


}

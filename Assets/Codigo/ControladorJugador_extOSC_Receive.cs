using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class ControladorJugador_extOSC_Receive : MonoBehaviour
{
    private Rigidbody body;

    public OSCReceiver osc;

    private Vector3 velocityFromOSC;

    void Start()
    {
        body = GetComponent<Rigidbody>();

        osc.Bind("/CubeXYZ", ReceivedMessage);
    }


    void Update()
    {
        //float valorH = Input.GetAxis("Horizontal");
        //float valorY = Input.GetAxis("Vertical");

        //Vector3 movimiento = new Vector3(valorH, 0, valorY);

        Vector3 movimiento = new Vector3(velocityFromOSC.x, 0, velocityFromOSC.y);

        //body.AddForce(new Vector3(valorY, 0, valorH));

        body.velocity = movimiento * 5;

        velocityFromOSC *= 0.98f;
    }

    private void ReceivedMessage(OSCMessage message)
    {
        float x = message.Values[0].FloatValue / 1000f;
        float y = message.Values[1].FloatValue / 1000f;

        velocityFromOSC = new Vector3(x, y);

        Debug.Log("OnReceiveXY " + velocityFromOSC);
    }


}

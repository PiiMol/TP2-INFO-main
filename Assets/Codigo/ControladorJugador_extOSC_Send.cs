using UnityEngine;
using extOSC;
using UnityEngine.UIElements;

public class ControladorJugador_extOSC_Send : MonoBehaviour
{
    private Rigidbody body;

    public OSCTransmitter osc;

    private Vector3 velocityFromOSC;


    void Start()
    {
        body = GetComponent<Rigidbody>();
  
    }

    void Update()
    {
        float valorH = Input.GetAxis("Horizontal");
        float valorY = Input.GetAxis("Vertical");

        Debug.Log("Horizontal: " + valorH + " | Vertical: " + valorY);

        Vector3 movimiento = new Vector3(valorH, 0, valorY);

        //body.AddForce(new Vector3(valorY, 0, valorH));

        body.velocity = movimiento * 5;

        var message = new OSCMessage("/UpdateXYZ");
        message.AddValue(OSCValue.Float(transform.position.x));
        message.AddValue(OSCValue.Float(transform.position.y));
        message.AddValue(OSCValue.Float(transform.position.z * (-1)));
        osc.Send(message);
    }

}
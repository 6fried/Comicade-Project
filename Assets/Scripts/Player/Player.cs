using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody body;
    public float jumpPower = 10f;
    public TextMeshProUGUI message;


    private void Update()
    {
        // Déplacement
        float forward = Input.GetAxis("Vertical");
        float leftRight = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(leftRight, 0, forward);
        direction = direction.normalized * speed * Time.deltaTime;

        // Rotation de la camera
        float cameraRotation = Input.GetAxis("Mouse X");
        Vector3 rotateDirection = new Vector3(0, cameraRotation, 0);

        if (Input.GetButtonDown("Jump"))
        {
            Vector3 jumpForce = new Vector3(0, jumpPower, 0);
            body.AddForce(jumpForce, ForceMode.Impulse);
        }

        transform.Translate(direction);
        transform.Rotate(rotateDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Mortal")
        {
            message.text = "You are dead";
            transform.position = new Vector3(0, 1, 0);
            StartCoroutine("ResetMessage");
        }
    }

    private IEnumerator ResetMessage()
    {
        yield return new WaitForSeconds(1);
        message.text = "";
    }
}

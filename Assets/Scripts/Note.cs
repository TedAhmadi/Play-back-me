using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody note_rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        note_rigidBody = this.GetComponent<Rigidbody>();
        //note_rigidBody.velocity = new Vector3(0, 0, -speed * Time.deltaTime/2);
    }
    private void OnCollisionEnter(Collision collision)
    {
       Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        note_rigidBody.velocity = new Vector3(0, 0, -speed * Time.deltaTime / 2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        this.transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }
}

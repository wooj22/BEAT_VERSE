using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    [SerializeField] float speed;
    public bool isMove = true;

    private void Update()
    {
        if (isMove)
        {
            this.transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
    }
}

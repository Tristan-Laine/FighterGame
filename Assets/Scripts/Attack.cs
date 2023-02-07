using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update

    private Player parent;
    void Start()
    {
        parent = transform.parent.GetComponent<Player>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (parent.isPunching() && col.transform.CompareTag(parent.getTarget()))
        {
            col.gameObject.GetComponent<Player>().lostPV(10f);
        }
    }
}

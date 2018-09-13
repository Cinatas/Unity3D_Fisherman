using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRaycast : MonoBehaviour {
    public bool isShow;
    public float radius;
    public AstarPath ai;
    List<string> blockIdList;
	// Use this for initialization
	void Start () {
        blockIdList = new List<string>();
        StartCoroutine(ReScans());
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right);

        Collider2D[] cs = Physics2D.OverlapCircleAll(this.transform.position, radius);

        foreach(var i in cs)
        {
            if (i.gameObject.layer != 8)
                i.gameObject.layer = 8;
        }
        
    }

    IEnumerator ReScans()
    {
        while (true)
        {
            yield return ai.ScanAsync();
        }
    }

    private void OnDrawGizmos()
    {
        if(isShow)
        Gizmos.DrawSphere(this.transform.position, radius);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDisplay : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(gameObject.transform.position.x, -3.55f, 3.55f);
        float y = Mathf.Clamp(gameObject.transform.position.y, -4.4f, 4.4f);

        transform.position = new Vector2(x, y);
    }
}

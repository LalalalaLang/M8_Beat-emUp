using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class followPlayer : MonoBehaviour
{
    public GameObject playerOne;
    private Vector3 camPlayer = new Vector3(0, 0, -10);

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if( playerOne.transform.position.x >= transform.position.x)
        {
         transform.position = new Vector3(playerOne.transform.position.x, transform.position.y, -10);
        }



    }
}

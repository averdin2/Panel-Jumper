using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PanelGeneration : MonoBehaviour
{

    public GameObject panel;
    public Transform genPoint;
    public float distanceBtwn;

    private float panelSpace;
    private float maxDistanceBtwn = 8;
    private float tempPlayerScore = 0;

    // If scoring is changed in playerController this value must be adjusted
    private float score = 5000;

    // Use this for initialization
    void Start()
    {

        // Creates space so panels cannot be overlapped vertically
        panelSpace = panel.GetComponent<BoxCollider2D>().size.y;

        // Creates an initial randomly generated panel
        transform.position = new Vector3(Random.Range(-3.21f, 3.21f), transform.position.y, transform.position.z);
        Instantiate(panel, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < genPoint.position.y)
        {
            PlayerController playerController = GameObject.Find("Character").GetComponent<PlayerController>();
            if (playerController.playerScore > tempPlayerScore)
            {
                tempPlayerScore += score;
                if (distanceBtwn == maxDistanceBtwn)
                {
                    distanceBtwn = 8;
                }
                else
                {
                    distanceBtwn++;
                }
            }
            transform.position = new Vector3(Random.Range(-3.21f, 3.21f), transform.position.y + panelSpace + distanceBtwn, transform.position.z);
            Instantiate(panel, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }
}

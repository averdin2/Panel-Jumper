using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PanelGeneration : MonoBehaviour
{

    public GameObject defaultPanel;
    public GameObject boostPanel;
    public GameObject badPanel;
    public GameObject ultraPanel;

    public GameObject[] panelSelector;

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
        // Creating array of panels to be selected at random
        panelSelector = new GameObject[4];
        panelSelector[0] = defaultPanel;
        panelSelector[1] = boostPanel;
        panelSelector[2] = badPanel;
        panelSelector[3] = ultraPanel;


        // Creates space so panels cannot be overlapped vertically
        //panelSpace = defaultPanel.GetComponent<BoxCollider2D>().size.y;
        panelSpace = 0.75f;

        // Creates an initial randomly generated panel
        transform.position = new Vector3(Random.Range(-3.21f, 3.21f), transform.position.y, transform.position.z);
        Instantiate(defaultPanel, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < genPoint.position.y)
        {
            // this is supposed to be for balancing the distance between panels as the game gets harder but is broken at its current state
            // it used to work so be careful changing it
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
                    distanceBtwn = 0;
                }
            }
            int n = Random.Range(0, 4);
            transform.position = new Vector3(Random.Range(-3.21f, 3.21f), transform.position.y + panelSpace + distanceBtwn, transform.position.z);
            Instantiate(panelSelector[n], transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    private string currentLocation = "Cell";

    private GameObject cellObject;
    private GameObject recroomObject;
    private GameObject workoutroomObject;

    // Start is called before the first frame update
    void Start()
    {
        cellObject = GameObject.Find("Cell");
        recroomObject = GameObject.Find("Recroom");
        workoutroomObject = GameObject.Find("Workoutroom");

        recroomObject.SetActive(false);
        workoutroomObject.SetActive(false);
        cellObject.SetActive(true);
    }

    public void changeRoom()
    {
        if (currentLocation == "Cell")
        {
            currentLocation = "Recroom";
            updateRoom(cellObject, recroomObject);
        }
        else if(currentLocation == "Recroom")
        {
            currentLocation = "Workoutroom";
            updateRoom(recroomObject, workoutroomObject);
        }
        else if(currentLocation == "Workoutroom")
        {
            currentLocation = "Cell";
            updateRoom(workoutroomObject, cellObject);
        }
    }

    void updateRoom(GameObject oldRoom, GameObject newRoom)
    {
        oldRoom.SetActive(false);
        newRoom.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

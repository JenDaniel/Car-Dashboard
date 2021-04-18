using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardViews : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }
  bool isActiveGoodTire = false;
    bool isActiveTripDetails = false;
    bool isActiveNavigationRoute = false;

    public GameObject goodTire;
    public GameObject tripDetails;
    public GameObject navigationRoute;
    // // Update is called once per frame
    void Update()
    {
        goodTire.SetActive(isActiveGoodTire);
        tripDetails.SetActive(isActiveTripDetails);
        navigationRoute.SetActive(isActiveNavigationRoute);

    }

  

    public void toggleTire()
    {
        isActiveGoodTire =! isActiveGoodTire;
        isActiveTripDetails = false;
        isActiveNavigationRoute = false;
    }

    public void toggleTrip()
    {
        isActiveGoodTire = false;
        isActiveTripDetails =! isActiveTripDetails;
        isActiveNavigationRoute = false;
    }

    public void toggleNavigation()
    {
        Debug.Log(isActiveNavigationRoute);
        isActiveGoodTire = false;
        isActiveTripDetails = false;
        isActiveNavigationRoute =! isActiveNavigationRoute;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCanvasManager : MonoBehaviour
{
    public static WorldCanvasManager instance;

    [SerializeField]
    private TowersPanel towersPanel;

    private bool towersPanelOpened = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowTowersPanel(TowerPlaceScript TPSReference)
    {
        //Moves tower selection menu to selected tower and shows the options. Also asigns the references to where the tower will be spawned.
        towersPanel.GetComponent<RectTransform>().position = TPSReference.transform.position;
        towersPanel.Show();
        towersPanel.RemoveBuyEvents();
        towersPanel.AddBuyEvents(TPSReference);
    }

    public void HideTowersPanel()
    {
        towersPanel.Hide();
        towersPanelOpened = false;
    }

    public bool IsTowersPanelOpened()
    {
        return towersPanelOpened;
    }

    public void SetTowersPanelOpened(bool state)
    {
        towersPanelOpened = state;
    }

}

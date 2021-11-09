using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCanvasManager : MonoBehaviour
{
    public static WorldCanvasManager instance;

    [SerializeField]
    private TowersPanel towersPanel;
    [SerializeField]
    private TowersPanel2 towersPanel2;

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
        StartCoroutine(SetTowersPanelOpened(true));
        towersPanel.GetComponent<RectTransform>().position = TPSReference.transform.position;
        towersPanel.Show();
        towersPanel.RemoveBuyEvents();
        towersPanel.AddBuyEvents(TPSReference);
    }

    public void HideTowersPanel()
    {
        towersPanel.Hide();
        StartCoroutine(SetTowersPanelOpened(false));
    }

    public void ShowTowersPanel2(TowerPlaceScript TPSReference)
    {
        //Moves tower selection menu to selected tower and shows the options. Also asigns the references to what tower will be modified.
        StartCoroutine(SetTowersPanelOpened(true));
        towersPanel2.GetComponent<RectTransform>().position = TPSReference.transform.position;
        towersPanel2.Show();
        towersPanel2.RemoveEvents();
        towersPanel2.AddEvents(TPSReference);
    }

    public void HideTowersPanel2()
    {
        towersPanel2.Hide();
        StartCoroutine(SetTowersPanelOpened(false));
    }

    public bool IsTowersPanelOpened()
    {
        return towersPanelOpened;
    }

    IEnumerator SetTowersPanelOpened(bool state)
    {
        yield return new WaitForSeconds(.2f);
        towersPanelOpened = state;
    }

}

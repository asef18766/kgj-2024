using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //slider component
    public Slider slider;

    //slider textmeshpro component
    public TextMeshProUGUI sliderText;

    //carrying score value
    public TextMeshProUGUI carryingScore;


    public GameObject starPrefab; // Assign your Star prefab here in the Inspector
    public RectTransform startPosObject; // Assign StartPoint GameObject here
    public RectTransform endPosObject; // Assign EndPoint GameObject here
    public float journeyTime = 5f; // Duration of the movement
    public float sliderLerpTime = 1f; // Duration of the movement

    // Update is called once per frame
    void Update()
    {

    }

    //add value to slider
    public void AddValueToSlider(float value)
    {
        slider.value += value;
        //update slider textmesh pro component
        sliderText.text = slider.value.ToString();
        FlyStar();
    }

    //set the value of carrying score
    public void SetCarryingScore(int value)
    {
        carryingScore.text = value.ToString();
    }



    //set the value of slider and make it lerp to the value
    public void SetSliderValue(float value)
    {
        //set the slider value to the value
        slider.value = value;
        sliderText.text = slider.value.ToString();
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    //sprite stars flying from startPosObject position to endPosObject position in the UI canvas
    public void FlyStar()
    {
        StartCoroutine(MoveStar());
    }
    // Coroutine to move the star
    IEnumerator MoveStar()
    {
        // Instantiate the star prefab
        GameObject star = Instantiate(starPrefab, startPosObject.position, Quaternion.identity);
        //put the star in the canvas
        star.transform.SetParent(GameObject.Find("Canvas").transform);

        //make the star scale to 0.5
        star.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Get the RectTransform component of the star
        RectTransform starRectTransform = star.GetComponent<RectTransform>();
        // Get the start position of the star
        Vector3 startPos = startPosObject.position;
        // Get the end position of the star
        Vector3 endPos = endPosObject.position;
        // Get the start time of the star movement
        float startTime = Time.time;
        // Calculate the distance between the start and end positions
        float distance = Vector3.Distance(startPos, endPos);
        // Loop until the star reaches the end position
        while (starRectTransform.position != endPos)
        {
            // Calculate the time since the journey started
            float elapsedTime = Time.time - startTime;
            // Calculate the fraction of the journey covered
            float fractionOfJourney = elapsedTime / journeyTime;
            // Move the star from the start position to the end position
            starRectTransform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            // Wait for the next frame
            yield return null;
        }
        // Destroy the star after reaching the end position
        Destroy(star);

        //display message
        Debug.Log("Star has reached the end position");
    }
}

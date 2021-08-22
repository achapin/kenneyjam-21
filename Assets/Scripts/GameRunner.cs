using UnityEngine;

public class GameRunner : MonoBehaviour
{
    private Vector3 windDirection;
    public Vector3 WindDirection => windDirection;
    private float timeUntilWindShifts;
    private Vector3 newWindDirection;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilWindShifts = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (newWindDirection != Vector3.zero)
        {
            windDirection = Vector3.Slerp(windDirection, newWindDirection, .1f);
            if (Vector3.Dot(windDirection, newWindDirection) > .99f)
            {
                newWindDirection = Vector3.zero;
                timeUntilWindShifts = Random.Range(2f, 10f);
            }
        }

        if (timeUntilWindShifts >= 0f)
        {
            timeUntilWindShifts -= Time.deltaTime;
        }

        if (timeUntilWindShifts < 0f && newWindDirection == Vector3.zero)
        {
            Vector2 randomXY = Random.insideUnitCircle;
            newWindDirection = new Vector3(randomXY.x, 0f, randomXY.y);
            newWindDirection *= Random.Range(300f, 1500f);
            Debug.Log($"Set new Wind direction to {newWindDirection}");
        }
    }
}

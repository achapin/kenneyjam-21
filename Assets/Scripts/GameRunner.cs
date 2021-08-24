using UnityEngine;

public class GameRunner : MonoBehaviour
{
    private Vector3 windDirection;
    public Vector3 WindDirection => windDirection;
    private float timeUntilWindShifts;
    private Vector3 newWindDirection;
    [SerializeField] private Vector2 windShiftMinMax;
    [SerializeField] private Vector2 windSpeedMinMax;

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

            windDirection = Vector3.RotateTowards(windDirection,
                newWindDirection,
                Mathf.PI * Time.deltaTime,
                newWindDirection.magnitude * Time.deltaTime);
            if (Vector3.Dot(windDirection.normalized, newWindDirection.normalized) > .99f)
            {
                windDirection = newWindDirection;
                newWindDirection = Vector3.zero;
                timeUntilWindShifts = Random.Range(windShiftMinMax.x, windShiftMinMax.y);
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
            newWindDirection *= Random.Range(windSpeedMinMax.x, windSpeedMinMax.y);
            Debug.Log($"Set new Wind direction to {newWindDirection}");
        }
    }
}

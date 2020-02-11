using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

	// Use this for initialization
	void Start () {
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveInPath();
    }

    public void setWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void MoveInPath()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementPerFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementPerFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

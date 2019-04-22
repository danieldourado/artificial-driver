using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    // Toggles the time scale between 1 and 0.7
    // whenever the user hits the Fire1 button.
    public float timescale = 1;
    void Update()
    {
        Time.timeScale = timescale;
            // Adjust fixed delta time according to timescale
            // The fixed delta time will now be 0.02 frames per real-time second
        //Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
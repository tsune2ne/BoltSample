using UnityEngine;
using UnityEngine.SceneManagement;

namespace Title
{
    public class Controller : MonoBehaviour
    {
        public void OnClickGameStart()
        {
            SceneManager.LoadScene("StateGraphSampleScene");
        }
    }
}

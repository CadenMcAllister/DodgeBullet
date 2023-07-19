   using UnityEngine;
   using UnityEngine.UI;
   using UnityEngine.SceneManagement;
   public class LogicScript : MonoBehaviour
   {
       private Summon script;
       public int playerScore;
       public Text scoreText;

       private bool passed;

       void Start(){
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<Summon>();
       }

       public void addScore(int scoreToAdd)
       {
        if (!passed){
           playerScore += scoreToAdd;
           scoreText.text = playerScore.ToString();
        }
           passed = true;
           Invoke("resetPassed", 15);
           script.ammoCounter = 7;
           
       }


      public void restarGame(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
       void resetPassed(){
        passed = false;
       }
   }

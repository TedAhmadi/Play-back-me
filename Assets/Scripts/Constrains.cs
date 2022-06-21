using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constrains : MonoBehaviour
{
    //public static int count = 0;
    public int count = 0;
    public List <string> ExpertModelBatch;
    public string NameOfBatch;
    public Play playerInput;
    public AudioPlay playAudio;

    public bool doubleflag = true;


    // Start is called before the first frame update

    public ShortTermStudentModel shortTermStudentModel;
    public LongTermStudentModel longTermStudentModel;

    void Start()
    {
        doubleflag = true;
    }

    public void CheckConstrain(GameObject Constrain)
    {
        //print("Yaaay" + ExpertBatch.Count+ " ----"+ count);
        if (count >= ExpertModelBatch.Count)
        {
            ExpertModelBatch.Add("0");
            //print("Yaaay");
        }
        if (Constrain.name == ExpertModelBatch[count])
        {
            //print("yaay");
            //GameObject.Find("ShortTermStudentModel").GetComponent<ShortTermStudentModel>().Addtolist(("_"+ Constrain.name), 1);
            shortTermStudentModel.Addtolist(("_" + Constrain.name), "Hit");
            playerInput.key = Constrain.name;
            playerInput.supposedPlayKey = ExpertModelBatch[count];
            playerInput.hitormiss = "Hit";
            playerInput.keyTime = Time.time;
            playerInput.PlayedCLFlag = true;
            playerInput.PlayedEyeFlag = true;
            playerInput.PlayedFixationFlag = true;
            playerInput.PlayedShimmarFlag = true;
            playerInput.PlayedEEGFlag = true;
            
        }
        else
        {
            //print("Miss");
            //GameObject.Find("ShortTermStudentModel").GetComponent<ShortTermStudentModel>().Addtolist(("_" + Constrain.name), 0);
            shortTermStudentModel.Addtolist(("_" + Constrain.name), "Miss");
            playerInput.key = Constrain.name;
            playerInput.supposedPlayKey = ExpertModelBatch[count];
            playerInput.hitormiss = "Miss";
            playerInput.keyTime = Time.time;
            playerInput.PlayedCLFlag = true;
            playerInput.PlayedEyeFlag = true;
            playerInput.PlayedFixationFlag = true;
            playerInput.PlayedShimmarFlag = true;
            playerInput.PlayedEEGFlag = true;
        }

        playAudio.play(Constrain.name);

        count++;
    }
}

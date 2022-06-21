using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class deployBatchVisualizer : MonoBehaviour
{
    public GameObject NotePrefab;
    public Constrains BatchNote;
    public GameObject blank;
    public Play playBatch;

    private GameObject piano;
    public AudioPlay playAudio;

    private Color HighlightColor = Color.green;
    private Color OriginalColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {

    }
    public async void NoteVisualizer()
    {
        if (BatchNote.doubleflag)
        {
            BatchNote.count = 0;
            await Task.Delay(2000);
            for (int i = 0; i < BatchNote.ExpertModelBatch.Count; i++)
            {
                string PianoKey = BatchNote.ExpertModelBatch[i];
                piano = GameObject.Find(PianoKey);
                playAudio.play(PianoKey);
                //tasks[i] = play(piano);
                await Task.WhenAll(play(piano));
                //noteDeployer(piano, .20f, i+1);
            }
            //await Task.WhenAll(tasks);
            await Task.Delay(800);
            blank.SetActive(true);
            await Task.Delay(3000);
            blank.SetActive(false);
            playBatch.playStart = Time.time;
            playBatch.playBatchName = BatchNote.NameOfBatch;
            playBatch.PlayCLFlag = true;
            playBatch.PlayEyeFlag = true;
            playBatch.PlayFixationFlag = true;
            playBatch.PlayShimmarFlag = true;
            playBatch.PlayEEGFlag = true;

            //print("finished");
        }
    }
    private void noteDeployer(GameObject key, float size, int order)
    {
        GameObject Note = Instantiate(NotePrefab) as GameObject;
        Note.name = "Note" + BatchNote.ExpertModelBatch[order-1];
        Note.transform.position = key.transform.position;
        Note.transform.position += Vector3.forward;
        Note.transform.position += Vector3.forward * (order * .25f);
        Note.transform.localScale += new Vector3(0 ,0 ,size) ;
    }

    async Task play(GameObject piano)
    {
        //print("haaay" + piano.transform.name.ToString());
        //print("haaay" + piano.GetComponentInChildren<MeshRenderer>().transform.name.ToString());
        //try
        //{
        //    OriginalColor = piano.GetComponentInChildren<MeshRenderer>().material.color;
        //}
        //catch (System.Exception exception)
        //{
        //    Debug.LogException(exception);
        //}
        //GameObject Note = Instantiate(NotePrefab) as GameObject;
        //Note.transform.position = piano.transform.position;
        //Note.GetComponent<MeshRenderer>().material.color = HighlightColor;
        piano.GetComponentInChildren<MeshRenderer>().material.color = HighlightColor;
        
        await Task.Delay(800);
        piano.GetComponentInChildren<MeshRenderer>().material.color = OriginalColor;
        //Destroy(Note);
    }
}

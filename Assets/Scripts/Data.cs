using Tobii.G2OM;
using Tobii.XR;
using Tobii.XR.Examples;
using UnityEngine;
using UnityEngine.Events;
using ViveSR.anipal.Eye;
using ViveSR.anipal;
using System.Collections.Generic;
using System.IO;
using System;
using HP.Omnicept.Messaging.Messages;


/// <summary>
/// Monobehaviour which can be put on the player's controller to allow grabbing a <see cref="GazeGrabbableObject"/> by looking at it and pressing a button on the controller.
/// </summary>
[RequireComponent(typeof(ControllerManager))]
    public class Data : MonoBehaviour
    {
        [SerializeField]
        private bool showEyeTrackingMessages = true;
        [SerializeField]
        private bool showCognitiveLoadMessages = true;
        public string lastSample = String.Empty;
        public string clSample = String.Empty;
        public string FixationSample = String.Empty;
        public bool StudyShimmerFlag, StudyEEGFlag;

        public Constrains BatchNote;
        public Play playBatch;

        public string LastNameOfBatch;
        private bool StudyFixationFlag, StudyCLFlag, StudyEyeFlag;
        public float StartBatchTime;

        private float _lastFocusTime = 0f;
        private GameObject _lastFocusedObject, _currentFocusedObject;
        private static EyeData eyeData = new EyeData();

        public List<GameObject> gazedObjects;
        public List<string> gazed_on_Objects_Names;
        public List<float> duration_of_Fixation;

        private StreamWriter FixationWriter;
        private string Fixationpath;

        private StreamWriter EyeWriter;
        private string Eyepath;

        private StreamWriter CLWriter;
        private string CLpath;

        private bool writerFlag;


    // Start is called before the first frame update

    //int m_frameCounter = 0;
    //float m_timeCounter = 0.0f;
    //float m_lastFramerate = 0.0f;
    //public float m_refreshTime = 0.5f;                                                                                                                              


        void Start()
        {
            SRanipal_Eye_API.GetEyeData(ref eyeData);
            _lastFocusedObject = null;
            LastNameOfBatch = null;

            Fixationpath = Application.persistentDataPath + "/" + playBatch.ID + "/" + "/FixationSample.txt";
            FixationWriter = new StreamWriter(Fixationpath, true);

            Eyepath = Application.persistentDataPath + "/" + playBatch.ID + "/eye.txt";
            EyeWriter = new StreamWriter(Eyepath, true);

            CLpath = Application.persistentDataPath + "/" + playBatch.ID + "/CL.txt";
            CLWriter = new StreamWriter(CLpath, true);

            writerFlag = true;
        }

        // Update is called once per frame
        void Update()
        {

            //if (m_timeCounter < m_refreshTime)
            //{
            //    m_timeCounter += Time.deltaTime;
            //    m_frameCounter++;
            //}
            //else
            //{
            //    //This code will break if you set your m_refreshTime to 0, which makes no sense.
            //    m_lastFramerate = (float)m_frameCounter / m_timeCounter;
            //    m_frameCounter = 0;
            //    m_timeCounter = 0.0f;
            //}
        //Check if is first time batch name
        if (BatchNote.NameOfBatch != LastNameOfBatch)
            {
                StartBatchTime = Time.time;
                StudyFixationFlag = true;
                StudyCLFlag = true;
                StudyEyeFlag = true;
                StudyShimmerFlag = true;
                StudyEEGFlag = true;
                LastNameOfBatch = BatchNote.NameOfBatch;
                //print("Time: " + StartBatchTime);
            }else {  }

            //Check whether TobiiXR has any focused objects.
            if (TobiiXR.FocusedObjects.Count > 0)
            {
                _currentFocusedObject = TobiiXR.FocusedObjects[0].GameObject;
                //print("change:" + _currentFocusedObject);
                //_lastFocusTime = Time.time;
                // Do something with the focused game object
            }
            else
            {
                _currentFocusedObject = null;
                //print("yaaaaay"+ _currentFocusedObject);
            }

            if (_lastFocusedObject != _currentFocusedObject)
            {
                //print("Focus Object Changed. last Object is :" + _lastFocusedObject + ". Time it took : " + (Time.time - _lastFocusTime));
                duration_of_Fixation.Add((Time.time - _lastFocusTime));
                gazedObjects.Add(_lastFocusedObject);
                if (_lastFocusedObject != null) 
                {
                    gazed_on_Objects_Names.Add(_lastFocusedObject.name); 
                } 
                else 
                { 
                    gazed_on_Objects_Names.Add("None"); 
                }
                _lastFocusTime = Time.time;
                _lastFocusedObject = _currentFocusedObject;
                if (writerFlag)
                {
                    Writer(gazed_on_Objects_Names, duration_of_Fixation);
                }
                else { }
            }
            //Debug.Log("Last FPS is: "+m_lastFramerate);
            //Writer(gazed_on_Objects_Names, duration_of_Fixation);
        }
        public void Writer(List<string> gazed_on_Objects_Names, List<float> duration_of_Fixation)
        {

            FixationSample = "Timestamp: " + Time.time + "   gazed_on_Objects_Names: " + gazed_on_Objects_Names[gazed_on_Objects_Names.Count - 1] + "  duration_of_Fixation: " + duration_of_Fixation[duration_of_Fixation.Count - 1];
            //string path = Application.persistentDataPath + "/FixationSample.txt";
            //Write some text to the test.txt file C:\Users\tedah\AppData\LocalLow\DefaultCompany\Piano_Leap_Motion_Vive-Eye_Tracker
            //StreamWriter writer = new StreamWriter(path, true);
            if (StudyFixationFlag)
            {
                StudyFixationFlag = false;
                string starter = "Timestamp: " + StartBatchTime + " Study " + LastNameOfBatch;
            FixationWriter.WriteLine(starter);
            }
            else { }
            if(playBatch.PlayFixationFlag)
            {
                playBatch.PlayFixationFlag = false;
                string starter = "Timestamp: " + playBatch.playStart + " Play " + playBatch.playBatchName;
            FixationWriter.WriteLine(starter);
            }
            else { }
            if(playBatch.PlayedFixationFlag)
            {
                playBatch.PlayedFixationFlag = false;
                string inputkey = "Timestamp: " + playBatch.keyTime + " " + playBatch.playBatchName + "_" + playBatch.supposedPlayKey + " PlayedKey: " + playBatch.key + " " + playBatch.hitormiss + " supposedPlayKey: " + playBatch.supposedPlayKey;
            FixationWriter.WriteLine(inputkey);
            }
            else { }
        FixationWriter.WriteLine(FixationSample);
            //writer.Close();
        }
        public void EyeTrackingHandler(EyeTracking eyeTracking)
        {
            if (writerFlag && showEyeTrackingMessages && eyeTracking != null)
            {
                lastSample = eyeTracking.ToString();

                if (_lastFocusedObject != null)
                {
                    lastSample = "Timestamp: "+ Time.time  + "  Object Name: " + _lastFocusedObject.name + " "+ lastSample;
                }
                else
                {
                    lastSample = "Timestamp: " + Time.time + "  Object Name: None" + " " + lastSample;
                }

                //string path = Application.persistentDataPath + "/eye.txt";
                //Write some text to the test.txt file C:\Users\tedah\AppData\LocalLow\DefaultCompany\Piano_Leap_Motion_Vive-Eye_Tracker
                //StreamWriter writer = new StreamWriter(path, true);
                if (StudyEyeFlag)
                {
                    StudyEyeFlag = false;
                    string starter = "Timestamp: " + StartBatchTime + " Study " + LastNameOfBatch;
                EyeWriter.WriteLine(starter);
                }
                else { }
                if (playBatch.PlayEyeFlag)
                {
                    playBatch.PlayEyeFlag = false;
                    string starter = "Timestamp: " + playBatch.playStart + " Play " + playBatch.playBatchName;
                EyeWriter.WriteLine(starter);
                }
                else { }
                if (playBatch.PlayedEyeFlag)
                {
                    playBatch.PlayedEyeFlag = false;
                    string inputkey = "Timestamp: " + playBatch.keyTime + " " + playBatch.playBatchName + "_" + playBatch.supposedPlayKey + " PlayedKey: " + playBatch.key + " " + playBatch.hitormiss + " supposedPlayKey: " + playBatch.supposedPlayKey;
                EyeWriter.WriteLine(inputkey);
                }
                else { }
            EyeWriter.WriteLine(lastSample);
                //writer.Close();

                //Debug.Log(eyeTracking);
            }
        }
        public void CognitiveLoadHandler(CognitiveLoad cl)
        {
            if (writerFlag && showCognitiveLoadMessages && cl != null)
            {
                clSample = cl.ToString();

                if (_lastFocusedObject != null)
                {
                    clSample = "Timestamp: " + Time.time + "  " + clSample;
                }
                else
                {
                    clSample = "Timestamp: " + Time.time + "  " + clSample;
                }
            
                //string path = Application.persistentDataPath + "/CL.txt";
                //Write some text to the test.txt file C:\Users\tedah\AppData\LocalLow\DefaultCompany\Piano_Leap_Motion_Vive-Eye_Tracker
                //StreamWriter writer = new StreamWriter(path, true);
                if (StudyCLFlag)
                {
                    StudyCLFlag = false;
                    string starter = "Timestamp: " + StartBatchTime + " Study " + LastNameOfBatch;
                CLWriter.WriteLine(starter);
                }
                else { }
                if (playBatch.PlayCLFlag)
                {
                    playBatch.PlayCLFlag = false;
                    string starter = "Timestamp: " + playBatch.playStart + " Play " + playBatch.playBatchName;
                CLWriter.WriteLine(starter);
                }
                else { }
                if (playBatch.PlayedCLFlag)
                {
                    playBatch.PlayedCLFlag = false;
                    string inputkey = "Timestamp: " + playBatch.keyTime + " " + playBatch.playBatchName + "_" + playBatch.supposedPlayKey + " PlayedKey: " + playBatch.key + " " + playBatch.hitormiss + " supposedPlayKey: " + playBatch.supposedPlayKey;
                CLWriter.WriteLine(inputkey);
                }
                else { }
            CLWriter.WriteLine(clSample);
                //writer.Close();
                //Debug.Log(cl);
            }
        }
    public void onclose()
    {
        writerFlag = false;
        FixationWriter.Close();
        EyeWriter.Close();
        CLWriter.Close();
        Debug.Log("Writers are Closed now!");
    }
}

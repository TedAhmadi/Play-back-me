using UnityEngine;
using System;
using System.Linq;
using Assets.LSL4Unity.Scripts.AbstractInlets;
using System.IO;


namespace Assets.LSL4Unity.Scripts.Examples
{
    /// <summary>
    /// Just an example implementation for a Inlet recieving float values // obci_eeg1 // EEG
    /// </summary>
    public class EEGLSLData : InletFloatSamples
    {
        private bool pullSamplesContinuously = false;
        private string lastSample = String.Empty;

        public Data dataInf;
        private StreamWriter EEGwriter;
        private string EEGpath;
        //private bool EEGcloseFlag;

        void Start()
        {
            EEGpath = Application.persistentDataPath + "/" + dataInf.playBatch.ID + "/EEG.txt";
            //Write some text to the test.txt file C:\Users\tedah\AppData\LocalLow\DefaultCompany\Lsl-test
            EEGwriter = new StreamWriter(EEGpath, true);
            //EEGcloseFlag = true;
        }

        private void Update()
        {
            if (pullSamplesContinuously == true)
            {
                pullSamples();
            }
        }

        protected override bool isTheExpected(LSLStreamInfoWrapper stream)
        {
            // the base implementation just checks for stream name and type
            var predicate = base.isTheExpected(stream);
            // add a more specific description for your stream here specifying hostname etc.
            //predicate &= stream.HostName.Equals("Expected Hostname");
            return predicate;
        }

        protected override void Process(float[] newSample, double timeStamp)
        {
            //if (EEGcloseFlag)
            //{
                // just as an example, make a string out of all channel values of this sample
                lastSample = string.Join(" ", newSample.Select(c => c.ToString()).ToArray());
                //Debug.Log(lastSample);
                lastSample = "Timestamp: " + Time.time + ",,,,,,,1 " + lastSample;

                //string path = Application.persistentDataPath + "/EEG.txt";
                ////Write some text to the test.txt file C:\Users\tedah\AppData\LocalLow\DefaultCompany\Lsl-test
                //StreamWriter writer = new StreamWriter(path, true);

                if (dataInf.StudyEEGFlag)
                {
                    dataInf.StudyEEGFlag = false;
                    string starter = "Timestamp: " + dataInf.StartBatchTime + " 1 Study" + dataInf.LastNameOfBatch;
                    EEGwriter.WriteLine(starter);
                }
                else { }
                if (dataInf.playBatch.PlayEEGFlag)
                {
                    dataInf.playBatch.PlayEEGFlag = false;
                    string starter = "Timestamp: " + dataInf.playBatch.playStart + " 1 Play" + dataInf.playBatch.playBatchName;
                    EEGwriter.WriteLine(starter);
                }
                else { }
                if (dataInf.playBatch.PlayedEEGFlag)
                {
                    dataInf.playBatch.PlayedEEGFlag = false;
                    string inputkey = "Timestamp: " + dataInf.playBatch.keyTime + " 1 "+ dataInf.playBatch.playBatchName + "_"+ dataInf.playBatch.supposedPlayKey + " PlayedKey: " + dataInf.playBatch.key + " " + dataInf.playBatch.hitormiss + " supposedPlayKey: " + dataInf.playBatch.supposedPlayKey;
                    EEGwriter.WriteLine(inputkey);
                }
                else { }

                EEGwriter.WriteLine(lastSample);
                //writer.Close();

                //Debug.Log(
                //    string.Format("Got {0} samples at {1},  {2}", newSample.Length, timeStamp , path)
                //    );
           // }
        }
        protected override void OnStreamAvailable()
        {
            pullSamplesContinuously = true;
        }

        protected override void OnStreamLost()
        {
            pullSamplesContinuously = false;
        }

        public void onclose()
        {
            pullSamplesContinuously = false;
            EEGwriter.Close();
        }
    }
}

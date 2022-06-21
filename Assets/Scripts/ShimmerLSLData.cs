using UnityEngine;
using System;
using System.Linq;
using Assets.LSL4Unity.Scripts.AbstractInlets;
using System.IO;

namespace Assets.LSL4Unity.Scripts.Examples
{
    /// <summary>
    /// Just an example implementation for a Inlet recieving float values
    /// </summary>
    public class ShimmerLSLData : InletFloatSamples
    {
        private bool pullSamplesContinuously = false;
        private string lastSample = String.Empty;

        public Data dataInf;
        private StreamWriter Shimmerwriter;
        private string Shimmerpath;
        //private bool shimmarcloseFlag;

        void Start()
        {
            Shimmerpath = Application.persistentDataPath + "/" + dataInf.playBatch.ID + "/Shimmer.txt";
            //Write some text to the test.txt file C:\Users\tedah\AppData\LocalLow\DefaultCompany\Lsl-test
            Shimmerwriter = new StreamWriter(Shimmerpath, true);
            //shimmarcloseFlag = true;
        }

        private void Update()
        {
            if(pullSamplesContinuously == true)
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
            //if (shimmarcloseFlag)
            //{
                // just as an example, make a string out of all channel values of this sample
                lastSample = string.Join(" ", newSample.Select(c => c.ToString()).ToArray());
                lastSample = "Timestamp: " + Time.time + " " + lastSample;

                //string path = Application.persistentDataPath + "/Shimmer.txt";
                //Write some text to the test.txt file C:\Users\tedah\AppData\LocalLow\DefaultCompany\Lsl-test
                //StreamWriter writer = new StreamWriter(path, true);

                if (dataInf.StudyShimmerFlag)
                {
                    dataInf.StudyShimmerFlag = false;
                    string starter = "Timestamp: " + dataInf.StartBatchTime + " Study " + dataInf.LastNameOfBatch;
                    Shimmerwriter.WriteLine(starter);
                }
                else { }
                if (dataInf.playBatch.PlayShimmarFlag)
                {
                    dataInf.playBatch.PlayShimmarFlag = false;
                    string starter = "Timestamp: " + dataInf.playBatch.playStart + " Play " + dataInf.playBatch.playBatchName;
                    Shimmerwriter.WriteLine(starter);
                }
                else { }
                if (dataInf.playBatch.PlayedShimmarFlag)
                {
                    dataInf.playBatch.PlayedShimmarFlag = false;
                    string inputkey = "Timestamp: " + dataInf.playBatch.keyTime +" "+ dataInf.playBatch.playBatchName + "_" + dataInf.playBatch.supposedPlayKey + " PlayedKey: " + dataInf.playBatch.key + " " + dataInf.playBatch.hitormiss + " supposedPlayKey: " + dataInf.playBatch.supposedPlayKey;
                    Shimmerwriter.WriteLine(inputkey);
                }
                else { }

                Shimmerwriter.WriteLine(lastSample);
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
            Shimmerwriter.Close();
        }
    }
}

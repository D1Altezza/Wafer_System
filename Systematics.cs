using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wafer_System.Config_Fun;
using static OpenCvSharp.Stitcher;

namespace Wafer_System
{
    public class Systematics
    {
        [JsonProperty("mode")]
        public List<Classify> Mode { get; set; }

    }   
    public class Classify
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("diameter_levels")]
        public List<GradeScore> DiameterLevel { get; set; }
        //public string Thickness { get; set; }
        [JsonProperty("thickness_levels")]
        public List<GradeScore> ThicknessLevel { get; set; }
        //public string TTV { get; set; }
        [JsonProperty("ttv_levels")]
        public List<GradeScore> TTVLevel { get; set; }
        //public string BOW { get; set; }
        [JsonProperty("bow_levels")]
        public List<GradeScore> BowLevel { get; set; }
        //public string WARP { get; set; }
        [JsonProperty("warp_levels")]
        public List<GradeScore> WARPLevel { get; set; }
    }
    public class GradeScore
    {
        [JsonProperty("grade_name")]
        public string Grade { get; set; }
        [JsonProperty("threshold")]
        public string Threshold { get; set; }
        [JsonProperty("high_limit ")]
        public string hLimit { get; set; }
        [JsonProperty("low_limit")]
        public string lLimit { get; set; }
        [JsonProperty("mark_color")]
        public string Mark { get; set; }
    }
  
    public class Systematics_RW
    {
        public bool ReadConfiguration(string FilePath, Systematics config)
        {
            if (!File.Exists(FilePath))
                File.WriteAllText(FilePath, JsonConvert.SerializeObject(config));

            var fileData = File.ReadAllText(FilePath);
            try
            {
                JsonConvert.PopulateObject(fileData, config);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("設定檔內容有誤，請確認!\n" + e.Message, "設定檔內容有誤");
                return false;
            }
        }
        //public bool rrrr() 
        //{
        //    Systematics data = JsonConvert.DeserializeObject<Systematics>(fileData);

        //    // 現在您可以根據需要訪問 data.Modes 中的資料
        //    foreach (var mode in data.Mode)
        //    {
        //        if (mode.Name == "a")
        //        {
        //            foreach (var diameterLevel in mode.DiameterLevel)
        //            {
        //                //Console.WriteLine($"Grade Name: {diameterLevel.Grade}");
        //                //Console.WriteLine($"Threshold: {diameterLevel.Threshold}");
        //                //Console.WriteLine($"High Limit: {diameterLevel.hLimit}");
        //                //Console.WriteLine($"Low Limit: {diameterLevel.lLimit}");
        //                //Console.WriteLine($"Mark Color: {diameterLevel.Mark}");
        //                //Console.WriteLine();
        //            }
        //        }
        //    }
        //    return true;
        //}
       




        public void SaveConfiguration(string FilePath, Systematics config)
        {
            string output = JsonConvert.SerializeObject(config);
            File.WriteAllText(FilePath, output);
        }

    }
}

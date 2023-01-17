using System;
using System.Collections.Generic;

namespace Source.Models
{
    public class ProjectScoreModel
    {
        public int CharacteristicID { get; set; }
        public string Score { get; set; }
        public int ScoreInt { get; set; }
        public ProjectScoreModel()
        {
        }

        public static List<ProjectScoreModel> GetEmptyScoreModels(List<CharacteristicModel> characteristics)
        {
            List<ProjectScoreModel> output = new List<ProjectScoreModel>();
            foreach (var characteristic in characteristics)
            {
                output.Add(new ProjectScoreModel()
                {
                    CharacteristicID = characteristic.ID,
                    Score = "0"
                });
            }
            return output;
        }
    }

    public static class ProjectScoreModelHelper
    {
        public static List<ProjectScoreModel> GetScoreInt(List<ProjectScoreModel> scoreModels)
        {
            Dictionary<String, int> scoreMap = new Dictionary<String, int>()
                {
                    {"0", 0 }, {"A1", 1 }, {"A2", 2 }, {"A3", 3 }, {"B1", 4 }, {"B2", 5 }, {"B3", 6 }, {"C1", 7 }, {"C2", 8 }, {"C3", 9 },
                    {"D1", 10 }, {"D2", 11 }, {"D3", 12 }, {"E1", 13 }, {"E2", 14 }, {"E3", 15 }, {"F1", 16 }, {"F2", 17 }, {"F3", 18 },
                    {"G1", 19 }, {"G2", 20 }, {"G3", 21 }, {"H1", 22 }, {"H2", 23 }, {"H3", 24 }, {"I1", 25 }, {"I2", 26 }, {"I3", 27 },
                    {"J1", 28 }, {"J2", 29 }, {"J3", 30 }, {"K1", 31 }, {"K2", 32 }, {"K3", 33 }, {"L1", 34 }, {"L2", 35 }, {"L3", 36 },
                    {"M1", 37 }, {"M2", 38 }, {"M3", 39 }, {"N1", 40 }, {"N2", 41 }, {"N3", 42 }
                };
            //If the key can be found apply score to scoreint
            foreach (var characteristic in scoreModels)
            {
                int result;
                if (scoreMap.TryGetValue(characteristic.Score, out result))
                {
                    characteristic.ScoreInt = result;
                }
                else
                {
                    characteristic.ScoreInt = 0;
                }
            }

            return scoreModels;
        }
    }
}
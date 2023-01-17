using Newtonsoft.Json;
using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class EvaluateProjectViewModel
    {
        public List<List<ProjectContinuumModel>> Continuum { get; set; }
        public List<ElementModel> Elements { get; set; }
        public List<CharacteristicModel> Characteristics { get; set; }
        public List<ContinuumLevelModel> Levels { get; set; }
        public ProjectModel Project { get; set; }
        public GroupModel Group { get; set; }
        public ProjectEvaluationModel ProjectEvaluation { get; set; }
        public List<StudentModel> StudentsInGroup { get; set; }
        public List<ProjectScoreModel> ScoreList { get; set; }
        public string ScoreStringList { get; set; }

        public EvaluateProjectViewModel(int? projectId, int? groupId)
        {
            Repository repo = new Repository();

            // needs checking
            Continuum = repo.ProjectContinuumModelBuildContinuum();

            //Continuum = ProjectContinuumModelDb.BuildContinuum();
            Elements = repo.ElementSelectAll();
            Characteristics = repo.CharacteristicSelectAll();
            Levels = repo.ContinuumLevelSelectAll();
            Project = repo.ProjectModelSelectOne((int)projectId);
            ProjectEvaluation = new ProjectEvaluationModel();
            Group = repo.GroupModelSelectByGroupID((int)groupId);
            ScoreList = ProjectScoreModel.GetEmptyScoreModels(Characteristics);
            ScoreStringList = SerializeScoreList();
        }

        public EvaluateProjectViewModel() { }

        public void getStudents(int groupId)
        {
            Repository repo = new Repository();

            StudentsInGroup = repo.StudentModelSelectAllInGroup(groupId);
        }

        public string SerializeScoreList()
        {
            string output = JsonConvert.SerializeObject(ScoreList);
            return output;
        }
    }
}
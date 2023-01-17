using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class GlossaryViewModel
    {
        public List<GlossaryModel> AllGlossaryItems { get; set; }
        public List<GlossaryModel> GlossaryByLetter { get; set; }
        public List<GlossaryModel> GlossaryByTerm { get; set; }
        public GlossaryViewModel()
        {
            Repository repo = new Repository();

            AllGlossaryItems = repo.GlossaryModelSelectAll();
            //AllGlossaryItems = GlossaryModelDb.SelectAll();
            GlossaryByLetter = repo.GlossaryModelSelectByLetter('a');
            //GlossaryByLetter = GlossaryModelDb.SelectByLetter('a');
            GlossaryByTerm = repo.GlossaryModelSelectByTerm("absolute phrase");
            //GlossaryByTerm = GlossaryModelDb.SelectByTerm("absolute phrase");
        }
    }
}

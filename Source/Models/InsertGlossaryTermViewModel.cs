using System.Collections.Generic;

namespace Source.Models
{
    public class InsertGlossaryTermViewModel
    {
        public GlossaryModel Glossary { get; set; }
        public List<GlossaryModel> GlossaryItems { get; set; }
    }
}
using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class InsertQuoteViewModel
    {
        public QuoteModel Quote { get; set; }
        public List<QuoteModel> Quotes { get; set; }
        public InsertQuoteViewModel()
        {
            Repository repo = new Repository();

            Quotes = repo.QuoteModelSelectAll();
        }
    }
}
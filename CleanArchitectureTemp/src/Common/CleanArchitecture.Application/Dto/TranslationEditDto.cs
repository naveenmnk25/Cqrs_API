using System.Collections.Generic;

namespace CleanArchitecture.Application.Dto
{
    public class TranslationBaseEditDto
    {
        public TranslationBaseEditDto()
        {
            Translations = new List<TranslationDto>();
        }
        public int TranslationBaseId { get; set; }
        public string Keyword { get; set; }
        public string Language { get; set; }
        public IList<TranslationDto> Translations { get; set; }
    }

    public class TranslationEdit
    {
        public int TranslationId { get; set; }
        public string Keyword { get; set; }
        public string Language { get; set; }
        public bool Active { get; set; }
    }
}

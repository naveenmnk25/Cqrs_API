using System.Collections.Generic;

namespace CleanArchitecture.Application.Dto
{
    public class CompanydDto
    {
        public IList<HeaderDto> Headers { get; set; }
        public IList<TranslationBaseDto> TranslationBases { get; set; }
    }

    public class TranslationBaseDto
    {
        public int TranslationBaseId { get; set; }
        public string Keyword { get; set; }
        public string Language { get; set; }
        public IList<LanguageMappingDto> SecondaryLanguages { get; set; }
        public IList<TranslationDto> TranslationKeywords { get; set; }
    }

    public class HeaderDto
    {
        public string LanguageCode { get; set; }
        public string Language { get; set; }
    }

    public class LanguageMappingDto
    {
        public string LanguageCode { get; set; }
        public IList<TranslationDto> TranslationKeywords { get; set; }
    }

    public class TranslationDto
    {
        public int TranslationId { get; set; }
        public string Keyword { get; set; }
        public string Language { get; set; }
        public bool Active { get; set; }
    }
}

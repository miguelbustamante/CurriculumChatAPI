namespace CurriculumChatAPI.Services;

public class CurriculumResponder : ICurriculumResponder
    {
        private readonly ICurriculumProvider _provider;

        public CurriculumResponder(ICurriculumProvider provider)
        {
            _provider = provider;
        }

        public string GetResponseForIntent(string intent)
        {
            var cv = _provider.Curriculum;

            return intent switch
            {
                "GetName" => $"My name is {cv.Name}.",
                "GetSummary" => cv.Summary,
                "GetEducation" => string.Join(" ", cv.Education.Select(e => 
                    $"I studied {e.Degree} at {e.University} ({e.Year}).")),
                "GetExperience" => string.Join(" ", cv.WorkExperience.Select(e => 
                    $"I worked as {e.Title} at {e.Company} ({e.Duration}). {e.Description}")),
                "GetSkills" => "My skills include: " + string.Join(", ", cv.Skills),
                "GetLanguages" => string.Join(" ", cv.Languages.Select(l => 
                    $"I speak {l.LanguageName} ({l.Proficiency}).")),
                "GetProjects" => string.Join(" ", cv.Projects.Select(p =>
                    $"I worked on {p.Name}, which is {p.Description}")),
                "GetContact" => $"You can reach me at {cv.Contact.Email} or find me on LinkedIn: {cv.Contact.LinkedIn ?? "not provided"}.",
                _ => "I'm not sure how to answer that. Try asking about my experience, skills, or projects!"
            };
        }
    }
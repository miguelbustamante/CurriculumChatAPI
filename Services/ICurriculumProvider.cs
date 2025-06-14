using CurriculumChatAPI.Models;

namespace CurriculumChatAPI.Services;
public interface ICurriculumProvider
    {
        Curriculum Curriculum { get; }
    }
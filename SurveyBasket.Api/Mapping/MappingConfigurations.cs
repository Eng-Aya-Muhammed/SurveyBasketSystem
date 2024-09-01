using Mapster;
using SurveyBasket.API.Contracts.Authentication;
using SurveyBasket.API.Contracts.Polls;
using SurveyBasket.API.Contracts.Questions;
using SurveyBasket.API.Contracts.Users;
using SurveyBasket.API.Entities;
using SurveyBasket.Contracts.Users;

namespace SurveyBasket.API.Mapping
{
    public class MappingConfigurations : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<QuestionRequest, Question>()
                .Map(dest => dest.Answers, src => src.Answers.Select(answer => new Answer { Content = answer }));

            config.NewConfig<RegisterRequest, ApplicationUser>()
                .Map(dest => dest.UserName, src => src.Email);

            config.NewConfig<(ApplicationUser user, IList<string> roles), UserResponse>()
                .Map(dest => dest, src => src.user)
                .Map(dest => dest.Roles, src => src.roles);

            config.NewConfig<CreateUserRequest, ApplicationUser>()
                .Map(dest => dest.UserName, src => src.Email)
                .Map(dest => dest.EmailConfirmed, src => true);

            config.NewConfig<UpdateUserRequest, ApplicationUser>()
                .Map(dest => dest.UserName, src => src.Email)
                .Map(dest => dest.NormalizedUserName, src => src.Email.ToUpper());
        }
    }
}

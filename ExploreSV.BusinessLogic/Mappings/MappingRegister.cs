using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.Entities;
using Mapster;

namespace ExploreSV.BusinessLogic.Mappings
{
    public class MappingRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TouristDestination, TouristDestinationResponse>()
                .Map(tdd => tdd.CategoryName, td => td.Category.CategoryName)
                .Map(tdd => tdd.DepartamentName, td => td.Department.DepartamentName);

            config.NewConfig<TouristDestination, TouristDestinationByIdResponse>()
                .Map(tdd => tdd.CategoryName, td => td.Category.CategoryName)
                .Map(tdd => tdd.DepartamentName, td => td.Department.DepartamentName)
                .Map(tdd => tdd.Images, td => td.Images)

                //Se podrian eliminar ya q son datos de la misma tabla, asi q no es necesario mapearlos
                .Map(tdd => tdd.TouristDestinationTitle, td => td.TouristDestinationTitle)
                .Map(tdd => tdd.TouristDestinationDescription, td => td.TouristDestinationDescription)
                .Map(tdd => tdd.TouristDestinationLocation, td => td.TouristDestinationLocation)
                .Map(tdd => tdd.TouristDestinationSchedule, td => td.TouristDestinationSchedule);

            config.NewConfig<TouristDestination, TouristDestinationByIdResponse>()
                .Map(tdd => tdd.TouristDestinationTitle, td => td.TouristDestinationTitle)
                .Map(tdd => tdd.CategoryName, td => td.Category.CategoryName)
                .Map(tdd => tdd.DepartamentName, td => td.Department.DepartamentName)
                .Map(tdd => tdd.Images, td => td.Images)
                .Map(tdd => tdd.TouristDestinationLocation, td => td.TouristDestinationLocation);

            config.NewConfig<Gastronomy, GastronomyResponse>()
                .Map(gd => gd.TouristDestinationTitle, g => g.TouristDestination.TouristDestinationTitle);

            config.NewConfig<Event, EventResponse>()
                .Map(ed => ed.TouristDestinationTitle, e => e.TouristDestination.TouristDestinationTitle);

            config.NewConfig<User, UserResponse>()
                .Map(ud => ud.RoleName, u => u.Role.RoleName);
        }
    }
}
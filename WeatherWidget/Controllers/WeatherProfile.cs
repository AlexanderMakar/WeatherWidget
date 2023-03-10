using AutoMapper;
using WeatherWidget.Services.Models;

namespace WeatherWidget.Controllers;

public class WeatherProfile: Profile
{
    public WeatherProfile()
    {
        CreateMap<Weather, WeatherResponse>()
            .ForMember(wr => wr.Country, opt => opt.MapFrom(w => w.GeoInfoResponse.Country))
            .ForMember(wr => wr.City, opt => opt.MapFrom(w => w.GeoInfoResponse.Name))
            .ForMember(wr => wr.TemperatureIn–°elsius,
                opt => opt.MapFrom(w => w.WeatherInfoResponse.Main.Temp - 273.15));
    }
}
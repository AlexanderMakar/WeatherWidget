namespace WeatherWidget.Services.Models;

public class WeatherInfoResponse
{
    public Main Main { get; set; }
}

public class Main
{
    public double Temp { get; set; }
}
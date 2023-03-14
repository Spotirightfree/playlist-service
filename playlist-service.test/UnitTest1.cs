using playlist_service.
namespace playlist_service.test
{
    public class UnitTest1
    {
        [Fact]
        public void WeatherForecastTest()
        {
            WeatherForecastController wc = new WeatherForecastController(null);
            var results = wc.Get();
            Assert.NotNull(results);
        }
    }
}
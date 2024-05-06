namespace WeatherInformation.Dto
{
    
    public class WeatherDto
    {
       
        public string resolvedAddress { get; set; }
        public string address { get; set; }
        public string timezone { get; set; }     
        public string description { get; set; }
        public List<Day> days { get; set; }


    }

    public class Day
    {
        public string datetime { get; set; }
        public float tempmax { get; set; }
        public float tempmin { get; set; }
       
    }    

}

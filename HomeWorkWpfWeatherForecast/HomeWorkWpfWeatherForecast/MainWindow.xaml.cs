using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWorkWpfWeatherForecast
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //string site = "http://dataservice.accuweather.com/locations/v1/regions?apikey=qWBhMWlpWjjeVUhJB1VXNztF7ehbwAXz";

            //List<Regions> regions = new List<Regions>();

            //HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            //using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
            //{
            //    string ss = stream.ReadToEnd();
            //    var rootobject = JsonConvert.DeserializeObject<List<Regions>>(ss);
            //}



        }

        private void ButtonClickSearch(object sender, RoutedEventArgs e)
        {
            string site = "http://dataservice.accuweather.com/locations/v1/cities/search?apikey=0OgiOvoljBOcwHtVYsGhkdhnB1zhV40N&q=";

            site += textBoxCity.Text;

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            List<SearchData> data = new List<SearchData>();

            using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
            {
                string JsonFormat = stream.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<SearchData>>(JsonFormat);
            }

            string siteTwo = $"http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/ {data[0].Key}?apikey=0OgiOvoljBOcwHtVYsGhkdhnB1zhV40N";

            req = (HttpWebRequest)HttpWebRequest.Create(siteTwo);
            resp = (HttpWebResponse)req.GetResponse();

            List<BasicInformationInTenHour> tweleHoursOfHourlyForecasts = new List<BasicInformationInTenHour>();

            using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
            {
                string JsonFormat = stream.ReadToEnd();
                tweleHoursOfHourlyForecasts = JsonConvert.DeserializeObject<List<BasicInformationInTenHour>>(JsonFormat);
            }

            dateOne.Content = tweleHoursOfHourlyForecasts[0].DateTime;
            dateTwo.Content = tweleHoursOfHourlyForecasts[3].DateTime;
            dateThree.Content = tweleHoursOfHourlyForecasts[6].DateTime;
            dateFour.Content = tweleHoursOfHourlyForecasts[9].DateTime;

            temperatureOne.Content = tweleHoursOfHourlyForecasts[0].Temperature.Value + tweleHoursOfHourlyForecasts[0].Temperature.Unit;
            temperatureTwo.Content = tweleHoursOfHourlyForecasts[3].Temperature.Value + tweleHoursOfHourlyForecasts[1].Temperature.Unit;
            temperatureThree.Content = tweleHoursOfHourlyForecasts[6].Temperature.Value + tweleHoursOfHourlyForecasts[2].Temperature.Unit;
            temperatureFour.Content = tweleHoursOfHourlyForecasts[9].Temperature.Value + tweleHoursOfHourlyForecasts[3].Temperature.Unit;

            for (int i = 0; i < 10; i++) 
            {
                if (i == 0 || i == 3 || i == 6 || i == 9)
                {
                    switch (tweleHoursOfHourlyForecasts[i].WeatherIcon)
                    {
                        case 1:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/01-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/01-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/01-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/01-s.png") as ImageSource;
                            break;
                        case 2:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/02-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/02-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/02-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/03-s.png") as ImageSource;
                            break;
                        case 3:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/03-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/03-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/03-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/03-s.png") as ImageSource;
                            break;
                        case 4:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/04-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/04-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/04-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/04-s.png") as ImageSource;
                            break;
                        case 5:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/05-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/05-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/05-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/05-s.png") as ImageSource;
                            break;
                        case 6:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/06-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/06-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/06-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/06-s.png") as ImageSource;
                            break;
                        case 7:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/07-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/07-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/07-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/07-s.png") as ImageSource;
                            break;
                        case 8:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/08-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/08-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/08-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/08-s.png") as ImageSource;
                            break;
                        
                        case 11:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/11-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/11-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/11-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/11-s.png") as ImageSource;
                            break;
                        case 12:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/12-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/12-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/12-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/12-s.png") as ImageSource;
                            break;

                        case 13:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/13-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/13-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/13-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/13-s.png") as ImageSource;
                            break;

                        case 14:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/14-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/14-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/14-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/14-s.png") as ImageSource;
                            break;

                        case 15:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/15-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/15-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/15-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/15-s.png") as ImageSource;
                            break;

                        case 16:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/16-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/16-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/16-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/16-s.png") as ImageSource;
                            break;

                        case 17:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/17-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/17-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/17-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/17-s.png") as ImageSource;
                            break;

                        case 18:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/18-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/18-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/18-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/18-s.png") as ImageSource;
                            break;

                        case 19:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/19-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/19-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/19-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/19-s.png") as ImageSource;
                            break;

                        case 20:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/20-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/20-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/20-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/20-s.png") as ImageSource;
                            break;

                        case 21:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/21-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/21-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/21-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/21-s.png") as ImageSource;
                            break;

                        case 22:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/22-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/22-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/22-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/22-s.png") as ImageSource;
                            break;

                        case 23:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/23-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/23-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/23-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/23-s.png") as ImageSource;
                            break;

                        case 24:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/24-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/24-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/24-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/24-s.png") as ImageSource;
                            break;

                        case 25:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/25-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/25-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/25-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/25-s.png") as ImageSource;
                            break;

                        case 26:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/26-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/26-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/26-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/26-s.png") as ImageSource;
                            break;
                        

                        case 29:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/29-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/29-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/29-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/29-s.png") as ImageSource;
                            break;

                        case 30:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/30-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/30-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/30-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/30-s.png") as ImageSource;
                            break;

                        case 31:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/31-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/31-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/31-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/31-s.png") as ImageSource;
                            break;

                        case 32:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/32-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/32-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/32-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/32-s.png") as ImageSource;
                            break;

                        case 33:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/33-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/33-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/33-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/33-s.png") as ImageSource;
                            break;

                        case 34:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/34-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/34-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/34-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/34-s.png") as ImageSource;
                            break;

                        case 35:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/35-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/35-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/35-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/35-s.png") as ImageSource;
                            break;

                        case 36:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/36-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/36-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/36-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/36-s.png") as ImageSource;
                            break;

                        case 37:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/37-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/37-s.png") as ImageSource;
                            else if (i == 6)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/37-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/37-s.png") as ImageSource;
                            break;

                        case 38:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/38-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/38-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/38-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/38-s.png") as ImageSource;
                            break;

                        case 39:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/39-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/39-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/39-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/39-s.png") as ImageSource;
                            break;

                        case 40:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/40-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/40-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/40-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/40-s.png") as ImageSource;
                            break;

                        case 41:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/41-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/41-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/41-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/41-s.png") as ImageSource;
                            break;

                        case 42:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/42-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/42-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/42-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/42-s.png") as ImageSource;
                            break;
                        case 43:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/43-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/43-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/43-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/43-s.png") as ImageSource;
                            break;
                        case 44:
                            if (i == 0)
                                imageOne.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/44-s.png") as ImageSource;
                            else if (i == 3)
                                imageTwo.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/44-s.png") as ImageSource;
                            else if (i == 6)
                                imageThree.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/44-s.png") as ImageSource;
                            else if (i == 9)
                                imageFour.Source = (new ImageSourceConverter()).ConvertFromString("https://developer.accuweather.com/sites/default/files/44-s.png") as ImageSource;
                            break;
                    }
                }
            }

            
        }
    }
}

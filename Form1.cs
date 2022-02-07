using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GettıngPrayersTime
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void getDataButton_Click(object sender, EventArgs e)
		{
			//menggunakan httpclient untuk menggunakan API
			HttpClient httpClient = new HttpClient();
			string endpoint = "http://api.aladhan.com/v1/timingsByAddress"; //url menggunakan api dari aladhan dengan timings by address
			string parameters = "?address=jakarta"; //menggunakan lokasi Jakarta
			string panggil = endpoint + parameters;
			HttpResponseMessage responseMessage =  httpClient.GetAsync(panggil).Result;
			string response = responseMessage.Content.ReadAsStringAsync().Result;
			dynamic resultObject =  JsonConvert.DeserializeObject(response);
			//mengeluarkan output waktu sholat
			subuhLabel.Text = resultObject.data.timings.Fajr;
			zuhrLabel.Text = resultObject.data.timings.Dhuhr;
			asharLabel.Text = resultObject.data.timings.Asr;
			maghribLabel.Text = resultObject.data.timings.Maghrib;
			isyaLabel.Text = resultObject.data.timings.Isha;
			//mengeluarkan output waktu lainnya
			sunlabel.Text = resultObject.data.timings.Sunrise;
			sunsetlabel.Text = resultObject.data.timings.Sunset;
			midlabel.Text = resultObject.data.timings.Midnight;
			imsaklabel.Text = resultObject.data.timings.Imsak;
			datelabel.Text = resultObject.data.date.readable;
			daylabel.Text = resultObject.data.date.gregorian.weekday.en;
			timelabel.Text = resultObject.data.meta.timezone;

		}
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sunlabel_Click(object sender, EventArgs e)
        {

        }
    }
}

//"http://api.aladhan.com/v1/calendarByCity"
//?city=serang&country=indonesia&method=2&month=01&year=2022

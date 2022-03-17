using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace AppaiEstudeMVC.util
{
    public class HttpHelper
    {
        public static HttpClient HttpClientBase(string URLBase, string token = "")
        {
            HttpClient cliente = new HttpClient() { Timeout = new TimeSpan(1, 30, 0) };
            cliente.BaseAddress = new Uri(URLBase);
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //if (SignInReturn != null)
            // cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SignInReturn.AccessToken);

            return cliente;
        }



        public static TipoRetorno RequestGet<TipoRetorno>(HttpClient cliente, string URLRequest)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URLRequest);

            var result = cliente.GetAsync(URLRequest).Result;

            if (result.IsSuccessStatusCode)
                return result.Content.ReadAsAsync<TipoRetorno>().Result;

            return default(TipoRetorno);
            //throw new Exception();



        }



        public static TipoRetorno RequestGet<TipoRetorno>(HttpClient cliente, string URLRequest, int id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URLRequest);

            request.Content = new StringContent(id.ToString());
            cliente.Timeout = new TimeSpan(1, 0, 0);
            var result = cliente.GetAsync(request.ToString()).Result;


            if (result.IsSuccessStatusCode)
                return result.Content.ReadAsAsync<TipoRetorno>().Result;

            return default(TipoRetorno);
            //throw new Exception();



        }


        public static TipoRetorno RequestPost<TipoRetorno, TipoObjetoPost>(HttpClient cliente, string URLRequest, TipoObjetoPost objeto, string token = "")
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, URLRequest);
            request.Content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, cliente.DefaultRequestHeaders.Accept.First().ToString());
            cliente.Timeout = new TimeSpan(1, 0, 0);
            var result = cliente.SendAsync(request).Result;


            if (result.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TipoRetorno>(result.Content.ReadAsStringAsync().Result);

            return default(TipoRetorno);
        }



        public static TipoRetorno RequestPut<TipoRetorno, TipoObjetoPost>(HttpClient cliente, string URLRequest, TipoObjetoPost objeto, string token = "")
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, URLRequest);
            request.Content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, cliente.DefaultRequestHeaders.Accept.First().ToString());
            cliente.Timeout = new TimeSpan(1, 0, 0);
            var result = cliente.SendAsync(request).Result;

            if (result.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TipoRetorno>(result.Content.ReadAsStringAsync().Result);


            return default(TipoRetorno);
        }
       
        public static TipoRetorno RequestDelete<TipoRetorno, TipoObjetoPost>(HttpClient cliente, string URLRequest, int id )
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, URLRequest);
            request.Content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, cliente.DefaultRequestHeaders.Accept.First().ToString());
            cliente.Timeout = new TimeSpan(1, 0, 0);
            var result = cliente.SendAsync(request).Result;

            if (result.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TipoRetorno>(result.Content.ReadAsStringAsync().Result);

            return default(TipoRetorno);
        }
    }
}
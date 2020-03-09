using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CountManagerClient.APIManager
{
   public class RequestAPIManager
    {
        //测试
        public Task<List<Countmes>> test()
        {
            
            Task<List<Countmes>> t = new Task<List<Countmes>>(() =>
            {
                byte[] request_data = Encoding.UTF8.GetBytes("{\"name\":\"汪女士\"}");
                WebRequest webRequest = WebRequest.Create(APIpath.GET_COUNTTYPE_MESSAGE);
                webRequest.Credentials = CredentialCache.DefaultCredentials;
                 webRequest.Method = "POST";
               Stream request_stream = webRequest.GetRequestStream();
                request_stream.Write(request_data,0,request_data.Length);
                request_stream.Close();
                WebResponse response = webRequest.GetResponse();
            
                Stream stream = response.GetResponseStream();
                StreamReader s = new StreamReader(stream);
                string data = s.ReadToEnd();
                s.Close();
                
                stream.Close();
                response.Close();

                Console.WriteLine(data);
                var d = new List<Countmes>();
                try {
                    d = JsonConvert.DeserializeObject<List<Countmes>>(data);
                }
                catch (Exception e) {
                    Console.WriteLine("解析错误"+e.Message);
                }
                return d;


            });
            t.Start();         
             return  t;

        }
        ////获取用户的信息
        //public async Task<(int, List<User>)> getUserMes()
        //{
        //    Task<(int, List<User>)> t = new Task(() =>
        //    {

        //        var request = new RestRequest(APIpath.GET_USER_MESSAGE, Method.GET);
        //        IRestResponse response = client.Execute(request);
        //        int code = (int)response.StatusCode;
        //        Console.WriteLine();
        //        if (response.StatusCode == HttpStatusCode.OK)
        //        {
        //            try
        //            {
        //                try
        //                {
        //                    List<User> list = JsonConvert.DeserializeObject<List<User>>(response.Content);
        //                    return (1, list);
        //                }
        //                catch (Exception e) {
        //                    return (-1, null);
        //                }

        //            }
        //            catch (Exception message)
        //            {
        //                return (-1,null);
        //            }
        //        }
        //        else
        //        {

        //            return (-1,null);
        //        }


        //    });

        //    return await t;
        //}


        //获取某个类型的发票信息
        public  Task<TypeCount> getSomeTypeCount(int type,int page)
        {
            Task<TypeCount> t = new Task<TypeCount>(()=> {

                TypeCount d = null;
                try
                {
                    string str = "{\"type\":" + type + ",\"page\":" + page + "}";
                    byte[] request_data = Encoding.UTF8.GetBytes(str);
                    WebRequest webRequest = WebRequest.Create(APIpath.GET_COUNTTYPE_MESSAGE);
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    webRequest.Method = "POST";
                    Stream request_stream = webRequest.GetRequestStream();
                    request_stream.Write(request_data, 0, request_data.Length);
                    request_stream.Close();
                    WebResponse response = webRequest.GetResponse();

                    Stream stream = response.GetResponseStream();
                    StreamReader s = new StreamReader(stream);
                    string data = s.ReadToEnd();
                    s.Close();

                    stream.Close();
                    response.Close();

                    Console.WriteLine(data);
                
                    d = JsonConvert.DeserializeObject<TypeCount>(data);
                }
                catch (Exception e)
                {
                    Console.WriteLine("解析错误" + e.Message);
                    
                }
                return d;


            });

             t.Start();
            return  t;

        }


        //获取用户
        public Task<UserPage> getUsers(int page) {
            Task<UserPage> t = new Task<UserPage>(() => {

                UserPage d = null;
                try
                {
                    string str = "{\"page\":" + page + "}";
                    byte[] request_data = Encoding.UTF8.GetBytes(str);
                    WebRequest webRequest = WebRequest.Create(APIpath.GET_USER_MESSAGE);
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    webRequest.Method = "POST";
                    Stream request_stream = webRequest.GetRequestStream();
                    request_stream.Write(request_data, 0, request_data.Length);
                    request_stream.Close();
                    WebResponse response = webRequest.GetResponse();

                    Stream stream = response.GetResponseStream();
                    StreamReader s = new StreamReader(stream);
                    string data = s.ReadToEnd();
                    s.Close();

                    stream.Close();
                    response.Close();

                    Console.WriteLine(data);

                    d = JsonConvert.DeserializeObject<UserPage>(data);
                }
                catch (Exception e)
                {
                    Console.WriteLine("解析错误" + e.Message);

                }
                return d;

            } );
            t.Start();
            return t;
        }

        //客户资料修改
        public Task<Dictionary<string, string>> UpdateCust(User user)
        {
            Task<Dictionary<string, string>> t = new Task<Dictionary<string, string>>(() => {

                Dictionary<string,string> d = null;
                try
                {
                    string str = JsonConvert.SerializeObject(user);
                    byte[] request_data = Encoding.UTF8.GetBytes(str);
                    WebRequest webRequest = WebRequest.Create(APIpath.USER_MESSAGE_EDIT);
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    webRequest.Method = "POST";
                    Stream request_stream = webRequest.GetRequestStream();
                    request_stream.Write(request_data, 0, request_data.Length);
                    request_stream.Close();
                    WebResponse response = webRequest.GetResponse();

                    Stream stream = response.GetResponseStream();
                    StreamReader s = new StreamReader(stream);
                    string data = s.ReadToEnd();
                    s.Close();

                    stream.Close();
                    response.Close();

                    Console.WriteLine(data);

                    d = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
                }
                catch (Exception e)
                {
                    Console.WriteLine("解析错误" + e.Message);

                }
                return d;

            });
            t.Start();
            return t;
        }
        //添加顾客资料
        public Task<GetUser> AddCustMes(User user) {
            Task<GetUser> t = new Task<GetUser>(() => {

                GetUser d = null;
                try
                {
                    string str = JsonConvert.SerializeObject(user);
                    byte[] request_data = Encoding.UTF8.GetBytes(str);
                    WebRequest webRequest = WebRequest.Create(APIpath.USER_MESSAGE_ADD);
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    webRequest.Method = "POST";
                    Stream request_stream = webRequest.GetRequestStream();
                    request_stream.Write(request_data, 0, request_data.Length);
                    request_stream.Close();
                    WebResponse response = webRequest.GetResponse();

                    Stream stream = response.GetResponseStream();
                    StreamReader s = new StreamReader(stream);
                    string data = s.ReadToEnd();
                    s.Close();

                    stream.Close();
                    response.Close();

                    Console.WriteLine(data);

                    d = JsonConvert.DeserializeObject<GetUser>(data);
                }
                catch (Exception e)
                {
                    Console.WriteLine("解析错误" + e.Message);

                }
                return d;

            });
            t.Start();
            return t;
        }
        //删除顾客资料
        public Task<Dictionary<string, string>> DelCustMes(int id)
        {
            Task<Dictionary<string, string>> t = new Task<Dictionary<string, string>>(() => {

                Dictionary<string, string> d = null;
                try
                {
                    string str = "{\"id\":"+id+"}";
                    byte[] request_data = Encoding.UTF8.GetBytes(str);
                    WebRequest webRequest = WebRequest.Create(APIpath.USER_MESSAGE_DELETE);
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    webRequest.Method = "POST";
                    Stream request_stream = webRequest.GetRequestStream();
                    request_stream.Write(request_data, 0, request_data.Length);
                    request_stream.Close();
                    WebResponse response = webRequest.GetResponse();

                    Stream stream = response.GetResponseStream();
                    StreamReader s = new StreamReader(stream);
                    string data = s.ReadToEnd();
                    s.Close();

                    stream.Close();
                    response.Close();

                    Console.WriteLine(data);

                    d = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
                }
                catch (Exception e)
                {
                    Console.WriteLine("解析错误" + e.Message);

                }
                return d;

            });
            t.Start();
            return t;
        }
        //添加票据记录 
        public Task<Countmes> AddPj(int id,int money)
        {
            Task<Countmes> t = new Task<Countmes>(() => {

                Countmes d = null;
                try
                {
                    string str = "{\"id\":" + id + ",\"jine\":"+money+"}";
                    byte[] request_data = Encoding.UTF8.GetBytes(str);
                    WebRequest webRequest = WebRequest.Create(APIpath.COUNT_ADD);
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    webRequest.Method = "POST";
                    Stream request_stream = webRequest.GetRequestStream();
                    request_stream.Write(request_data, 0, request_data.Length);
                    request_stream.Close();
                    WebResponse response = webRequest.GetResponse();

                    Stream stream = response.GetResponseStream();
                    StreamReader s = new StreamReader(stream);
                    string data = s.ReadToEnd();
                    s.Close();

                    stream.Close();
                    response.Close();

                    Console.WriteLine(data);

                    d = JsonConvert.DeserializeObject<Countmes>(data);
                }
                catch (Exception e)
                {
                    Console.WriteLine("解析错误" + e.Message);

                }
                return d;

            });
            t.Start();
            return t;
        }

        //获取税号对应的公司
        public Task<List<ShuihaoAndGs>> getShuihaoAndGs()
        {
            Task<List<ShuihaoAndGs>> t = new Task<List<ShuihaoAndGs>>(() => {

                List<ShuihaoAndGs> d = null;
                try
                {           
                    WebRequest webRequest = WebRequest.Create(APIpath.GET_SHUIHAO_GS);
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    webRequest.Method = "GET";
                    WebResponse response = webRequest.GetResponse();

                    Stream stream = response.GetResponseStream();
                    StreamReader s = new StreamReader(stream);
                    string data = s.ReadToEnd();
                    s.Close();
                    stream.Close();
                    response.Close();

                    Console.WriteLine(data);

                    d = JsonConvert.DeserializeObject<List<ShuihaoAndGs>>(data);
                }
                catch (Exception e)
                {
                    Console.WriteLine("解析错误" + e.Message);

                }
                return d;

            });
            t.Start();
            return t;
        }


        //账单的state+1
     
        public Task<Dictionary<string, string>> AddState(int id, int type)
        {
            Task<Dictionary<string, string>> t = new Task<Dictionary<string, string>>(() => {

                Dictionary<string, string> d = null;
                try
                {
                    string str = "{\"_id\":" + id + ",\"type\":" + type + "}";
                    byte[] request_data = Encoding.UTF8.GetBytes(str);
                    WebRequest webRequest = WebRequest.Create(APIpath.COUNT_STATE_ADD);
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    webRequest.Method = "POST";
                    Stream request_stream = webRequest.GetRequestStream();
                    request_stream.Write(request_data, 0, request_data.Length);
                    request_stream.Close();
                    WebResponse response = webRequest.GetResponse();

                    Stream stream = response.GetResponseStream();
                    StreamReader s = new StreamReader(stream);
                    string data = s.ReadToEnd();
                    s.Close();

                    stream.Close();
                    response.Close();

                    Console.WriteLine(data);

                    d = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
                }
                catch (Exception e)
                {
                    Console.WriteLine("解析错误" + e.Message);

                }
                return d;

            });
            t.Start();
            return t;
        }
        ////添加或修改快递单号
        public Task<Dictionary<string, string>> updatekdnum(int id, int num)
        {
            Task<Dictionary<string, string>> t = new Task<Dictionary<string, string>>(() => {

                Dictionary<string, string> d = null;
                try
                {
                    string str = "{\"_id\":" + id + ",\"num\":" + num + "}";
                    byte[] request_data = Encoding.UTF8.GetBytes(str);
                    WebRequest webRequest = WebRequest.Create(APIpath.COUNT_KUAIDI_EDIT);
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    webRequest.Method = "POST";
                    Stream request_stream = webRequest.GetRequestStream();
                    request_stream.Write(request_data, 0, request_data.Length);
                    request_stream.Close();
                    WebResponse response = webRequest.GetResponse();

                    Stream stream = response.GetResponseStream();
                    StreamReader s = new StreamReader(stream);
                    string data = s.ReadToEnd();
                    s.Close();

                    stream.Close();
                    response.Close();

                    Console.WriteLine(data);

                    d = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
                }
                catch (Exception e)
                {
                    Console.WriteLine("解析错误" + e.Message);

                }
                return d;

            });
            t.Start();
            return t;
        }
        ///  //删除信息需要提供密码验证
        public Task<Dictionary<string, string>> checkpassword(int id, int pass)
        {
            Task<Dictionary<string, string>> t = new Task<Dictionary<string, string>>(() => {

                Dictionary<string, string> d = null;
                try
                {
                    string str = "{\"_id\":" + id + ",\"pass\":" + pass + "}";
                    byte[] request_data = Encoding.UTF8.GetBytes(str);
                    WebRequest webRequest = WebRequest.Create(APIpath.MESSAGE_PASSWORD);
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    webRequest.Method = "POST";
                    Stream request_stream = webRequest.GetRequestStream();
                    request_stream.Write(request_data, 0, request_data.Length);
                    request_stream.Close();
                    WebResponse response = webRequest.GetResponse();

                    Stream stream = response.GetResponseStream();
                    StreamReader s = new StreamReader(stream);
                    string data = s.ReadToEnd();
                    s.Close();

                    stream.Close();
                    response.Close();

                    Console.WriteLine(data);

                    d = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
                }
                catch (Exception e)
                {
                    Console.WriteLine("解析错误" + e.Message);

                }
                return d;

            });
            t.Start();
            return t;
        }
    }
    public class APIpath
    {
        public static readonly string BASE_URL = "http://192.168.28.2/newcount/public/index/";
        //获取用户的信息
        public static readonly string GET_USER_MESSAGE = BASE_URL + "index/getUsers";
        //获取某一个类型的票据
        public static readonly string GET_COUNTTYPE_MESSAGE = BASE_URL + "index/getTypeMes";
        //顾客资料修改
        public static readonly string USER_MESSAGE_EDIT = BASE_URL + "index/UpdateCust";
        //添加顾客资料
        public static readonly string USER_MESSAGE_ADD = BASE_URL + "index/AddCustMes";
        //删除顾客资料
        public static readonly string USER_MESSAGE_DELETE = BASE_URL + "index/DelCustMes";
        //添加票据记录 
        public static readonly string COUNT_ADD = BASE_URL + "index/AddPj";
        //获取税号对应的公司
        public static readonly string GET_SHUIHAO_GS = BASE_URL + "index/getShuihaoAndGs";
        //账单的state+1
        public static readonly string COUNT_STATE_ADD = BASE_URL + "index/AddState";
        ////添加或修改快递单号
        public static readonly string COUNT_KUAIDI_EDIT = BASE_URL + "index/updatekdnum";
        //删除信息需要提供密码验证
        public static readonly string MESSAGE_PASSWORD = BASE_URL + "index/checkpassword";

    }


    public class User
    {
        public int _id { get; set; }
        public string rm { get; set; }
        public string gsm { get; set; }
        public string shuihao { get; set; }
        public string lianxifs { get; set; }
        public int bh { get; set; }
        public string address { get; set; }


    }

    public class GetUser {
        public User user { get; set; }
        public string mes { get; set; }
    }

    public class Countmes
    {
        public int _id { get; set; }
        public string rm { get; set; }
        public string gsm { get; set; }
        public string shuihao { get; set; }
        public string lianxifs { get; set; }
        public int money { get; set; }
        public int state { get; set; }
        public int bh { get; set; }
        public string address { get; set; }
        public string kdnum { get; set; }
        public int ?maidandate { get; set; }
        public int ?kaipiaodate { get; set; }
        public int ?lingpiaodate { get; set; }
        public override string ToString()
        {
            return "_id:"+_id+";rm:"+rm+";gsm:"+gsm
                +";money:"+money+":state:"+state+";bh:"+bh;
        }
    }

    public class ShuihaoAndGs {
        public string gsm { get; set; }
        public string shuihao { get; set; }

        public override string ToString()
        {
            return "公司名："+gsm+";税号："+shuihao;
        }
    }
    public class TypeCount {
        public int count { get; set; }
        public List<Countmes> data { get; set; }
    }

    public class UserPage {
        public int count { get; set; }
        public List<User> data { get; set; }
    }
}

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LibraryUI.Utilities
{
    public static class Utilities
    {
        public class ResponseStatus
        {
            public const string Success = "S";
            public const string Failed = "F";
        }
        
        public class APIPath
        {
            public const string AddUser = "/api/User/AddUser";
            public const string UpdateUser = "/api/User/UpdateUser";
            public const string FetchAllUser = "/api/User/FetchAll";
            public const string FetchUserByID = "/api/User/FetchUserByID";
            public const string DeleteUSer = "/api/User/DeleteUser";
            public const string AddBook = "/api/Book/AddBook";
            public const string UpdateBook = "/api/Book/UpdateBook";
            public const string FetchAllBook = "/api/Book/FetchAll";
            public const string FetchBookByID = "/api/Book/FetchBookByID";
            public const string DeleteBook = "/api/Book/DeleteBook";
            public const string Login = "/api/Book/Login";
        }

        public class ResponseMessage
        {
            public const string Success = "Success";
            public const string Failed = "Failed";
            public const string UnAuthorized = "Un Authorized User.";
            public const string NoData = "No data exist.";
        }

        public static string GetAPIPath()
        {
            //var APIPath = configuration.GetSection("APIPath");
            //return "http://localhost:65481/";
            return "https://localhost:44325/";
            //return APIPath.Value;
        }

        public static DataSet ToDataSet<T>(this IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                t.Columns.Add(propInfo.Name, propInfo.PropertyType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();
                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null);
                }
                t.Rows.Add(row);
            }
            ds.Tables.Add(t);

            return ds;
        }

        public static string GetAPICall(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            //request.AddParameter("application/json; charset=utf-8", null, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Content;
            }
            else
            {
                return string.Empty;
            }
        }

    }

    public class PostAPICallWithParam<TClass> where TClass : class
    {
        public static string APICall(TClass param, string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(param), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Content;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
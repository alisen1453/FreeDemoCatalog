using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FreeDemoCatalog.Entities
{


   
    public  class ErrorResponse<T>
    {
        
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; }
      
        [JsonIgnore]
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }
      


        public  ErrorResponse(T data,string message,int statuscode)
        {
            Data = data;
            StatusCode = statuscode;
            Message = message;
            IsSuccessful = true; 
        }
      

        public  ErrorResponse( int statuscode)
        {
                Data = default(T);
                StatusCode = statuscode;
                IsSuccessful = true; 
          
        }
        public  ErrorResponse(List<string> errors, int statuscode)
        {


            Errors = errors;
            StatusCode = statuscode;
            IsSuccessful = false;
            
        }
            public ErrorResponse(string error,int statuscode)
            {


            Errors = new List<string>() { error };
            StatusCode = statuscode;
            IsSuccessful = false;
               


            }

        }
        

 
    



   

    
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Entity
{
    public class Response<T>
    {
        public int state { get; set; }
        public string exception { get; set; }
        public T data { get; set; }

        public static Response<T> Completed(T data)
        {
            var response = new Response<T>
            {
                state = 200,
                data = data,
                exception = string.Empty
            };
            return response;
        }
        public static Response<T> Error(string exception)
        {
            var response = new Response<T>
            {
                state = 100,
                exception = exception
            };
            return response;
        }
    }
}

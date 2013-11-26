﻿using _02EndToEndWebApp_done.Model;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02EndToEndWebApp_done
{
    public class CustomerModule : NancyModule
    {
        public CustomerModule(ICustomerRepository customerRepository) : base("/customers") {
            Get["/generate_test_data"] = _ => {


                return HttpStatusCode.OK;
            };


            Get["/"] = _ => {
                var customers = customerRepository.GetCustomers();
                return Response.AsJson(customers, HttpStatusCode.OK);
            };
        }
    }
}
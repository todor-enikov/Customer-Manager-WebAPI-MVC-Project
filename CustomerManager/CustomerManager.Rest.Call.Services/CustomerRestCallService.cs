﻿using CustomerManager.Common.Models;
using CustomerManager.Rest.Call.Services.Contracts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManager.Rest.Call.Services
{
    public class CustomerRestCallService : ICustomerRestCallService
    {
        private const string baseURL = "http://localhost:56638";
        private readonly IRestClient client;

        public CustomerRestCallService(IRestClient client)
        {
            this.client = client;
            this.client.BaseUrl = new Uri(baseURL);
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            var getAllCustomersRequest = new RestRequest("api/customers");

            var response = this.client.Execute<List<CustomerModel>>(getAllCustomersRequest).Data;

            return response;
        }

        public CustomerByIdModel GetCustomerById(string id)
        {
            var getCustomerByIdRequest = new RestRequest("api/customer/" + id);

            var response = this.client.Execute<CustomerByIdModel>(getCustomerByIdRequest).Data;

            return response;
        }

        public List<OrderModel> GetOrdersByCustomerId(string id)
        {
            var getCustomerByIdRequest = new RestRequest("api/customer/" + id + "/orders");

            var response = this.client.Execute<List<OrderModel>>(getCustomerByIdRequest).Data;

            return response;
        }

        public IEnumerable<CustomerModel> GetCustomerByContactName(string contactName)
        {
            var getAllCustomersRequest = new RestRequest("api/customers");

            var response = this.client.Execute<List<CustomerModel>>(getAllCustomersRequest).Data;

            var resultCustomer = response.Where(x => x.ContactName.Equals(contactName, StringComparison.CurrentCultureIgnoreCase));

            return resultCustomer;
        }
    }
}

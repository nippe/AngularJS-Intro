using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02EndToEndWebApp_done.Model
{
    public class RavenCustomerRepository : ICustomerRepository
    {
        private readonly string STORE_URL = "http://localhost:8080";
        private readonly string STORE_NAME = "AngularDemo";

        public List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>();
            using (var documentStore = new DocumentStore() { Url = STORE_URL })
            {
                documentStore.Initialize();

                using (IDocumentSession session = documentStore.OpenSession(STORE_NAME))
                {
                    var queryResult = from buildbox in session.Query<Customer>()
                                      select buildbox;

                    list = queryResult.ToList<Customer>();
                }
            }
            return list;
        }

        public Customer GetCustomer(int customerId)
        {
            Customer cust;
            using (var documentStore = new DocumentStore() { Url = STORE_URL })
            {
                documentStore.Initialize();
                using (IDocumentSession session = documentStore.OpenSession(STORE_NAME))
                {
                    var queryResult = from c in Queryable.Distinct<Customer>(session.Query<Customer>())
                                      where c.CustomerId == customerId
                                      select c;

                    cust = queryResult.First<Customer>();
                }
            }
            return cust;
        }

        public void DeleteCustomer(Customer cust)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer cust)
        {
            throw new NotImplementedException();
        }

        public void AddCustomer(Customer cust)
        {
            using (var documentStore = new DocumentStore() { Url = STORE_URL })
            {
                documentStore.Initialize();

                using (IDocumentSession session = documentStore.OpenSession(STORE_NAME))
                {
                    session.Store(cust);
                    session.SaveChanges();
                }
            }
        }




        public int GetCustomerCount()
        {
            int count = 0;
            using (var documentStore = new DocumentStore() { Url = STORE_URL })
            {
                documentStore.Initialize();
                using (IDocumentSession session = documentStore.OpenSession(STORE_NAME))
                {
                    RavenQueryStatistics stats = new RavenQueryStatistics();
                    session.Query<Customer>().Statistics(out stats).ToArray();
                    count = stats.TotalResults;
                }
            }
            return count;
        }
    }
}
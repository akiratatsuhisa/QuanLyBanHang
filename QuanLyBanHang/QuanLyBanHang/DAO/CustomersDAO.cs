﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class CustomersDAO
    {
        public List<Customer> GetList() => DataProvider.Instance.DataContext.Customers.ToList();
        public bool AddCustomer(Customer obj, out string serverMessage)
        {
            try
            {
                DataProvider.Instance.DataContext.Customers.Add(obj);
                DataProvider.Instance.DataContext.SaveChanges();
                serverMessage = "Customer Name: " + obj.Name + ", ID: " + obj.CustomerID + " is added.";
                return true;
            }
            catch (Exception ex)
            {
                serverMessage = ex.InnerException != null ? ex.InnerException.InnerException.Message: ex.Message;
                return false;
            }
        }
        public bool EditCustomer(Customer obj, out string serverMessage)
        {
            try
            {
                Customer objE = DataProvider.Instance.DataContext.Customers.Single(o => o.CustomerID == obj.CustomerID);
                objE.Name = obj.Name;
                objE.Gender = obj.Gender;
                objE.PhoneNumber = obj.PhoneNumber;
                objE.Address = obj.Address;
                objE.Email = obj.Email;
                DataProvider.Instance.DataContext.SaveChanges();
                serverMessage = "Customer Name: " + obj.Name + ", ID: " + obj.CustomerID + " is edited.";
                return true;
            }
            catch (Exception ex)
            {
                serverMessage = ex.InnerException != null ? ex.InnerException.InnerException.Message : ex.Message;
                return false;
            }
        }
        public bool DeleteCustomer(int id, out string serverMessage)
        {
            try
            {
                Customer obj = DataProvider.Instance.DataContext.Customers.Single(o => o.CustomerID == id);
                DataProvider.Instance.DataContext.Customers.Remove(obj);
                DataProvider.Instance.DataContext.SaveChanges();
                serverMessage = "Customer Name: " + obj.Name + ", ID: " + obj.CustomerID + " is deleted.";
                return true;
            }
            catch (Exception ex)
            {
                serverMessage = ex.InnerException != null ? ex.InnerException.InnerException.Message : ex.Message;
                return false;
            }
        }
    }
}

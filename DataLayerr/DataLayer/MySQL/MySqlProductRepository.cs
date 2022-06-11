using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using orderSorter.Businesslogic.Business;
using orderSorter.Businesslogic.Interfaces;
using orderSorter.DatabaseMySQL;
using orderSorter.DataProviders;

namespace orderSorter.DataLayer.MySQL
{
    public class MySqlProductRepository : DBConnection, IDataProviderProduct
    {
        public void AddProduct(IProduct product)
        {
          
            //int inStock = (product.InStock ) ? 1 : 0;
            try
            {
                if (OpenConnection())
                {
                    string query = $"INSERT INTO products(id, name, weight, instock) VALUES (\"{product.Id}\",\"{product.Name}\", \"{product.Weight}\" , \"{  Convert.ToInt32(product.InStock)}\" )";
                    MySqlCommand cmd = new MySqlCommand(query, Connection);
                    
                    // Execute Command
                    cmd.ExecuteNonQuery(); 
                    
                    // Close connection
                    CloseConnection();
                }
       
             
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public IProduct FetchProduct(int id)
        {
            throw new NotImplementedException();
        }


        // Nog fixen om met behulp van een id op te halen
        
        /*
        public IProduct FetchProduct(int id)
        {
            try
            {
                if (OpenConnection())
                {
                    string query = "SELECT FROM products WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, Connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader.GetString("name");
                        int weight = reader.GetInt32("weight");
                        int inStock = reader.GetInt32("instock");
                        IProduct product = new Product(id, name, weight, Convert.ToBoolean(inStock));
                        return product;
                    }
                    reader.Close();
                }
            }
            
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
            CloseConnection();
            return null;
        }
        */
        
        
        
        // int weight wordt niet omgezet in een boolean
        public List<IProduct> FetchAllProducts()
        {
            try
            {
                List<IProduct> products = new List<IProduct>();
                if (OpenConnection())
                {
                    string query = "SELECT * FROM products";
                    MySqlCommand cmd = new MySqlCommand(query, Connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string name = reader.GetString("name");
                        int weight = reader.GetInt32("weight");
                        bool inStock = Convert.ToBoolean(reader.GetByte("instock"));
                        IProduct product = new Product(id, name, weight, inStock);
                        products.Add(product);
                        
                     
                    }
                    // Close Data Reader
                    reader.Close();
                    
                    // Close Connection
                    CloseConnection();
                    
                    // return products
                    return products;
                    
                }
                
                
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
            CloseConnection();
            return null;
        }
        
    }
}
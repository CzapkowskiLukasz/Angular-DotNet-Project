﻿using MVC_Project.Domain.Entities;

namespace MVC_Project.Logic.Commons
{
    public static class MappingNameHelper
    {
       public static string GetProductFullName(Product product)
        {
            string result = product.Name;
            if (product.Producer != null)
            {
                result = $"{product.Producer.Name} {result}";
            }
            return result;
        }
    }
}
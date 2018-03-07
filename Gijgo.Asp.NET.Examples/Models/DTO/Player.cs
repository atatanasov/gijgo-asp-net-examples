﻿using System;

namespace Gijgo.Asp.NET.Examples.Models.DTO
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
        public int OrderNumber { get; set; }
    }
}
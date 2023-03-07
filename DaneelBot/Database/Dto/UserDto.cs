using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DaneelBot.Database.Dto;

public class UserDto : DtoModel {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public DateTime LastConnexion { get; set; }

    public int TotalConnexion { get; set; }
}
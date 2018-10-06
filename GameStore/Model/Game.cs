﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Model
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<UserGame> Members { get; set; }
        public ICollection<WishGame> FavoriteMembers { get; set; }
        public float Rating { get; set; }
        public string Logo { get; set; }
        public string VideoUrl { get; set; }
        public string Content { get; set; }
        public ICollection<CategoryGame> Categories { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float Price { get; set; }
        public ICollection<CodeFree> FreeCodes { get; set; }
        //Server=(localdb)\\mssqllocaldb;Database=GameDB;Trusted_Connection=True
        //Server=tcp:gamestorecrosplatformdbserver.database.windows.net,1433;Initial Catalog = GameStoreDb; Persist Security Info=False;User ID = vkhoi; Password=Thatvuhai_7595;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;
        public Game()
        {
            Id = Guid.NewGuid();
            Members = new Collection<UserGame>();
            FavoriteMembers = new Collection<WishGame>();
            FreeCodes = new Collection<CodeFree>();
            Categories = new Collection<CategoryGame>();
            PurchaseDate= DateTime.Now;
        }
    }
}

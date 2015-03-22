using LibraryManagement.DAL;
using LibraryManagement.DAL.Entities;
using LibraryManagement.Enums;
using System;
using System.Collections.Generic;


namespace LibraryManagement.TestData
{
    public static class TestData
    {
        public static List<BaseItemEntity> itemEntities = new List<BaseItemEntity>() { 
            new BookEntity
            {
                ID =  "100",
                BookMetaData =  "1",
                Status = ItemStatus.Borrowed,
                
            }, 
            new BookEntity
            {
                ID =  "101",
                BookMetaData ="2",
                Status = ItemStatus.Borrowed
            },
            new BookEntity
            {
                ID =  "102",
                BookMetaData = "3",
                Status = ItemStatus.Borrowed
            },
            new BookEntity
            {
                ID =  "103",
                BookMetaData = "4",
                Status = ItemStatus.Available
            },
            new BookEntity
            {
                ID =  "104",
                BookMetaData = "5",
                Status = ItemStatus.Available
            },
            new BookEntity
            {
                ID =  "105",
                BookMetaData = "6",
                Status = ItemStatus.Available
            }
        };

        public static List<BaseMetadataEntity> metadataEntities = new List<BaseMetadataEntity>() { 
            new BookMetadataEntity
                {
                    Author = "Dennis Ritchie",
                    ID = "1",
                    BookName = "Let us C#",
                    BookVersion = "v1",
                    Language = "English",
                    Publisher = "Penguin"
                },
                new BookMetadataEntity
                {
                    Author = "Amy Ritchie",
                    ID = "2",
                    BookName = "Let us java",
                    BookVersion = "v1",
                    Language = "English",
                    Publisher = "Penguin"
                },
                new BookMetadataEntity
                {
                    Author = "Johny Ritchie",
                    ID = "3",
                    BookName = "Let us Scala",
                    BookVersion = "v1",
                    Language = "English",
                    Publisher = "Penguin"
                },
                new BookMetadataEntity
                {
                    Author = "Johny Ritchie",
                    ID = "4",
                    BookName = "Let us Scala",
                    BookVersion = "v1",
                    Language = "English",
                    Publisher = "Penguin"
                },
                new BookMetadataEntity
                {
                    Author = "Graham Bell",
                    ID = "5",
                    BookName = "Discovery Telephone",
                    BookVersion = "v1",
                    Language = "Greek",
                    Publisher = "Penguin"
                },
                new BookMetadataEntity
                {
                    Author = "Alex Malley",
                    ID = "6",
                    BookName = "The Naked CEO",
                    BookVersion = "v1",
                    Language = "English",
                    Publisher = "Penguin"
                },
        };

        public static List<UserEntity> userEntities = new List<UserEntity>(){ 
            new UserEntity
                {
                    ID = "200",
                    Password="password",
                    UserEmail="admin@gmail.com",
                    RoleId= RoleEnums.Admin                
                },
                new UserEntity
                {
                   ID = "201",
                    Password="password",
                    UserEmail="librarian@gmail.com",
                    RoleId= RoleEnums.Librarian 
                },
                new UserEntity
                {
                   ID = "202",
                   Password="password",
                   UserEmail="user@gmail.com",
                   RoleId= RoleEnums.User 
                }
        };

        public static List<LendingEntity> lendingEntities = new List<LendingEntity>(){ 
            new LendingEntity
                {
                    ID = "500",
                    ItemIssued= ("100"),                   
                    Issuer= ("200")   ,
                    IssueDate= DateTime.Today.AddDays(-10)
                },
                new LendingEntity
                {
                    ID = "501",
                    ItemIssued= ("101"),                   
                    IssueDate= DateTime.Today.AddDays(-1),
                    Issuer= ("201")  ,
                   
                },
                new LendingEntity
                {
                   ID = "502",
                   ItemIssued= ("102"),                   
                   Issuer= ("202"),
                  IssueDate= DateTime.Today.AddDays(-2)
                }
        };

        public static List<RoleEntity> roleEntities = new List<RoleEntity>(){ 
            new RoleEntity
                {
                    ID = "301",
                    RoleName = RoleEnums.Admin                   
                },
                new RoleEntity
                {
                    ID = "302",
                    RoleName = RoleEnums.Librarian
                },
                new RoleEntity
                {
                   ID = "303",
                   RoleName = RoleEnums.User
                }
        };
    }
}
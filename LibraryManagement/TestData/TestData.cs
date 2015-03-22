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
                Status = ItemStatus.Available
            }, 
            new BookEntity
            {
                ID =  "101",
                BookMetaData ="2",
                Status = ItemStatus.Available
            },
            new BookEntity
            {
                ID =  "102",
                BookMetaData = "3",
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
                    Language = "English"
                },
                new BookMetadataEntity
                {
                    Author = "Amy Ritchie",
                    ID = "2",
                    BookName = "Let us java",
                    BookVersion = "v1",
                    Language = "English"
                },
                new BookMetadataEntity
                {
                    Author = "Johny Ritchie",
                    ID = "3",
                    BookName = "Let us Scala",
                    BookVersion = "v1",
                    Language = "English"
                }
        };

        public static List<BaseMetadataEntity> MetadataEntities {
            get
            {
               return metadataEntities;
            }
            set
            {
            }
        }

        public static List<UserEntity> userEntities = new List<UserEntity>(){ 
            new UserEntity
                {
                    ID = "200",
                    Password="password",
                    UserEmail="test@gmail.com",
                    Roleid= ("300")                  
                },
                new UserEntity
                {
                   ID = "201",
                    Password="password",
                    UserEmail="test2@gmail.com",
                    Roleid= ("301")
                },
                new UserEntity
                {
                   ID = "202",
                   Password="password",
                   UserEmail="test3@gmail.com",
                   Roleid= ("302")
                }
        };

        public static List<LendingEntity> lendingEntities = new List<LendingEntity>(){ 
            new LendingEntity
                {
                    ID = "500",
                    ItemIssued= ("100"),
                   
                    Issuer= ("200")                  
                },
                new LendingEntity
                {
                    ID = "501",
                   ItemIssued= ("101"),
                   
                    Issuer= ("201")  
                   
                },
                new LendingEntity
                {
                   ID = "502",
                   ItemIssued= ("102"),
                   
                    Issuer= ("202")  
                  
                }
        };

        public static List<RoleEntity> roleEntities = new List<RoleEntity>(){ 
            new RoleEntity
                {
                    ID = "301",
                    RoleName = RoleEnum.Admin                   
                },
                new RoleEntity
                {
                    ID = "302",
                    RoleName = RoleEnum.Librarian
                },
                new RoleEntity
                {
                   ID = "303",
                   RoleName = RoleEnum.User
                }
        };
    }
}
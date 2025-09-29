using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Linq;

namespace Raqmiyat.Entities.Login
{
    public class UserMaker
    {
        public int USER_ID { get; set; }

        public string? UserName { get; set; }
                     
        public string? FirstName { get; set; }
                     
        public string? LastName { get; set; }
                     
        public string? EmailAddress { get; set; }
                     
                     
        public string? MobileNo { get; set; }
                     
        public string? Password { get; set; }
                     
        public string? ConfirmPassword { get; set; }
        public string? UserGroup { get; set; }
        public string? HomeBranch { get; set; }
        public string? Role_ID { get; set; }
        public string? Actionby { get; set; }
        public string? USERATTRIBS_DESCRIPTION { get; set; }
        public bool USERATTRIBS_USERSTATUS { get; set; }
        public string? USERATTRIBS_DETAILS { get; set; }
        public string? Roles { get; set; }
        public string? USERATTRIBS_MENU_TYPE { get; set; }
        public string? Status { get; set; }
        public string? ActionType { get; set; }
        public string? Created_On { get; set; }
        public string? Created_By { get; set; }
        public string? IsApproved { get; set; }
        public bool USERATTRIBS_IsDelete { get; set; }
       
        public bool IsCheckerUser { get; set; }
        public bool IsBusinessApprovalChecker { get; set; }
        public bool PasswordNeverExpired { get; set; }
        public string? BusinessHours { get; set; }
        public bool Overrideroles { get; set; }
        public string? Product_ID { get; set; }
        public List<CheckBoxViewModel>? CheckBoxItems { get; set; }
        public List<RoleList>? UserMakerGridList { get; set; }


    }

    public class CheckBoxViewModel
    {
        public int Value { get; set; }
        public string? Text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class RoleList
    {
        public int Role_ID { get; set; }
        public string? Role_Name { get; set; }
        public bool IsSelected { get; set; }
    }
    public class ProductLists
    {
        public string? Prodouct_ID { get; set; }
        public string? Product_Name { get; set; }
        public bool IsSelected { get; set; }
    }
}



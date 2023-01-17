using System;
using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class UserModel
    {
        private string _FirstName;
        private string _MiddleName;
        private string _LastName;
        private string _Email;
        private string _Password;
        private int _RoleID;
        private bool _Active;
        private int _SchoolID;
        private int _DistrictID;
        private string _PhoneNumber;
        private bool _Participate;
        private bool _TestAccount;
        private string _Gender;
        private string _prefix;
        private string _suffix;
        private int _globalRoleId;
        private bool _isVerified;



        public int ID { get; set; }
        [Required(ErrorMessage = "The First Name field is required.")]
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (value != DBNull.Value.ToString()) { _FirstName = value; }
            }
        }
        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                if (value != DBNull.Value.ToString()) { _MiddleName = value; }
            }
        }
        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (value != DBNull.Value.ToString()) { _LastName = value; }
            }
        }
        [Required(ErrorMessage = "The Email field is required.")]
        public string Email
        {
            get { return _Email; }
            set
            {
                if (value != DBNull.Value.ToString()) { _Email = value; }
            }
        }
        public string Password
        {
            get { return _Password; }
            set
            {
                if (value != DBNull.Value.ToString()) { _Password = value; }
            }
        }
        public int RoleID
        {
            get { return _RoleID; }
            set
            { _RoleID = value; }
        }
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public int SchoolID
        {
            get { return _SchoolID; }
            set { _SchoolID = value; }
        }
        public int DistrictID
        {
            get { return _DistrictID; }
            set { _DistrictID = value; }
        }
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set
            {
                if (value != DBNull.Value.ToString()) { _PhoneNumber = value; }
            }
        }
        public bool Participate
        {
            get { return _Participate; }
            set { _Participate = value; }
        }
        public bool TestAccount
        {
            get { return _TestAccount; }
            set { _TestAccount = value; }
        }
        public string Gender
        {
            get { return _Gender; }
            set
            {
                if (value != DBNull.Value.ToString()) { _Gender = value; }
            }
        }
        public string Suffix
        {
            get { return _suffix; }
            set
            {
                if (value != DBNull.Value.ToString()) { _suffix = value; }
                else { _suffix = "N/A"; }
            }
        }
        public string Prefix
        {
            get { return _prefix; }
            set
            {
                if (value != DBNull.Value.ToString()) { _prefix = value; }
                else { _prefix = "N/A"; }
            }
        }
        public bool isVerified
        {
            get { return _isVerified; }
            set
            {
                _isVerified = value;
            }
        }
        public int globalRoleId
        {
            get { return _globalRoleId; }
            set
            {
                _globalRoleId = value;
            }
        }
        public string globalRole { get; set; }
    }

}
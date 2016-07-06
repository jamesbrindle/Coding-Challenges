using System;
using System.Linq;
using System.Web;
using UniEnrollment_MVC.Models;

namespace UniEnrollment_MVC.Helpers
{
    /// <summary>
    /// Used for getting and storing values from browser's cookie store. It's main use is
    /// storing user data and validation of logon and user type
    /// </summary>
    public class CookieHelper
    {
        /// <summary>
        /// Consistent cookie key
        /// </summary>
        private static readonly string _key = "uniEnrollmentUser";

        /// <summary>
        /// For ease in Views
        /// </summary>
        public enum LoggedInUserTypeEnum
        {
            ADMIN,
            PROFESSOR,
            STUDENT,
            NONE
        }

        /// <summary>
        /// Static property to get the logged in user type (i.e. 'Student') as an Enum
        /// </summary>
        public static LoggedInUserTypeEnum LoggedInUserType
        {
            get
            {
                if (!IsLoggedIn())
                    return LoggedInUserTypeEnum.NONE;
                try
                {
                    string cookieValue = GetCookie(_key);
                    string[] cookieValueParts = cookieValue.Split(':');
                    int userTypeInt = Convert.ToInt32(cookieValueParts[1]);

                    string userType = new UniEnrollmentDBEntities().UserTypes.Single(t => t.ID == userTypeInt).Name;

                    if (userType == "Administrator")
                        return LoggedInUserTypeEnum.ADMIN;
                    else if (userType == "Professor")
                        return LoggedInUserTypeEnum.PROFESSOR;
                    else if (userType == "Student")
                        return LoggedInUserTypeEnum.STUDENT;
                    else
                        return LoggedInUserTypeEnum.NONE;
                }
                catch
                {
                    return LoggedInUserTypeEnum.NONE;
                }
            }
        }

        /// <summary>
        /// Static property to get the ID of the logged in user
        /// </summary>
        public static int LoggedInUserID
        {
            get
            {
                try
                {
                    string cookieValue = GetCookie(_key);
                    string[] cookieValueParts = cookieValue.Split(':');

                    return Convert.ToInt32(cookieValueParts[0]);
                }
                catch
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Static property to get the name of the logged in user
        /// </summary>
        public static string LoggedInUserName
        {
            get
            {
                try
                {
                    string cookieValue = GetCookie(_key);
                    string[] cookieValueParts = cookieValue.Split(':');

                    int userId = Convert.ToInt32(cookieValueParts[0]);

                    return new UniEnrollmentDBEntities().Users.Single(u => u.ID == userId).Name;
                }
                catch
                {
                    return String.Empty;
                }
            }
        }

        /// <summary>
        /// Simply sets the user type in the cookie to '99' - Not a recognised user type
        /// </summary>
        public static void LogOut()
        {
            string cookieValue = string.Format("{0}:{1}", 0, 99);
            SetCookie(_key, cookieValue, new TimeSpan(1, 0, 0, 0, 0));
        }

        /// <summary>
        /// Generates the cooke value string and sets the user cookie
        /// </summary>
        /// <param name="userID">User ID integer</param>
        public static void SetLoginCookie(int userID)
        {
            string cookieValue = string.Format("{0}:{1}", userID,
                new UniEnrollmentDBEntities().Users.Single(u => u.ID == userID).UserTypeID);

            // 1 day will do
            SetCookie(_key, cookieValue, new TimeSpan(1, 0, 0, 0, 0));
        }

        /// <summary>
        /// Checks the login cookie to see if a user is looged in
        /// </summary>
        /// <returns>True if a user is logged in</returns>
        public static bool IsLoggedIn()
        {
            if (string.IsNullOrEmpty(GetCookie(_key)))
                return false;
            else
            {
                try
                {
                    string cookieValue = GetCookie(_key);
                    string[] cookieValueParts = cookieValue.Split(':');

                    if (cookieValueParts[1] == "0" || cookieValueParts[1] == "1" ||
                        cookieValueParts[1] == "2" || cookieValueParts[1] == "3")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        #region Actual Cookie Actions

        /// <summary>
        /// Does the actual setting of the browser cookie
        /// </summary>
        /// <param name="key">Name of cookie (or 'key')</param>
        /// <param name="value">Cookie string - whch contains data</param>
        /// <param name="expires">Time to cookie expire</param>
        private static void SetCookie(string key, string value, TimeSpan expires)
        {
            HttpCookie cookie = new HttpCookie(key, value);

            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                var cookieOld = HttpContext.Current.Request.Cookies[key];
                cookieOld.Expires = DateTime.Now.Add(expires);
                cookieOld.Value = cookie.Value;
                HttpContext.Current.Response.Cookies.Add(cookieOld);
            }
            else
            {
                cookie.Expires = DateTime.Now.Add(expires);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// Gets value from specified cookie as a string
        /// </summary>
        /// <param name="key">Name of cookie (or 'key')</param>
        /// <returns>The value in the specified cookie</returns>
        private static string GetCookie(string key)
        {
            string value = string.Empty;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];

            if (cookie != null)
            {
                value = cookie.Value;
            }

            return value;
        }

        #endregion
    }
}
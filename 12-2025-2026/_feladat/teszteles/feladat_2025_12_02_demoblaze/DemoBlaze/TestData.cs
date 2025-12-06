namespace DemoBlaze;

public class TestData
{
    public static string _baseUrl = "https://www.demoblaze.com/";
    
    public static string Title = "STORE";

    public class UserData
    {
        public static string Username = "vb2007";
        public static string Password = "abc123";
        public static string InvalidPassword = "abc1234";
    }

    public class FooterData
    {
        class Titles
        {
            public static string AboutUs = "About Us";
            public static string GetInTouch = "Get in Touch";
        }

        class Content
        {
            public static string AboutUs =
                "We believe performance needs to be validated at every stage of the software development cycle and our open source compatible, massively scalable platform makes that a reality.";
            public static string Address = "Address: 2390 El Camino Real";
            public static string Phone = "Phone: +440 123456";
            public static string Email = "Email: demo@blazemeter.com";
        }

        public static string CopyrightNotice = "Copyright © Product Store";
    }
}
namespace Webteszt_VB;

public class TestData
{
    public static string _baseUrl = "https://allatmenhely-ikt.vb2007.hu";
    public static string _loginUrl = _baseUrl + "/Login";
    public static string _registerUrl = _baseUrl + "/Register";

    public class NavbarData
    {
        public static string NavbarTitle = "Allatmenhely.WebApp";

        public static string HomepageLinkText = "Főoldal";
        public static string AnimalsLinkText = "Állatok";

        public static string LoginButtonText = "Bejelentkezés";
        public static string RegisterButtonText = "Regisztráció";
    }

    public class HomepageData
    {
        public static string BrowserTitle = "Főoldal - Állatmenhely";
        public static string HeaderTitle = "Állatmenhely digitális kezelőfelület";
        public static string Slogan = "A nagy 25 óta partnered állatok professzionális kezelésével.";

        public static string NoLoginContainer = "Kérlek jelentkezz be vagy regisztrálj az összes funkció eléréséhez.";
        public static string SuccessLoginMessageContainer = "Sikeresen bejelentkeztél felhasználóként. Bátran foglalj időpontokat állatok látogatására és örökbefogadására!";
    }

    public class FooterData
    {
        public static string FooterText = "© 2025 - Állatmenhely";
    }

    public class UserData
    {
        public static string ValidUsername = "SeleniumTest";
        public static string ValidRegisteredEmail = "test@test.com";
        public static string ValidPassword = "abc123";

        public static string InvalidUsername = "SeleniumTestInvalid";
        public static string InvalidEmail = "invalid-email";
        public static string InvalidPassword = "123";
    }

    public class LoginPageData
    {
        public static string InvalidCredentialsErrorMessage = "Érvénytelen felhasználónév vagy jelszó.";
    }
}